using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoveableController : MonoBehaviour
{
    [SerializeField] protected float followSpeed = 3f;

    protected bool isMoveActive;
    protected Vector3 finalPos;

    private void Start() => EventHandler.HeightChanged += OnHeightChange;

    private void OnDestroy() => EventHandler.HeightChanged -= OnHeightChange;

    void OnHeightChange(Vector3 finalPos)
    {
        isMoveActive = true;
        this.finalPos = finalPos;
    }
    protected void Follow()
    {
        var cameraPos = transform.position;
        var targetPos = finalPos;

        if (cameraPos.y < targetPos.y)
        {
            cameraPos.y = Mathf.Lerp(cameraPos.y, targetPos.y, followSpeed * Time.deltaTime);
            transform.position = cameraPos;
        }
        else
            isMoveActive = false;
    }
}
