using System;
using UnityEngine;

public class OnCollisionDisable : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _gameObject;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _gameObject = gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _gameObject.SetActive(false);
    }

    #endregion
}
