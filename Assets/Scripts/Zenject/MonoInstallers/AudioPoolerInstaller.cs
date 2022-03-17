using System;
using Zenject;

public class AudioPoolerInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField] private UnityEngine.GameObject _audioPoolerPrefab;
    
    public override void InstallBindings()
    {
        UnityEngine.GameObject instantiatedObject = Container.InstantiateDontDestroyOnLoad(_audioPoolerPrefab);

        Container.Bind<AudioPooler>().FromComponentOn(instantiatedObject).AsSingle();
    }
}