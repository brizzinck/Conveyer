using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] static private Animator animator;
    public static void PickUp() => animator.SetTrigger("PickUp");
    public static void Finish() => animator.SetTrigger("Finish");
    private void Start() => animator = _animator;
}
