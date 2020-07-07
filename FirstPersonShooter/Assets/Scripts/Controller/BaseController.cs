using UnityEngine;


public abstract class BaseController
{
    #region Propeties

    public bool isActive { get; private set; }

    #endregion


    #region Methods

    public virtual void On() 
    {
        isActive = true;
    }

    public virtual void Off() 
    {
        isActive = false;
    }

    public virtual void Switch()
    {
        if (isActive)
        {
            Off();
        }
        else
        {
            On();
        }
    }

    #endregion
}
