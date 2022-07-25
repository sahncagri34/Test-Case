using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathController : MonoBehaviour
{
    [SerializeField] List<Transform> pathBGList;
    [SerializeField] Transform target;

    private Queue<Transform> pathBGQueue;
    private Transform currentPath;

    private float distanceBtwPaths;
    private bool isActive;
    private int pathBGListCount;

    private void Awake() => Initialize();
    private void Start() => EventHandler.GameStatusToggled += OnGameStatusToggled;
    private void OnDestroy() => EventHandler.GameStatusToggled -= OnGameStatusToggled;

    private void Update()
    {
        if (!isActive) return;

        GeneratePath();
    }

    private void Initialize()
    {
        distanceBtwPaths = pathBGList[1].position.y - pathBGList[0].position.y;
        pathBGListCount = pathBGList.Count;

        pathBGQueue = new Queue<Transform>();
        for (int i = 0; i < pathBGListCount; i++)
        {
            pathBGQueue.Enqueue(pathBGList[i]);
        }

    }


    private void GeneratePath()
    {
        currentPath = pathBGQueue.Peek();
        if (target.position.y > (currentPath.position.y + distanceBtwPaths))
        {
            currentPath = pathBGQueue.Dequeue();
            currentPath.position += new Vector3(0, pathBGListCount * distanceBtwPaths, 0);
            pathBGQueue.Enqueue(currentPath);
        }
    }


    private void OnGameStatusToggled(bool isGameActive)
    {
        isActive = isGameActive;
    }
}
