using UnityEngine;

[CreateAssetMenu(fileName = "OnDeathParticleData", menuName = "ScriptableObjects/OnDeathParticleData")]
public class OnDeathParticleData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private Pools _particle;
    [SerializeField] private Vector3 _offset;
    
    public Pools Particle => _particle;
    public Vector3 Offset => _offset;
}
