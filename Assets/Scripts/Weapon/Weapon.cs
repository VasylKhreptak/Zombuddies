using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour, IWeapon
{
    [Header("References")]
    [SerializeField] private Transform _bulletSpawnPlace;

    [Header("Shoot Preferences")]
    [SerializeField] private float _shootDelay = 0.2f;
    [SerializeField] private Pools _bullet;

    private ObjectPooler _objectPooler;

    private Coroutine _shootCoroutine;

    public event Action onStartShooting;
    public event Action onStopShooting;
    public event Action onShoot;
    
    [Inject]
    private void Construct(ObjectPooler objectPooler)
    {
        _objectPooler = objectPooler;
    }

    public void StartShooting()
    {
        if (_shootCoroutine == null)
        {
            onStartShooting?.Invoke();

            _shootCoroutine = StartCoroutine(ShootRoutine());
        }
    }
    public void StopShooting()
    {
        if (_shootCoroutine != null)
        {
            onStopShooting?.Invoke();

            StopCoroutine(_shootCoroutine);

            _shootCoroutine = null;
        }
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();

            yield return new WaitForSeconds(_shootDelay);
        }
    }

    private void Shoot()
    {
        onShoot?.Invoke();

        SpawnBullet();
    }

    private void SpawnBullet()
    {
        Quaternion rotation = quaternion.LookRotation(_bulletSpawnPlace.forward, Vector3.up);

        _objectPooler.Spawn(_bullet, _bulletSpawnPlace.position, rotation);
    }
}
