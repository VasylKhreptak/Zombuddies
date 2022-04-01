using UnityEngine;

public class OnEnableEventLinker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private OnEnableEvent _enableEvent;

    #region MonoBehaviour

    private void OnValidate()
    {
        _gameObject = gameObject;
        _enableEvent ??= GetComponent<OnEnableEvent>();
    }

    private void Awake()
    {
        _enableEvent.onEnable += Enable;
    }

    private void OnDestroy()
    {
        _enableEvent.onEnable -= Enable;
    }

    #endregion

    private void Enable()
    {
        _gameObject.SetActive(true);
    }
}
