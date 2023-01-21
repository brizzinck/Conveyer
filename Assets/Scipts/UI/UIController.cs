using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _restartButton;
    private void Start()
    {
        _restart.onClick.AddListener(ReStarting);
        _restartButton.onClick.AddListener(ReStarting);
    }
    private void ReStarting()
    {
        SceneManager.LoadScene(0);
    }
}
