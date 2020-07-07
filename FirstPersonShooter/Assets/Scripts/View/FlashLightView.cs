using UnityEngine;


public class FlashLightView : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform _transform;
    [SerializeField] private Light _light;

    #endregion


    #region Methods

    public void SetIntensety(float value)
    {
        _light.intensity = value;
    }

    public void SetEnable()
    {
        _light.enabled = true;
    }

    public void SetDisable()
    {
        _light.enabled = false;
    }

    public void Blinking()
    {
        _light.enabled = Random.Range(0, 100) >= Random.Range(0, 10);
    }

    #endregion
}
