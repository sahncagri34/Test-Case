using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    public bool isActive = false;
    public bool isGameStarted = false;

    private int previousYTrigger;
    private int newYTrigger;

    private void Start() => GameManager.Instance.GameStatusToggled += OnGameStatusToggled;
    private void OnDestroy() => GameManager.Instance.GameStatusToggled -= OnGameStatusToggled;

    private void Update()
    {
        if(!isGameStarted) return;
        if (!isActive) return;

        CalculateHeightChanges();
    }

    private void CalculateHeightChanges()
    {
        newYTrigger = (int)transform.position.y / 4;
        if (newYTrigger > previousYTrigger)
        {
            previousYTrigger = newYTrigger;
            GameManager.Instance.HeightChanged.Invoke(transform.position);
        }
    }

    private void OnGameStatusToggled(bool isActive)
    {
        rigidbody.simulated = isActive;
        isGameStarted = isActive;
    }




    #region  OnCollisionEnter
    private void OnCollisionEnter2D(Collision2D other)
    {
        CompareCollisionTags(other);
    }
    private void CompareCollisionTags(Collision2D other)
    {
        switch (other.collider.tag)
        {
            case Variables.STICK_TAG:
                OnHitStick(other);
                break;
        }
    }
    void OnHitStick(Collision2D stick)
    {
        if (!isActive) isActive = true;

        var currentSpeedOfStick = GameManager.Instance.GetStickCurrentSpeed();
        var forceFactorAccordingToSpeed = Mathf.Clamp(currentSpeedOfStick, 0.5f, 1);
        var finalForce = stick.contacts[0].normal * forceFactorAccordingToSpeed * 40;

        rigidbody.AddForce(finalForce, ForceMode2D.Impulse);

    }
    #endregion

    #region  OnTriggerEnter


    private void OnTriggerEnter2D(Collider2D other)
    {
        CompareTriggerTags(other);
    }

    private void CompareTriggerTags(Collider2D other)
    {
        switch (other.tag)
        {
            case Variables.DOWN_WALL:
                OnTriggerDownWall(other);
                break;
        }
    }

    void OnTriggerDownWall(Collider2D upWall)
    {
        //Game OVER
    }
    #endregion
}