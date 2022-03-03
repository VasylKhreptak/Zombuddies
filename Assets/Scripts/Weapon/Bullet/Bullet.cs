using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private BulletData _data;

    public float Damage => Random.Range(_data.MinDamage, _data.MaxDamage);
}
