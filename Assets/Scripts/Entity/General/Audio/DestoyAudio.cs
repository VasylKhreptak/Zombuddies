using UnityEngine;
using Zenject;

public class DestoyAudio : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private DamageableObject _damageableObject;

    [Header("Sounds")]
    [SerializeField] private AudioClip[] _audioClips;
    
    [Inject]
    private AudioPooler _audioPooler;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
        _damageableObject = GetComponent<DamageableObject>();
    }

    private void OnEnable()
    {
        _damageableObject.onDeath += PlaySound;
    }

    private void OnDisable()
    {
        _damageableObject.onDeath -= PlaySound;
    }

    #endregion

    private void PlaySound()
    {
        _audioPooler.PlayOneShootSound(AudioMixerGroups.SOUND, _audioClips.Random(), _transform.position, 1f, 1f);
    }
}
