using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFood : MonoBehaviour
{
    [SerializeField] private string _nameFood;
    private Collider _collider;
    private Rigidbody _rigidbody;

    public string NameFood { get => _nameFood; }

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
