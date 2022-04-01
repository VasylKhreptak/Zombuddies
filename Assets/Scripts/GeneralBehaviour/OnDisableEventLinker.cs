using UnityEngine;

public class OnDisableEventLinker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private OnDisableEvent _disableEvent;

    #region MonoBehaviour

    private void OnValidate()
    {
        _gameObject = gameObject;
        _disableEvent ??= GetComponent<OnDisableEvent>();
    }

    private void OnEnable()
    {
        _disableEvent.onDisable += Disable;
    }

    private void OnDisable()
    {
        _disableEvent.onDisable -= Disable;
    }

    private void Disable()
    {
        _gameObject.SetActive(false);
    }
    
    #endregion
}
