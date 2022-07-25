using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathController : MonoBehaviour
{
    [SerializeField] List<Transform> pathImageList;
    [SerializeField] List<Transform> coinList;

    private void Start() => EventHandler.HeightChanged += HeightChanged;
    private void OnDestroy() => EventHandler.HeightChanged -= HeightChanged;

    
    private void HeightChanged(Vector3 finalPos)
    {
        ManagePath();
        ManageCoinPath();
    }


    private void ManagePath()
    {
        var lastItem = pathImageList.Last();
        var firstItem = pathImageList.First();

        pathImageList.Remove(firstItem);


        firstItem.position = new Vector3(lastItem.position.x, lastItem.position.y + 5, lastItem.position.z);
        pathImageList.Add(firstItem);
    }

    private void ManageCoinPath()
    {
        var lastItem = coinList.Last();
        var firstItem = coinList.First();

        coinList.Remove(firstItem);


        firstItem.position = new Vector3(lastItem.position.x, lastItem.position.y + 5, lastItem.position.z);
        firstItem.gameObject.SetActive(true);
        coinList.Add(firstItem);
    }
}
