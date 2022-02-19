using UnityEngine;

public class AdaptedCanvasGroupForAlpha : AlphaAdapter
{
    [Header("References")]
    [SerializeField] private CanvasGroup _canvasGroup;

    public override float alpha
    {
        get => _canvasGroup.alpha;
        set => _canvasGroup.alpha = value;
    }
}