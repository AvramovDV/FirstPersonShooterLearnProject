public class GameModel
{
    #region Fields

    private PlayerModel _playerModel;

    #endregion


    #region Propeties

    public PlayerModel Player { get => _playerModel; }

    #endregion


    #region ClassLifeCycle

    public GameModel()
    {
        _playerModel = new PlayerModel();
    }

    #endregion


    #region Methods



    #endregion
}
