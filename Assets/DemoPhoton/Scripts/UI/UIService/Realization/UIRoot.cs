using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour, IUIRoot
{
    public Transform ActivateContainer => activateContainer;
    public Transform DeactivateContainer => deactivateContainer;
        
    [SerializeField] private Transform activateContainer;
    [SerializeField] private Transform deactivateContainer;
}
