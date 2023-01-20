using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private GameObject _pickFood;

    public GameObject PickFood { get => _pickFood; }
}
