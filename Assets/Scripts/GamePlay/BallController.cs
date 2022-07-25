using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] SpriteRenderer ballImage;

    public bool isActive = false;
    public bool isGameStarted = false;

    private int previousYTrigger;
    private int newYTrigger;

    

    private void Start()
    {
        EventHandler.GameStatusToggled += OnGameStatusToggled;
        EventHandler.ItemEquipped += OnItemEquipped;
    }

    private void OnDestroy()
    {
        EventHandler.GameStatusToggled -= OnGameStatusToggled;
        EventHandler.ItemEquipped -= OnItemEquipped;
    }

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
            EventHandler.HeightChanged?.Invoke(transform.position);
        }

        GameManager.Instance.UpdateMeter(transform.position.y);
    }

    private void OnGameStatusToggled(bool isActive)
    {
        rigidbody.simulated = isActive;
        isGameStarted = isActive;
    }


    private void OnItemEquipped()
    {
        ballImage.color = DataPack.UserData.EquippedItem.Color.ToColor();
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
            case Variables.COIN:
                OnTriggerCoin(other);
                break;
        }
    }

    void OnTriggerDownWall(Collider2D upWall)
    {
        GameManager.Instance.PushPanel(LobbyPanels.GameOver);
    }

    void OnTriggerCoin(Collider2D coin)
    {
        coin.gameObject.SetActive(false);
        DataPack.UserData.AddCoin();
    }

    #endregion
}