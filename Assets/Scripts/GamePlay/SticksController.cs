using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SticksController : MonoBehaviour
{
    private RaycastHit2D hitInfo;

    private bool isPressing;
    private bool isGameActive;

    private Vector3 previousPos;
    private Vector3 newPos;

    private void Start()
    {
        EventHandler.GameStatusToggled += OnGameStatusToggled;
    }

    private void OnDestroy()
    {
        EventHandler.GameStatusToggled -= OnGameStatusToggled;
    }

    private void Update()
    {
        if (!isGameActive) return;

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 origin = GameManager.Instance.GetCameraScreenToWorldPoint(Input.mousePosition);
            hitInfo = Physics2D.Raycast(origin, Vector2.zero);

            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.tag == Variables.STICK_TAG)
                {
                    isPressing = true;
                    previousPos = origin;
                    newPos = previousPos;
                }
            }

        }

        if(Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        if (isPressing)
        {
            MoveSticks();
        }

    }

    private void Reset()
    {
        isPressing = false;
        previousPos = Vector3.zero;
        newPos = Vector3.zero;
    }

    private void MoveSticks()
    {
        var deltaPosition = newPos.y -  previousPos.y;
        newPos = hitInfo.transform.position;
        if(MathF.Abs(deltaPosition) >= Variables.DELTA_POSITION_TO_RESET) 
        {
            previousPos = newPos;
        }
        
        MoveStick(hitInfo.transform);
    }
    void MoveStick(Transform stick)
    {
        Vector3 mousePosition = GameManager.Instance.GetCameraScreenToWorldPoint(Input.mousePosition);
        Vector3 move = new Vector3(stick.position.x, mousePosition.y, stick.position.z);

        stick.position = move;
    }
    public float GetCurrentSpeed()
    {
        return (newPos- previousPos).y;
    }


    private void OnGameStatusToggled(bool isGameActive)
    {
        this.isGameActive = isGameActive;
    }

}
