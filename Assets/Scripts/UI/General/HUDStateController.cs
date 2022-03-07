using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDStateController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DamageableObject _playerDamageableObject;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;

    #region MonoBehaviour

    private void OnValidate()
    {
        _graphicRaycaster ??= GetComponent<GraphicRaycaster>();
    }

    private void OnEnable()
    {
        _playerDamageableObject.onDeath += DisableHUD;
        _playerDamageableObject.onResurrection += EnableHUD;
    }

    private void OnDisable()
    {
        _playerDamageableObject.onDeath -= DisableHUD;
        _playerDamageableObject.onResurrection -= EnableHUD;
    }

    #endregion

    private void EnableHUD() => SetHUDState(true);

    private void DisableHUD() => SetHUDState(false);
    
    private void SetHUDState(bool state)
    {
        _graphicRaycaster.enabled = state;
    }
}
