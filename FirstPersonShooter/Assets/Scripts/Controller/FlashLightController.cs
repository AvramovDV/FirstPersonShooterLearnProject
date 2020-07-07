using UnityEngine;


public class FlashLightController : BaseController
{
    #region Fields

    private FlashLightModel _model;
    private FlashLightView _view;
    private FlashLightUIView _viewUI;

    #endregion


    #region ClassLifeCycles

    public FlashLightController(FlashLightModel model)
    {
        _model = model;

        SetView(Camera.main.transform);

        _view.SetDisable();
        _viewUI.gameObject.SetActive(isActive);

    }

    #endregion


    #region Methods

    public override void Off()
    {
        base.Off();
        //ServiceLocatorMonoBehaviour.GetService<GameController>().OnUpdate -= MainLogic;
        ServiceLocatorMonoBehaviour.GetService<GameController>().OnUpdate -= LoseEnergy;
        ServiceLocatorMonoBehaviour.GetService<GameController>().OnUpdate += GrowEnergy;
        _view.SetDisable();
        _viewUI.gameObject.SetActive(false);
    }

    public override void On()
    {
        base.On();
        //ServiceLocatorMonoBehaviour.GetService<GameController>().OnUpdate += MainLogic;
        ServiceLocatorMonoBehaviour.GetService<GameController>().OnUpdate -= GrowEnergy;
        ServiceLocatorMonoBehaviour.GetService<GameController>().OnUpdate += LoseEnergy;
        _view.SetEnable();
        _viewUI.gameObject.SetActive(true);
    }

    public override void Switch()
    {
        base.Switch();
    }

    //public void SwitchLight()
    //{
    //    if (_model.IsActive)
    //    {
    //        _view.SetDisable();
    //        _viewUI.gameObject.SetActive(false);
    //    }
    //    else if(_model.BatteryCurrentEnergy > 0f)
    //    {
    //        _view.SetEnable();
    //        _viewUI.gameObject.SetActive(true);
    //    }
    //}

    private void SetView(Transform parent)
    {
        GameObject _prefubRef = Resources.Load<GameObject>(StaticData.FlashlightPrefubPath);
        _view = ServiceLocatorMonoBehaviour.GetService<GameController>().GetView(_prefubRef, Vector3.zero, parent).GetComponent<FlashLightView>();

        _prefubRef = Resources.Load<GameObject>(StaticData.FlashlightUITextPrefubPath);
        Canvas canvas = ServiceLocatorMonoBehaviour.GetService<Canvas>();
        _viewUI = ServiceLocatorMonoBehaviour.GetService<GameController>().GetView(_prefubRef, Vector3.zero, canvas.transform).GetComponent<FlashLightUIView>();
    }

    //private void MainLogic()
    //{
    //    if (_model.IsActive)
    //    {
    //        LoseEnergy();
    //    }
    //    else
    //    {
    //        GrowEnergy();
    //    }
    //}

    private void LoseEnergy()
    {
        _model.BatteryCurrentEnergy -= _model.LoseEnergySpeed * Time.deltaTime;
        if (_model.BatteryCurrentEnergy <= 0)
        {
            Off();
        }
        SetIntensety();
    }

    private void GrowEnergy()
    {
        if (_model.BatteryCurrentEnergy >= _model.BatteryMaxEnergy)
        {
            return;
        }
        _model.BatteryCurrentEnergy += _model.LoseEnergySpeed * Time.deltaTime;
        SetIntensety();
    }

    private void SetIntensety()
    {
        float intensety = _model.Intensety * (_model.BatteryCurrentEnergy / _model.BatteryMaxEnergy);

        if(intensety <= _model.BlinkThreshold)
        {
            _view.Blinking();
        }

        _view.SetIntensety(intensety);

        _viewUI.SetEnergy(_model.BatteryCurrentEnergy / _model.BatteryMaxEnergy * 100f);
    }

    #endregion
}
