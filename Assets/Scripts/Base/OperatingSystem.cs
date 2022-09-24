using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class OperatingSystem : MonoBehaviour{
    
    private Dictionary<String, App> apps = new Dictionary<string, App>();
    private Desktop desktop;


    public void Awake() {
        desktop = GameObject.FindGameObjectWithTag("Desktop").GetComponent<Desktop>();
        desktop.Init();
        Settings settings = new Settings();
        settings.Init();
        apps.Add(Settings.NAME, settings);

        // StartAllApps();
    }

    public void Start()
    {
        desktop.InstantiateIconOnToolbar(apps[Settings.NAME]);
    }

}