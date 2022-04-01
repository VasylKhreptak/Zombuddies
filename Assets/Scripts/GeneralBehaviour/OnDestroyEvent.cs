using System;
using UnityEngine;

public class OnDestroyEvent : MonoBehaviour
{
    public Action onDestroy;

    #region MonoBehaviour

    private void OnDestroy()
    {
        onDestroy?.Invoke();
    }

    #endregion
}
