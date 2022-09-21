using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class OperatingSystem : MonoBehaviour{
    
    private Dictionary<String, Type> apps = new Dictionary<string, Type>();
    private Dictionary<String, App> runningApps = new Dictionary<string, App>();
    private Desktop desktop;


    public void Awake() {
        desktop = GameObject.FindGameObjectWithTag("Desktop").GetComponent<Desktop>();
        desktop.Init();

        apps.Add(Settings.NAME, typeof(Settings));
        

        // StartAllApps();
    }

    public void Start() {
        runningApps.Add(Settings.NAME, desktop.InstantiateIconOnToolbar(apps[Settings.NAME]));
    }
    


    public Type GetDownloadedApp(String name) {
        return apps[name];
    }
    
    
    
}