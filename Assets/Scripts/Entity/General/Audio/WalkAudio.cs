using System;
using UnityEngine;
using Zenject;

public class WalkAudio : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private SpeedAdapter _speedAdapter;

    [Header("Audios")]
    [SerializeField] private AudioItem[] _audioItems;
    [SerializeField] private AudioClip[] _defaultStepSounds;

    [Header("Data")]
    [SerializeField] private WalkAudioData _data;

    [Inject] private AudioPooler _audioPooler;

    #region MonoHebaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _groundChecker ??= GetComponent<GroundChecker>();
        _speedAdapter ??= GetComponent<SpeedAdapter>();
    }

    #endregion

    public void TryPlayStepSound()
    {
        if (CanPlayStepSound())
        {
             PlayStepSound();
        }
    }

    private bool CanPlayStepSound()
    {
        return _groundChecker.IsGrounded();
    }

    private void PlayStepSound()
    {
        AudioClip audioClip = GetAudioClip();

        _audioPooler.PlayOneShootSound(AudioMixerGroups.SOUND, audioClip, _transform.position, 
            GetVolume(), 1f);
    }

    private AudioClip GetAudioClip()
    {
        Ray ray = new Ray(_transform.position + new Vector3(0, _data.StartOffset, 0),
            Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _data.RayLength))
        {
            foreach (var audioItem in _audioItems)
            {
                if (audioItem.layerMask.ContainsLayer(hitInfo.collider.gameObject.layer))
                {
                    return audioItem.stepSounds.Random();
                }
            }

        }

        return _defaultStepSounds.Random();
    }

    private float GetVolume()
    {
        float speed = _speedAdapter.velocity.magnitude;

        float unclampedVolume = speed / _data.TaregtWalkSpeed;

        return Mathf.Clamp(unclampedVolume, _data.MinVolume, _data.MaxVolume) * _data.VolumeAplifier;
    }
    
    private void OnDrawGizmosSelected()
    {
        bool CanDraw() => _transform != null;
        
        if (CanDraw() == false) return;

        Gizmos.color = Color.green;
        Gizmos.DrawRay(_transform.position + new Vector3(0, _data.StartOffset, 0),
            Vector3.down * _data.RayLength);
    }

    [Serializable]
    public class AudioItem
    {
        public LayerMask layerMask;
        public AudioClip[] stepSounds;
    }
}

public enum SurfaceType
{
    Grass = 0,
    Sand = 1,
    Wood = 2,
}
