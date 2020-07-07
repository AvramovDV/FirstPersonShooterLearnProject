using System;
using UnityEngine;

public class PlayerModel
{
    #region Fields

    private Vector3 _position = Vector3.up;
    private Vector3 _rotation;

    private FlashLightModel _flashLightModel;

    private float _speed = 5f;
    private float _jump = 10f;
    private float _mass = 30f;
    private float _rotationSpeed = 2f;

    #endregion


    #region Propeties

    public Vector3 Position 
    { 
        get => _position;
        set => _position = value;
    }

    public Vector3 Rotation 
    { 
        get => _rotation;
        set => _rotation = value;
    }

    public float Speed { get => _speed; }

    public float Jump { get => _jump; }
    public float Mass { get => _mass; }
    public float RotationSpeed { get => _rotationSpeed; }
    public FlashLightModel FlashLight { get => _flashLightModel; }

    #endregion


    #region ClassLifeCycles

    public PlayerModel()
    {
        _flashLightModel = new FlashLightModel();
    }

    #endregion
}
