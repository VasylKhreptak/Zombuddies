using UnityEngine;

public static class TransformExtensions
{
    public static Transform FindClosestTransform(this Transform transform, Transform[] transforms)
    {
        Transform closestTransform = null;
        var closestDistanceSqr = Mathf.Infinity;

        foreach (var potentiaTransform in transforms)
        {
            var directionToTarget = potentiaTransform.position - transform.position;
            var sqrDirectionToTarget = directionToTarget.sqrMagnitude;

            if (sqrDirectionToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = sqrDirectionToTarget;
                closestTransform = potentiaTransform;
            }
        }

        return closestTransform;
    }
}
