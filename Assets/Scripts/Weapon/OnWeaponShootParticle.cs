using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class OnWeaponShootParticle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _particleSpawnPlace;
    [SerializeField] private Weapon _weapon;

    [Header("Preferences")]
    [SerializeField] private Pools _particle;
    [SerializeField] private Vector3 _rotationOffset;

    [Inject] private ObjectPooler _objectPooler;

    #region MonoBehaviour

    private void OnValidate()
    {
        _weapon ??= GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        _weapon.onShoot += SpawnParticle;
    }

    private void OnDisable()
    {
        _weapon.onShoot -= SpawnParticle;
    }

    #endregion

    private void SpawnParticle()
    {
        Quaternion rotataion = Quaternion.LookRotation(_particleSpawnPlace.forward, Vector3.up);
        
        rotataion = quaternion.Euler(rotataion.eulerAngles + _rotationOffset);

        _objectPooler.Spawn(_particle, _particleSpawnPlace.position, rotataion);
    }
}
