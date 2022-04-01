using UnityEngine;

public class OnDestroyEventLinker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private OnDestroyEvent _destroyEvent;

    #region MonoBehaviour

    private void OnValidate()
    {
        _gameObject = gameObject;
        _destroyEvent ??= GetComponent<OnDestroyEvent>();
    }

    private void Awake()
    {
        _destroyEvent.onDestroy += Destroy;
    }

    private void OnDestroy()
    {
        _destroyEvent.onDestroy -= Destroy;
    }

    private void Destroy()
    {
        Destroy(_gameObject);
    }
    
    #endregion
}
