using UnityEngine;

public abstract class UIAnimation : MonoBehaviour
{
    public abstract void Animate(bool state);
    public abstract void Kill();
}