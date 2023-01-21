using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketFood : MonoBehaviour
{
    [SerializeField] private int _fullCount;
    private int _countFoodInBasket = 0;
    public void PutFood(PickFood food)
    {
        _countFoodInBasket++;
        food.transform.parent = transform;
        food.transform.localPosition = Vector3.zero;
        food.transform.rotation = Quaternion.identity;
        BasketFull();
    }
    private void BasketFull()
    {
        if (_fullCount == _countFoodInBasket)
            AnimationController.Lost();
    }
}
