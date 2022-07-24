using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [Header("REFERENCES")]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private SticksController sticksController;

    public Action<Vector3> OnHeightChanged;

    private void Awake() => Initialize();

    private void Initialize()
    {
        _instance = this;
    }

    public Vector3 GetCameraScreenToWorldPoint(Vector3 point)
    {
        return cameraController.GetCameraScreenToWorldPoint(point);
    }
    public float GetStickCurrentSpeed()
    {
        return sticksController.GetCurrentSpeed();
    }
}
