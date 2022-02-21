using System;
using UnityEngine;
using Zenject;

public class WalkAudio : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private GroundChecker _groundChecker;

    [Header("Preferences")]
    [SerializeField] private float _startOffset = 1f;
    [SerializeField] private float _rayLength = 1f;

    [Header("Audio Preferences")]
    [SerializeField] private AudioItem[] _audioItems;
    [SerializeField] private AudioClip[] _defaultStepSounds;

    [Inject] private AudioPooler _audioPooler;

    #region MonoHebaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _groundChecker ??= GetComponent<GroundChecker>();
    }

    #endregion

    public void TryPlayStepSound()
    {
        if (CanPlayStepSound())
        {
             PlayStepSound();
        }
    }


    private AudioClip GetAudioClip()
    {
        Ray ray = new Ray(_transform.position + new Vector3(0, _startOffset, 0),
            Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _rayLength))
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

    private bool CanPlayStepSound()
    {
        return _groundChecker.IsGrounded();
    }

    private void PlayStepSound()
    {
        AudioClip audioClip = GetAudioClip();

        _audioPooler.PlayOneShootSound(AudioMixerGroups.SOUND, audioClip, _transform.position, 1f, 1f);
    }

    private void OnDrawGizmosSelected()
    {
        if (_transform == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawRay(_transform.position + new Vector3(0, _startOffset, 0),
            Vector3.down * _rayLength);
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
