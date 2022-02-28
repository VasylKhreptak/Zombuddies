using System;
using UnityEngine;

public static class GameObjectExtensions 
{
    public static bool IsValid(this GameObject gameObject)
    {
        return gameObject != null && gameObject.activeSelf;
    }
}
