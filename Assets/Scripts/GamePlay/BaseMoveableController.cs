using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoveableController : MonoBehaviour
{
    [SerializeField] protected float followSpeed = 3f;

    protected bool isMoveActive;
    protected Vector3 finalPos;

    private void Start() => GameManager.Instance.OnHeightChanged += OnHeightChange;

    private void OnDestroy() => GameManager.Instance.OnHeightChanged -= OnHeightChange;

    void OnHeightChange(Vector3 finalPos)
    {
        isMoveActive = true;
        this.finalPos = finalPos;
    }
    protected virtual void Follow()
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
