using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class App {

    public Texture2D iconTexture;
    private static GameObject WINDOW_PREFAB;

    public abstract string GetName();

    public abstract Type GetWindowContent();
    
    public void Init()
    {
        WINDOW_PREFAB = Resources.Load<GameObject>("Window");
    }

    public abstract void Start();

    public abstract void PreStart();

    public Texture2D GetIconTexture() {
        return iconTexture;
    }


    public void Open()
    {
        GameObject window = Object.Instantiate(WINDOW_PREFAB, Desktop.INSTANCE.transform);
        for (int i = 0; i < window.transform.childCount; i++)
        {
            Transform transform = window.transform.GetChild(i);
            if (transform.CompareTag("Content"))
            {
                Component addComponent = transform.gameObject.AddComponent(GetWindowContent());
                window.GetComponent<Window>().content = addComponent as WindowContent;
                break;
            }
        }
    }

}