using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] static private Animator animator;
    public static void TurnToObject(Transform turnObject, Vector3 objectPostion, float speed = 10)
    {
        Vector3 direction = objectPostion - turnObject.position;
        turnObject.rotation = Quaternion.Slerp(turnObject.rotation,
            Quaternion.LookRotation(direction), Time.deltaTime * speed);
        turnObject.rotation = new Quaternion(0, turnObject.rotation.y, 0, turnObject.rotation.w);
    }
    public static void PickUp() => animator.SetTrigger("PickUp");
    public static void Finish() => animator.SetTrigger("Finish");
    public static void Lost() => animator.SetTrigger("Lost");
    private void Start() => animator = _animator;
}
