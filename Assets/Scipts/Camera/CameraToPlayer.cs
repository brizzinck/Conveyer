using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToPlayer : MonoBehaviour
{
    private static Transform _cameraTransform;
    public static void GoPlayer() =>_cameraTransform.DOMoveX(-0.25f, 1.6f);
    private void Start() => _cameraTransform = transform;
}
