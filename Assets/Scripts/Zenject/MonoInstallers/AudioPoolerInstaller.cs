using System;
using Zenject;

public class AudioPoolerInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField] private UnityEngine.GameObject _audioPoolerPrefab;
    
    public override void InstallBindings()
    {
        UnityEngine.GameObject instantiatedObject = Container.InstantiatePrefab(_audioPoolerPrefab);
        instantiatedObject.transform.SetParent(null);
        DontDestroyOnLoad(instantiatedObject);
        
        AudioPooler audioPooler = instantiatedObject.GetComponent<AudioPooler>();

        Container.BindInstance(audioPooler).AsSingle();
    }
}