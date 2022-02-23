using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class ZombieAtackAudio : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [FormerlySerializedAs("_zombieAtack")]
    [SerializeField] private ZombieAttack _zombieAttack;

    [Header("Sounds")]
    [SerializeField] private AudioItem[] _audioItems;

    [Inject] private AudioPooler _audioPooler;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _zombieAttack ??= GetComponent<ZombieAttack>();
    }

    private void OnEnable()
    {
        _zombieAttack.onAttack += PlayAudio;
    }

    private void OnDisable()
    {
        _zombieAttack.onAttack -= PlayAudio;
    }

    #endregion

    private void PlayAudio(ZombieAttackType zombieAttackType)
    {
        _audioPooler.PlayOneShootSound(AudioMixerGroups.SOUND, GetAudioClip(zombieAttackType),
            _transform.position, 1f, 1f);
        
        Debug.Log("kjsadhfkjh");
    }

    private AudioClip GetAudioClip(ZombieAttackType attackType)
    {
        foreach (var audioItem in _audioItems)
        {
            if (audioItem.zombieAttackType == attackType)
            {
                return audioItem.audioClips.Random();
            }
        }

        throw new ArgumentException("Invalid parameter of type: " + (typeof(ZombieAttackType)));
    }

    [Serializable]
    public class AudioItem
    {
        public ZombieAttackType zombieAttackType;
        [FormerlySerializedAs("_audioClips")]
        public AudioClip[] audioClips;
    }
}
