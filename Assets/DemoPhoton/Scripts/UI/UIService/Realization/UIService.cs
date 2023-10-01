using System;
using System.Collections.Generic;
using DemoPhoton.Scripts;
using DemoPhoton.Scripts.UI.UIWindow;
using UnityEngine;
using Object = UnityEngine.Object;

public class UIService : IUIService
{
    private Transform _deactivatedContainer;
        
    private readonly UIRoot _uIRoot;
    private readonly Dictionary<Type,UIWindow> _viewStorage = new Dictionary<Type,UIWindow>();
    private readonly Dictionary<Type, GameObject> _initWindows= new Dictionary<Type, GameObject>();
        
    public UIService(string UISource)
    {
        _uIRoot = Resources.Load<UIRoot>("UIRoot");
        _uIRoot = Object.Instantiate(_uIRoot);

        LoadWindows(UISource);
        InitWindows(_uIRoot.DeactivateContainer);
    }

    public T Show<T>() where T : UIWindow
    {
        var window = Get<T>();
        if(window != null)
        {
            window.transform.SetParent(_uIRoot.ActivateContainer, false);
                
            window.Show();
            return window;
        }
        return null;
    }
        
    public T Get<T>() where T : UIWindow
    {
        var type = typeof(T);
        if (_initWindows.ContainsKey(type))
        {
            var view = _initWindows[type];            
            return view.GetComponent<T>();
        }
        return null;
    }

    public void Hide<T>() where T : UIWindow
    {
        var window = Get<T>();
            
        if(window!=null)
        {
            window.transform.SetParent(_uIRoot.DeactivateContainer, false);
            window.Hide();
        }
    }

    public void InitWindows(Transform poolDeactiveContiner)
    {
        _deactivatedContainer = poolDeactiveContiner == null ? _uIRoot.DeactivateContainer : poolDeactiveContiner;
        foreach (var windowKVP in _viewStorage)
        {
            Init(windowKVP.Key, _deactivatedContainer);
        }
    }

    public void LoadWindows(string source)
    {
        var windows = Resources.LoadAll(source, typeof(UIWindow));

        foreach (var window in windows)
        {
            var windowType = window.GetType();

            _viewStorage.Add(windowType, (UIWindow)window);
        }
    }

    private void Init(Type t, Transform parent = null)
    {
        if(_viewStorage.ContainsKey(t))
        {
            GameObject view = null;
            if(parent!=null)
            {
                view = Object.Instantiate(_viewStorage[t].gameObject, parent);
            }
            else
            {
                view = Object.Instantiate(_viewStorage[t].gameObject);
            }

            var uiWindow = view.GetComponent<UIWindow>();
            uiWindow.UIService = this;
                
            _initWindows.Add(t, view);
        }
    }
}