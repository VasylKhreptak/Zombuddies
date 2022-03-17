using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class OnCollisionParticle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CollisionDetector _collisionDetector;

    [Header("Data")]
    [SerializeField] private OnCollisionParticleData _data;

    private ObjectPooler _objectPooler;

    [Inject]
    private void Construct(ObjectPooler objectPooler)
    {
        _objectPooler = objectPooler;
    }
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _collisionDetector ??= GetComponent<CollisionDetector>();
    }

    private void OnEnable()
    {
        _collisionDetector.onEnter += SpawnParticle;
    }

    private void OnDisable()
    {
        _collisionDetector.onEnter -= SpawnParticle;
    }

    #endregion

    private void SpawnParticle(Collision collision)
    {
        ContactPoint contactPoint = collision.GetContact(0);
        
        Vector3 position = contactPoint.point;
        
        Quaternion rotation = quaternion.LookRotation(contactPoint.normal, Vector3.up);
        
        rotation = quaternion.Euler(rotation.eulerAngles + _data.RotationOffsset);

        _objectPooler.Spawn(_data.Particle, position, rotation);
    }
}
