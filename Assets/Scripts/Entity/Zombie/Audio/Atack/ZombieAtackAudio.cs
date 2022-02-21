using UnityEngine;
using Zenject;

public class ZombieAtackAudio : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private ZombieAtack _zombieAtack;

    [Header("Sounds")]
    [SerializeField] private AudioClip[] _audioClips;

    [Inject] private AudioPooler _audioPooler;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _zombieAtack ??= GetComponent<ZombieAtack>();
    }

    private void OnEnable()
    {
        _zombieAtack.onAtack += PlayAudio;
    }

    private void OnDisable()
    {
        _zombieAtack.onAtack -= PlayAudio;
    }

    #endregion

    private void PlayAudio(ZombieAtackType zombieAtackType)
    {
        //_audioPooler.PlayOneShootSound(AudioMixerGroups.SOUND, _audioClips.Random(), _transform.position, 1f, 1f);
    }

    private AudioClip GetAudioClip(ZombieAtackType atackType)
    {
        return null;
    }
}
