using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketFood : MonoBehaviour
{
    public void PutFood(Food food)
    {
        food.PickFood.transform.parent = transform;
        food.PickFood.transform.localPosition = Vector3.zero;
        food.PickFood.transform.rotation = Quaternion.identity;
    }
}
