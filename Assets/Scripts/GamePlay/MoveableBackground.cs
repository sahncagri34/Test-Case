using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableBackground : BaseMoveableController
{
    private void Update()
    {
        if (!isMoveActive) return;

        Follow();
    }

}
