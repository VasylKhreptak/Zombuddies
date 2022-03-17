using System;
using UnityEngine;
using Zenject;

public class ZombieAttackParticle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private ZombieAttack _zombieAttack;

    [Header("Preferences")]
    [SerializeField] private ParticleItem[] _particleItems;

    private ObjectPooler _objectPooler;

    [Inject]
    private void Construct(ObjectPooler objectPooler)
    {
        _objectPooler = objectPooler;
    }

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _zombieAttack ??= _transform.root.GetComponent<ZombieAttack>();
    }

    private void OnEnable()
    {
        _zombieAttack.onAttack += TrySpawnParticle;
    }

    private void OnDisable()
    {
        _zombieAttack.onAttack -= TrySpawnParticle;
    }

    #endregion

    private void TrySpawnParticle(ZombieAttackType attackType)
    {
        if (TryGetParticle(attackType, out Pools particle))
        {
            _objectPooler.Spawn(particle, _transform.position, Quaternion.identity);
        }

    }

    private bool TryGetParticle(ZombieAttackType attackType, out Pools particle)
    {
        foreach (var particleItem in _particleItems)
        {
            if (particleItem.attackType == attackType)
            {
                particle = particleItem.particle;

                return true;
            }
        }

        particle = Pools.None;

        return false;
    }

    [Serializable]
    public class ParticleItem
    {
        public Pools particle;
        public ZombieAttackType attackType;
    }
}
