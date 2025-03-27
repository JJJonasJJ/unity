using System;
using Unity.VisualScripting;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    InputManager m_InputManager;
    Camera m_MainCamera;

    [SerializeField] PieceFallDetector pfd;

    public GameObject GameObject => gameObject;

    public ISelectable CurrentSelection { get; private set; }

    void Awake()
    {
        m_InputManager = InputManager.Instance;
        m_MainCamera = Camera.main;
    }

    void Update()
    {
        if (m_InputManager != null) { 
            if (m_InputManager.IsSingleMainInput())
            {
                HandleSelection(m_InputManager.GetSingleMainInputPosition());
            }
        }
    }
    void HandleSelection(Vector3 screenPosition)
    {
    
        var selectable = GetSelectable(screenPosition);

        if ((CurrentSelection != null) && (CurrentSelection != selectable) && (pfd.GameOver != true))
        {
            CurrentSelection.Deselect();

        }

        if (pfd.GameOver != true)
        {
            selectable?.Select();
            CurrentSelection = selectable;
        }
    }

    ISelectable GetSelectable(Vector3 screenPosition)
    {
        var ray = m_MainCamera.ScreenPointToRay(screenPosition);

        if (!Physics.Raycast(ray, out var hit) || hit.transform == null)
        {
            return null;
        }

        var gameObject = hit.transform.gameObject;

        if (!gameObject.TryGetComponent<ISelectable>(out var selectable))
        {
            return null;
        }

        return selectable;
    }
}