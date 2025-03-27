using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public interface ISelectable
    {
        GameObject GameObject { get; }
        void Select();
        void Deselect();
    }