using UnityEngine;
using Zenject;

public class ZombieTargetsProviderInstaller : MonoInstaller
{
    [Header("References")]
    [SerializeField] private ZombieTargetsProvider _targetsProvider;

    public override void InstallBindings()
    {
        Container.BindInstance(_targetsProvider).AsSingle(); 
    }
}
