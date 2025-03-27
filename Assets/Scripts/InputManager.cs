using System;
using UnityEngine;

public class InputManager
{
    static InputManager s_Instance;
    IInputDevice m_InputDevice;

    public static InputManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = new InputManager();
            }

            return s_Instance;
        }
    }

    public bool IsSingleMainInput()
    {
        return m_InputDevice.IsSingleMainInput();
    }

    public Vector3 GetSingleMainInputPosition()
    {
        return m_InputDevice.GetMainInputPosition();
    }

    protected InputManager()
    {
        if (s_Instance != null)
        {
            throw new Exception("InputManager singleton already instantiated!");
        }

        m_InputDevice = InputDeviceFactory.Instance.Create();
    }
}