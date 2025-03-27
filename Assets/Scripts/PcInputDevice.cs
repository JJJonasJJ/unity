using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInputDevice : IInputDevice
{
    public bool IsSingleMainInput()
    {
        return Input.GetMouseButtonUp(0);
    }

    public Vector3 GetMainInputPosition()
    {
        return Input.mousePosition;
    }
}
