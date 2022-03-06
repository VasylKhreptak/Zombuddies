using UnityEngine;

[CreateAssetMenu(fileName = "ZombieAttackAnimationData", menuName = "ScriptableObjects/ZombieAttackAnimationData")]
public class ZombieAttackAnimationData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private string _animatorAtackParameter;
    [SerializeField] private string _attackIndexParameter;
    [SerializeField] private int _minAtackIndex;
    [SerializeField] private int _maxAtackIndex;
    [SerializeField] private float _animateDelay = 2f;
    
    public string AnimatorAtackParameter => _animatorAtackParameter;
    public string AttackIndexParameter => _attackIndexParameter;
    public int MinAtackIndex => _minAtackIndex;
    public int MaxAtackIndex => _maxAtackIndex;
    public float AnimateDelay => _animateDelay;
}
