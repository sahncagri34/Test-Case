using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : BaseMoveableController
{
    [SerializeField] Camera mainCamera;

    private void LateUpdate() => Follow();

    public Vector3 GetCameraScreenToWorldPoint(Vector3 point)
    {
       return mainCamera.ScreenToWorldPoint(point);
    }

}
