using System;
using UnityEngine;
using Zenject;

public class OnDeathParticle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private DamageableObject _damageableObject;

    [Header("Data")]
    [SerializeField] private OnDeathParticleData _data;

    [Inject] private ObjectPooler _objectPooler;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _damageableObject ??= GetComponent<DamageableObject>();
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
        Vector3 position = _transform.position + _data.Offset;
        
        _objectPooler.Spawn(_data.Particle, position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        bool CanDraw() => _transform != null;
        
        if (CanDraw() == false) return;

        Vector3 position = _transform.position + _data.Offset;
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(position, 0.3f);
    }
}
