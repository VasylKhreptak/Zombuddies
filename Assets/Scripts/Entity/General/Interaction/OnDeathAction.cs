using UnityEngine;

public class OnDeathAction : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private DamageableObject _damageableObject;

    [Header("Data")]
    [SerializeField] private OnDeathActionData _data;
    #region MonoBehaviour

    private void OnValidate()
    {
        _gameObject = gameObject;
        _damageableObject ??= GetComponent<DamageableObject>();
    }

    private void OnEnable()
    {
        _damageableObject.onDeath += StartSelectedAction;
    }

    private void OnDisable()
    {
        _damageableObject.onDeath -= StartSelectedAction;
    }

    #endregion

    private void StartSelectedAction()
    {
        if (_data.DestroyOnDeath)
        {
            Destroy(_gameObject);
        }
        else
        {
            _gameObject.SetActive(false);
        }
    }
}
