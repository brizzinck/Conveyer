using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    [SerializeField] private ConveyerBelt[] _conveyerBelts;
    [SerializeField] private PickUpFood _pickUpFood;
    private void Awake()
    {
        foreach (ConveyerBelt conveyerBelt in _conveyerBelts)
        {
            _pickUpFood.ActionsWithFood += conveyerBelt.SetSpeedConveyer;
        }
    }
}
