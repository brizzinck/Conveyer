using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Transform _endpoint;
    [SerializeField] private float _speed;

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, 
            _endpoint.position, _speed * Time.deltaTime);
    }
}
