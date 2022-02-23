using System;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TriggerComponent _attackZone;

    [Header("Preferences")]
    [SerializeField] private Atack[] _atacks;

    public Action<ZombieAttackType> onAttack;

    #region MonoBehaviour

    private void OnValidate()
    {
        _attackZone ??= GetComponent<TriggerComponent>();
    }

    #endregion

    public void TryAttack(ZombieAttackType zombieAttackType)
    {
        if (_attackZone.affectedGameObject != null &&
            _attackZone.affectedGameObject.TryGetComponent(out IHealth health))
        {
            onAttack?.Invoke(zombieAttackType);
            health.TakeDamage(GetDamageValue(zombieAttackType));
        }
    }

    private float GetDamageValue(ZombieAttackType attackType)
    {
        foreach (var atack in _atacks)
        {
            if (atack.type == attackType)
            {
                return atack.damage;
            }
        }

        throw new ArgumentException("Invalid parameter of type: " + (typeof(ZombieAttackType)));
    }

    [Serializable]
    public class Atack
    {
        public ZombieAttackType type;
        public float damage;
    }
}

public enum ZombieAttackType
{
    Bite = 0,
    RightScratch = 1,
    LeftScratch = 2,
}
