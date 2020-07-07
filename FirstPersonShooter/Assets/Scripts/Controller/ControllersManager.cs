using UnityEngine;


public class ControllersManager
{
    #region Fields

    private GameModel _model;
    private PlayerController _playerController;

    #endregion


    #region ClassLifeCycles

    public ControllersManager(GameModel model)
    {
        _model = model;
        SetControllers();
    }

    #endregion


    #region Methods

    public void SetControllers()
    {
        if (_playerController == null)
        {
            _playerController = new PlayerController(_model.Player);
        }
    }

    #endregion
}
