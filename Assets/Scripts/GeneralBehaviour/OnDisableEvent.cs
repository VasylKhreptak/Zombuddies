using System;
using UnityEngine;

public class OnDisableEvent : MonoBehaviour
{
    public Action onDisable;

    #region MonoBehaviour

    private void OnDisable()
    {
        onDisable?.Invoke();
    }

    #endregion
}