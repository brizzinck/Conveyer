using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFood : MonoBehaviour
{
    private Collider _collider;
    private Rigidbody _rigidbody;
    public void FreeGravity()
    {
        _collider.isTrigger = false;
        _rigidbody.isKinematic = false;
    }
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }
}
