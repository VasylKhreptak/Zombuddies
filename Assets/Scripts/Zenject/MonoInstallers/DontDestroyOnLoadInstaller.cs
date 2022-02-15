using Zenject;

public class DontDestroyOnLoadInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField] private UnityEngine.GameObject[] _gameObjects;
    
    public override void InstallBindings()
    {
        foreach (var gameObj in _gameObjects)
        {
            UnityEngine.GameObject instantiatedObject = Instantiate(gameObj);
            DontDestroyOnLoad(instantiatedObject);
        }
    }
}