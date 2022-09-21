using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class App {

    public Texture2D iconTexture;

    public abstract string GetName();
    public abstract Type GetWindowType();
    
    

    public void Init() {
        PreStart();
        LoadIconTexture();
        CreateOrGetWindowPrefab(GetWindowType());
        Start();
    }

    public abstract void Start();

    public abstract void PreStart();
    
    public Texture2D GetIconTexture() {
        return iconTexture;
    }
    

    public void Open() {
        Window window = CreateOrGetWindowPrefab(GetWindowType());
        window.Display();
    }
    
    public void LoadIconTexture() {
        Object resource = Resources.Load("Icons/" + GetName());
        iconTexture = resource as Texture2D;
    }

    public Window CreateOrGetWindowPrefab(Type type) {
        if (!type.IsAssignableFrom(typeof(Window))) {
            throw new ArgumentException("Type " + type.Name + " isn't extended from Window class");
        }
        GameObject obj = new GameObject(GetName(), type);
        PrefabUtility.SaveAsPrefabAsset(obj, "Assets/WindowPrefabs/" + GetName() + ".prefab");
        return obj.GetComponent(type) as Window;
    }
}