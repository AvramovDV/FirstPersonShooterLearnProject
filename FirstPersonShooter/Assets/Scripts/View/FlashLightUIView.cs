using UnityEngine;
using UnityEngine.UI;


public class FlashLightUIView : MonoBehaviour
{
    #region Fialds

    [SerializeField] private Text _energyText;

    #endregion


    #region Methods

    public void SetEnergy(float energy)
    {
        _energyText.text = $"{energy.ToString("F1")}";
    }

    #endregion
}
