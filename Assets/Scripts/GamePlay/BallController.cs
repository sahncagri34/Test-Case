using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] SpriteRenderer ballImage;
    public Rigidbody2D Rigidbody;

    private int previousYTrigger;
    private int newYTrigger;

    public bool IsActive = false;
    private bool IsGameStarted = false;

    
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
        if(!IsGameStarted) return;
        if (!IsActive) return;

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
        Rigidbody.simulated = isActive;
        IsGameStarted = isActive;
    }


    private void OnItemEquipped()
    {
        ballImage.color = DataPack.UserData.EquippedItem.Color.ToColor();
    }

}