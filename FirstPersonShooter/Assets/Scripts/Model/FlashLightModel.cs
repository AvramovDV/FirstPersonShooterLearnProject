using System;

public class FlashLightModel
{
    #region Fields

    private float _intensety = 2f;
    private float _batteryMaxEnergy = 1f;
    private float _batteryCurrentEnergy = 1f;
    private float _blinkthreshold = 0.4f;
    private float _loseEnergySpeed = 0.01f;
    private bool _isActive = false;

    #endregion


    #region Propeties

    public float Intensety { get => _intensety; }
    public float BatteryMaxEnergy { get => _batteryMaxEnergy; }
    public float BatteryCurrentEnergy 
    { 
        get => _batteryCurrentEnergy;
        set
        {
            _batteryCurrentEnergy = value;
            if (_batteryCurrentEnergy > _batteryMaxEnergy)
            {
                _batteryCurrentEnergy = _batteryMaxEnergy;
            }
            if (_batteryCurrentEnergy < 0f)
            {
                _batteryCurrentEnergy = 0f;
            }
        }
    }
    public float BlinkThreshold { get => _blinkthreshold; }

    public float LoseEnergySpeed { get => _loseEnergySpeed; }

    public bool IsActive { get => _isActive; set => _isActive = value; }

    #endregion
}
