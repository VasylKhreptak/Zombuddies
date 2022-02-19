using UnityEngine;
using Zenject;

public class JoystickInstaller : MonoInstaller
{
    [Header("References")]
    [SerializeField] private Joystick _joystick;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_joystick).AsCached();
    }
}