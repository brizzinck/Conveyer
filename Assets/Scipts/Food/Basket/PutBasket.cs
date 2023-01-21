using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBasket : MonoBehaviour
{
    [SerializeField] private BasketFood _basketFood;
    public void PutBasked()
    {
        _basketFood.transform.parent = null;
        _basketFood.transform.eulerAngles = Vector3.zero;
        _basketFood.transform.position = new Vector3(_basketFood.transform.position.x, 
            0.2f, _basketFood.transform.position.z);
    }
}
