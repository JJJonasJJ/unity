using System;
using UnityEngine;

public class InputDeviceFactory
{
    static InputDeviceFactory s_Instance;

    public static InputDeviceFactory Instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = new InputDeviceFactory();
            }

            return s_Instance;
        }
    }

    private InputDeviceFactory()
    {
        if (s_Instance != null)
        {
            throw new Exception("InputDeviceFactory singleton already instantiated!");
        }
    }
    public IInputDevice Create()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
                return new PcInputDevice();
        }

        return null;
    }
}