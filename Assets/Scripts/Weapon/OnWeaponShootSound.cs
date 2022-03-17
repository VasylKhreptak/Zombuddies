using UnityEngine;
using Zenject;

public class OnWeaponShootSound : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _bulletSpawnPlace;
    [SerializeField] private Weapon _weapon;

    [Header("Sounds")]
    [SerializeField] private AudioClip[] _audioClips;

    [Header("Preferences")]
    [SerializeField] private float _volume = 1f;
    [SerializeField] private float _spatialBlend = 1f;
    
    private AudioPooler _audioPooler;
    
    [Inject]
    private void Construct(AudioPooler audioPooler)
    {
        _audioPooler = audioPooler;
    }
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _weapon ??= GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        _weapon.onShoot += PlaySound;
    }

    private void OnDisable()
    {
        _weapon.onShoot -= PlaySound;
    }

    #endregion

    private void PlaySound()
    {
        _audioPooler.PlayOneShootSound(AudioMixerGroups.SOUND, _audioClips.Random(),
            _bulletSpawnPlace.position, _volume, _spatialBlend);
    }
}
