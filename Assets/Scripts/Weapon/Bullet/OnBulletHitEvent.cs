using System;
using UnityEngine;

public class OnBulletHitEvent : CollisionDetector
{
    public Action<float> onHit;

    protected override void OnEnter(Collision collision)
    {
        base.OnEnter(collision);

        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            onHit?.Invoke(bullet.Damage);
        }
    }
}
