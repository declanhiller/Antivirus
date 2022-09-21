using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desktop : MonoBehaviour {
    
    
    private Texture2D background;
    private AppToolbar toolbar;

    

    public void Init() {
        toolbar = GameObject.FindGameObjectWithTag("AppToolbar").GetComponent<AppToolbar>();
    }

    public App InstantiateIconOnToolbar(Type appType) {
        if (!appType.IsAssignableFrom(typeof(App))) {
            throw new ArgumentException("Type " + appType.Name + " isn't extended from App class");
        }
        return toolbar.InstantiateIcon(appType);
    }
    
}