using System;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class ZombieAtack : MonoBehaviour
{
    public Action<ZombieAtackType> onAtack;

    public void Atack(ZombieAtackType zombieAtackType)
    {
        onAtack?.Invoke(zombieAtackType);

        Debug.Log(zombieAtackType.ToString());
    }
}

public enum ZombieAtackType
{
    Bite = 0,
    Scratch = 1,
}
