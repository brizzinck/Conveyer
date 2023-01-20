using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFood : MonoBehaviour
{
    [SerializeField] private PickUpFood _pickUpFood;
    [SerializeField] private Food food;
    [SerializeField][Range(1.7f, 2f)] private float _minIterval;
    [SerializeField][Range(2f, 4)] private float _maxIterval;
    private List<Food> _foodList = new List<Food>();
    private float _currentTimeToSpawn = 0;
    private void Start()
    {
        Spawn();     
    }
    private void Update()
    {
        CheckRemoveFood();
        Spawn();
    }

    private void CheckRemoveFood()
    {
        if (_foodList.Count > 0)
        {
            if (_foodList[0].transform.position.z <= 0)
            {
                Destroy(_foodList[0].gameObject);
                _foodList.RemoveAt(0);
            }
        }
    }

    private void Spawn()
    {
        if (_pickUpFood.IsPickUp) return;
        if (_currentTimeToSpawn <= 0)
        {
            Food newFood = Instantiate(food, transform.position, Quaternion.identity);
            _foodList.Add(newFood);
            SetNewInterwal();
        }
        else
            _currentTimeToSpawn -= Time.deltaTime;
    }

    private void SetNewInterwal()
    {
        _currentTimeToSpawn = Random.Range(_minIterval, _maxIterval);
    }
}
