using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputDevice
{
    bool IsSingleMainInput();
    Vector3 GetMainInputPosition();

}
