using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static Action<Vector3> HeightChanged;
    public static Action<bool> GameStatusToggled;
}
