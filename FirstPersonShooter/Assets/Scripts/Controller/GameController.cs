using System;
using UnityEngine;


public class GameController : MonoBehaviour
{
    #region Fields

    public Action OnUpdate;

    private GameModel _gameModel;
    private ControllersManager _controllers;

    #endregion


    #region Propeties

    public GameModel Model { get => _gameModel; }

    #endregion


    #region UnityMethods

    private void Start()
    {
        _gameModel = new GameModel();
        _controllers = new ControllersManager(_gameModel);
    }

    private void Update()
    {
        if (OnUpdate != null)
        {
            OnUpdate.Invoke();
        }
    }

    #endregion


    #region Methods

    public GameObject GetView(GameObject prefub, Vector3 spawnPoint, Transform parent)
    {
        if (parent != null)
        {
            return Instantiate(prefub, parent);
        }
        else
        {
            return Instantiate(prefub, spawnPoint, prefub.transform.rotation);
        }
    }

    #endregion
}
