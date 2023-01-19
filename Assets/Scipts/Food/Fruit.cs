using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private float _upPosition;
    public void SetTransform()
    {
        transform.position += new Vector3(0, _upPosition, 0);
        transform.eulerAngles = new Vector3(-90, 0, 0);
        transform.localScale = new Vector3(transform.localScale.x, 
            transform.localScale.y, transform.localScale.z / 2);
    }
}
