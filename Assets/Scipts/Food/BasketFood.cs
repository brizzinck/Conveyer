using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketFood : MonoBehaviour
{
    public void PutFood(PickFood food)
    {
        food.transform.parent = transform;
        food.transform.localPosition = Vector3.zero;
        food.transform.rotation = Quaternion.identity;
    }
}
