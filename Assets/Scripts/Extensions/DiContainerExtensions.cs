using UnityEngine;
using Zenject;

public static class DiContainerExtensions 
{
    public static GameObject InstantiateDontDestroyOnLoad(this  DiContainer container, GameObject gameObject)
    {
        GameObject instance = container.InstantiatePrefab(gameObject);

        instance.transform.SetParent(null);
        
        Object.DontDestroyOnLoad(instance);

        return instance;
    }
}
