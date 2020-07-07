using UnityEngine;


public class PlayerController : BaseController
{
    #region Fields

    private PlayerModel _playerModel;
    private PlayerView _playerView;

    private FlashLightController _flashLightController;

    private Vector2 _input;
    private Vector3 _movement;
    private float _gravityForce;

    #endregion


    #region ClassLifeCycles

    public PlayerController(PlayerModel model)
    {
        _playerModel = model;

        SetView();

        Cursor.lockState = CursorLockMode.Locked;

        _flashLightController = new FlashLightController(_playerModel.FlashLight);

        On();
    }

    #endregion


    #region Methods

    public override void Off()
    {
        base.Off();
        ServiceLocatorMonoBehaviour.GetService<GameController>().OnUpdate -= MainLogic;
    }

    public override void On()
    {
        base.On();
        ServiceLocatorMonoBehaviour.GetService<GameController>().OnUpdate += MainLogic;
    }

    public override void Switch()
    {
        base.Switch();
    }

    private void SetView()
    {
        GameObject prefubRef = Resources.Load<GameObject>(StaticData.PlayerPrefubPath);
        _playerView = ServiceLocatorMonoBehaviour.GetService<GameController>().GetView(prefubRef, _playerModel.Position, null).GetComponent<PlayerView>();
    }

    private void MainLogic()
    {
        Move();
        GamingGravity();
        Rotation();
        FlashLight();
    }

    private void Move()
    {
        if (_playerView.IsGrounded)
        {
            _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 desiredMove = _playerView.Forward * _input.y + _playerView.Right * _input.x;

            _movement.x = desiredMove.x * _playerModel.Speed;
            _movement.z = desiredMove.z * _playerModel.Speed;
        }

        _movement.y = _gravityForce;
        
        _playerView.SetPosition(_movement * Time.deltaTime);
        _playerModel.Position = _playerView.transform.position;
    }

    private void GamingGravity()
    {
        if (!_playerView.IsGrounded) _gravityForce -= _playerModel.Mass * Time.deltaTime;
        else _gravityForce = -1;
        if (Input.GetKeyDown(KeyCode.Space) && _playerView.IsGrounded) _gravityForce = _playerModel.Jump;
    }

    private void Rotation()
    {
        float rotX = Input.GetAxis("Mouse X") * _playerModel.RotationSpeed;
        float rotY = Input.GetAxis("Mouse Y") * _playerModel.RotationSpeed;

        Vector3 rotation = new Vector3(rotY, rotX, 0f);

        _playerView.SetRotation(rotation);
        _playerModel.Rotation = _playerView.transform.rotation.eulerAngles;
    }

    private void FlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _flashLightController.Switch();
        }
    }

    #endregion
}
