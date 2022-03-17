using Zenject;

public class ObjectPoolerInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField] private UnityEngine.GameObject _objectPoolerPrefab;
    
    public override void InstallBindings()
    {
        UnityEngine.GameObject instantiatedObject = Container.InstantiateDontDestroyOnLoad(_objectPoolerPrefab);
        
        Container.Bind<ObjectPooler>().FromComponentOn(instantiatedObject).AsSingle();
    }
}
 