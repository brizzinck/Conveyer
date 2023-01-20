using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool IsPick = false;
    [SerializeField] private PickFood[] _pickFoods;
    private PickFood _pickFood;
    public PickFood PickFood { get => _pickFood; }

    private void Start()
    {
        _pickFood = Instantiate(_pickFoods[Random.Range(0, _pickFoods.Length)], 
            transform.position, Quaternion.identity, transform);
    }
}
