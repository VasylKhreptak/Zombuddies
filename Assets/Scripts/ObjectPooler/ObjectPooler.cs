using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public sealed class ObjectPooler : MonoBehaviour
{
    [Serializable]
    private class Pool
    {
        public Pools _poolType;
        public GameObject _prefab;
        public int _size;
        [HideInInspector] public GameObject folder;
    }

    [Header("Pool")]
    private Dictionary<Pools, Queue<GameObject>> _poolDictionary;
    [SerializeField] private List<Pool> _pools;

    [Inject] private DiContainer _diContainer;

    #region MonoBehaviour

    private void Awake()
    {
        CreatePoolFolders();

        FillPool();
    }

    private void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    #endregion

    private void CreatePoolFolders()
    {
        foreach (var pool in _pools)
        {
            pool.folder = new GameObject(pool._poolType.ToString());
            pool.folder.transform.parent = gameObject.transform;
        }
    }

    private void FillPool()
    {
        _poolDictionary = new Dictionary<Pools, Queue<GameObject>>();

        for (var i = 0; i < _pools.Count; i++)
        {
            var objectPool = new Queue<GameObject>();

            for (var j = 0; j < _pools[i]._size; j++)
            {
                var obj = _diContainer.InstantiatePrefab(_pools[i]._prefab);
                obj.SetActive(false);

                obj.transform.SetParent(_pools[i].folder.transform);

                objectPool.Enqueue(obj);
            }

            _poolDictionary.Add(_pools[i]._poolType, objectPool);
        }
    }

    public GameObject Spawn(Pools pool, Vector3 position, Quaternion rotation)
    {
        if (_poolDictionary.ContainsKey(pool) == false)
        {
            Debug.LogWarning("Pool with name " + pool + "doesn't exist");
            return null;
        }

        var objectFromPool = _poolDictionary[pool].Dequeue();

        objectFromPool.transform.position = position;
        objectFromPool.transform.rotation = rotation;

        if (objectFromPool.activeSelf)
        {
            objectFromPool.SetActive(false);
        }

        objectFromPool.SetActive(true);

        _poolDictionary[pool].Enqueue(objectFromPool);

        return objectFromPool;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        DisableAllObjects();
    }

    private void DisableAllObjects()
    {
        foreach (Transform poolFolder in transform)
        {
            foreach (Transform poolObjTransform in poolFolder)
            {
                poolObjTransform.gameObject.SetActive(false);
            }
        }
    }
}
