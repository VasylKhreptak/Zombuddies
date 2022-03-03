using UnityEngine;

public class OnBulletHitDamage : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DamageableObject _damageableObject;
    [SerializeField] private OnBulletHitEvent _bulletHitEvent;

    #region MonoBehaviour

    private void OnValidate()
    {
        _damageableObject ??= GetComponent<DamageableObject>();
        _bulletHitEvent ??= GetComponent<OnBulletHitEvent>();
    }

    private void OnEnable()
    {
        _bulletHitEvent.onHit += _damageableObject.TakeDamage;
    }

    private void OnDisable()
    {
        _bulletHitEvent.onHit -= _damageableObject.TakeDamage;

    }

    #endregion
}
