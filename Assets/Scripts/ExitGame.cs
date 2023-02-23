using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDestroy()
    {
        _exitButton.onClick.RemoveListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
