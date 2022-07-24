using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathController : MonoBehaviour
{
    [SerializeField] List<Transform> pathImageList;

    private void Start() => GameManager.Instance.OnHeightChanged += OnHeightChanged;
    private void OnDestroy() => GameManager.Instance.OnHeightChanged -= OnHeightChanged;

    
    private void OnHeightChanged(Vector3 finalPos)
    {
        var lastItem = pathImageList.Last();
        var firstItem = pathImageList.First();

        pathImageList.Remove(firstItem);


        firstItem.position = new Vector3(lastItem.position.x, lastItem.position.y + 5, lastItem.position.z);
        pathImageList.Add(firstItem);
    }
}
