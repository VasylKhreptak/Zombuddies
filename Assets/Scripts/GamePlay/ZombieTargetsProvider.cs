using System;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTargetsProvider : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] private List<Transform> _targets;

    public Action<Transform> onAddTarget;

    public void AddTarget(Transform target)
    {
        _targets.Add(target);
        
        onAddTarget.Invoke(target);
    }

    public Transform GetClosestTarget(Transform start)
    {
        if (HasInappropriateElement(_targets, out var inappropriateElement))
        {
            _targets.Remove(inappropriateElement);
        }

        return _targets.Count == 0 ? null : start.FindClosestTransform(_targets.ToArray());
    }

    private bool HasInappropriateElement<T>(List<T> list, out T element) where T : Component
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].gameObject.IsValid() == false)
            {
                element = list[i];

                return true;
            }
        }

        element = null;

        return false;
    }
}
