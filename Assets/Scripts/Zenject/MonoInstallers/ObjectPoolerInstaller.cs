using Zenject;

public class ObjectPoolerInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField] private UnityEngine.GameObject _objectPoolerPrefab;
    
    public override void InstallBindings()
    {
        UnityEngine.GameObject instantiatedObject = Container.InstantiatePrefab(_objectPoolerPrefab);
        instantiatedObject.transform.SetParent(null);
        DontDestroyOnLoad(instantiatedObject);

        ObjectPooler objectPooler = instantiatedObject.GetComponent<ObjectPooler>();
        
        Container.BindInstance(objectPooler).AsSingle();
    }
}