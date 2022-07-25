using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    private BallController ballController;

    private void Awake() => ballController = GetComponent<BallController>();


    #region  OnCollisionEnter
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Instance.PlaySound(AudioTypes.Pop);
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
        if (!ballController.IsActive) ballController.IsActive = true;

        var currentSpeedOfStick = GameManager.Instance.GetStickCurrentSpeed();
        var forceFactorAccordingToSpeed = Mathf.Clamp(currentSpeedOfStick, 0.5f, 1);
        var finalForce = stick.contacts[0].normal * forceFactorAccordingToSpeed * 40;

        ballController.Rigidbody.AddForce(finalForce, ForceMode2D.Impulse);

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
        GameManager.Instance.PlaySound(AudioTypes.Lose);
        GameManager.Instance.PushPanel(LobbyPanels.GameOver);
    }

    void OnTriggerCoin(Collider2D coin)
    {
        GameManager.Instance.PlaySound(AudioTypes.Click);
        coin.gameObject.SetActive(false);
        DataPack.UserData.AddCoin();
    }
    #endregion
}
