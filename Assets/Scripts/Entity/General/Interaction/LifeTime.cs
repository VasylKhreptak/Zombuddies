using System;
using DG.Tweening;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _gameObject;

    [Header("Preferences")]
    [SerializeField] private float _lifeTime;

    [Header("On Time Out Action")]
    [SerializeField] private bool _destroy;

    private Tween _waitTween;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _gameObject = gameObject;
    }

    private void OnEnable()
    {
        StartTimer();
    }

    private void OnDisable()
    {
        _waitTween.Kill();
    }

    #endregion

    private void StartTimer()
    {
        _waitTween.Kill();
        _waitTween = this.DOWait(_lifeTime).OnComplete(StartSelectedAction);
    }

    private void StartSelectedAction()
    {
        if (_destroy)
        {
            Destroy(_gameObject);
        }
        else
        {
            _gameObject.SetActive(false);
        }
    }
}
