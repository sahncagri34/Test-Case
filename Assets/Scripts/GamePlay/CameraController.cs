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
    public (float,float) GetMinMaxPositionsOfCamera()
    {
        return (transform.position.y-3,transform.position.y +3);
    }
}
