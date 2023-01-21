using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _restart;
    private void Start()
    {
        _restart.onClick.AddListener(ReStarting);
    }
    private void ReStarting()
    {
        SceneManager.LoadScene(0);
    }
}
