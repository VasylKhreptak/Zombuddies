using System;
using UnityEngine;
using Zenject;

public class DestroyParticle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private DamageableObject _damageableObject;

    [Header("Preferences")]
    [SerializeField] private Pools _particle;
    [SerializeField] private Vector3 _offset;

    [Inject] private ObjectPooler _objectPooler;

    private Vector3 _position;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _damageableObject ??= GetComponent<DamageableObject>();
    }

    private void Awake()
    {
        _position = _transform.position + _offset;
    }

    private void OnEnable()
    {
        _damageableObject.onDeath += SpawnParticle;
    }

    private void OnDisable()
    {
        _damageableObject.onDeath -= SpawnParticle;
    }

    #endregion

    private void SpawnParticle()
    {
        _objectPooler.GetFromPool(_particle, _transform.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        if (_transform == null) return;

        Vector3 position = _transform.position + _offset;
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(position, 0.3f);
    }
}
