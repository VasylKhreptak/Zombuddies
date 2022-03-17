using System;

public interface IWeapon
{
    public event Action onStartShooting;
    public event Action onStopShooting;
    public event Action onShoot;
    
    public void StartShooting();

    public void StopShooting();
}
