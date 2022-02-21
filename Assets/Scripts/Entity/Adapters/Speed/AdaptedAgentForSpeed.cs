using System;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.AI;

public class AdaptedAgentForSpeed : SpeedAdapter
{
    [Header("References")]
    [SerializeField] private NavMeshAgent _agent;

    #region MonoBehaviour

    private void OnValidate()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    #endregion
    
    public override Vector3 velocity
    {
        get => _agent.velocity;
        set => _agent.velocity = value;
    }
}
