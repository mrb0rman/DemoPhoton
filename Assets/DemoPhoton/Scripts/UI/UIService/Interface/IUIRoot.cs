using UnityEngine;

public interface IUIRoot
{
    Transform ActivateContainer { get; }
    Transform DeactivateContainer { get; }
}
