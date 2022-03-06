using UnityEngine;

[CreateAssetMenu(fileName = "OnDeathActionData", menuName = "ScriptableObjects/OnDeathActionData")]
public class OnDeathActionData : ScriptableObject
{
    [Header("Action")]
    [SerializeField] private bool _destroyOnDeath;
    
    public bool DestroyOnDeath => _destroyOnDeath;
}
