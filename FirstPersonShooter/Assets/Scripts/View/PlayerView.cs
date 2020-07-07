using UnityEngine;


public class PlayerView : MonoBehaviour
{
    #region Fields

    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidBody;

    #endregion


    #region Propeties

    public Transform CameraTransform { get => _cameraTransform; }
    public bool IsGrounded { get => _characterController.isGrounded; }
    public Vector3 Forward { get => _transform.forward; }
    public Vector3 Right { get => _transform.right; }

    #endregion


    #region Methods

    public void SetPosition(Vector3 position)
    {
        _characterController.Move(position);
    }

    public void SetRotation(Vector3 rotation)
    {
        Vector3 delta = rotation;

        delta.x = Mathf.Clamp(delta.x, -90f, 90f);

        _transform.localRotation *= Quaternion.Euler(0f, delta.y, 0f);
        _cameraTransform.localRotation *= Quaternion.Euler(-delta.x, 0f, 0f);
    }

    #endregion
}
