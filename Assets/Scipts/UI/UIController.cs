using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _start;
    private void Start()
    {
        _start.onClick.AddListener(Starting);
    }
    private void Starting()
    {

        _start.gameObject.SetActive(false);
    }
}
