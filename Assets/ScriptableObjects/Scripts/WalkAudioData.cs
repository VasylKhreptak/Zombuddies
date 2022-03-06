using UnityEngine;

[CreateAssetMenu(fileName = "WalkAudioData", menuName = "ScriptableObjects/WalkAudioData")]
public class WalkAudioData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private float _startOffset = 1f;
    [SerializeField] private float _rayLength = 1f;
    [SerializeField] private float _taregtWalkSpeed;
    
    [Header("Sound Preferences")]
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _volumeAplifier = 1f;
    
    public float StartOffset => _startOffset;
    public float RayLength => _rayLength;
    public float TaregtWalkSpeed => _taregtWalkSpeed;
    public float MinVolume => _minVolume;
    public float MaxVolume => _maxVolume;
    public float VolumeAplifier => _volumeAplifier;
}
