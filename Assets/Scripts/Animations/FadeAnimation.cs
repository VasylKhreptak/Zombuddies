using DG.Tweening;
using UnityEngine;

public class FadeAnimation : AnimationCore
{
    [Header("References")]
    [SerializeField] private AlphaAdapter _alphaAdapter;

    [Header("Preferences")]
    [SerializeField] private float _duration;
    [SerializeField] private float _startAlpha;
    [SerializeField] private float _targetAlpha = 1f;
    [SerializeField] private AnimationCurve _animationCurve;

    private Tween _fadeTween;

    #region MonoBehaviour

    private void OnValidate()
    {
        _alphaAdapter = GetComponent<AlphaAdapter>();
    }

    private void OnDisable()
    {
        Kill();
    }
    
    #endregion

    public override void Animate(bool state)
    {
        _alphaAdapter.alpha = state ? _startAlpha : _targetAlpha;

        _fadeTween = DOTween
            .To(() => _alphaAdapter.alpha, x => _alphaAdapter.alpha = x, state ? _targetAlpha : _startAlpha, _duration)
            .SetEase(_animationCurve);
    }

    public override void Kill()
    {
        _fadeTween.Kill();
    }
}
