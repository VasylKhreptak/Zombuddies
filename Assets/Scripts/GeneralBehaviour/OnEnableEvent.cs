using System;
using UnityEngine;

public class OnEnableEvent : MonoBehaviour
{
    public Action onEnable;

    #region MonoBehaviour

    private void OnEnable()
    {
        onEnable?.Invoke();
    }

    #endregion
}
