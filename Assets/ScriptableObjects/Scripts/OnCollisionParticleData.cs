using UnityEngine;

[CreateAssetMenu(fileName = "OnCollisionParticleData", menuName = "ScriptableObjects/OnCollisionParticleData")]
public class OnCollisionParticleData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private Pools _particle;
    [SerializeField] private Vector3 _rotationOffsset;
    
    public Pools Particle => _particle;
    public Vector3 RotationOffsset => _rotationOffsset;
}
