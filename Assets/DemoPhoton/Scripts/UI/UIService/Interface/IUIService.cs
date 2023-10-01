using System;
using DemoPhoton.Scripts.UI.UIWindow;
using UnityEngine;

public interface IUIService
{
    T Show<T>() where T : UIWindow;
    void Hide<T>() where T : UIWindow;
    T Get<T>() where T : UIWindow;

    void InitWindows(Transform poolDeactiveContiner);
    void LoadWindows(string source);
}