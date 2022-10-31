using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desktop : MonoBehaviour {
    
    
    private Texture2D background;
    private AppToolbar toolbar;
    public static Desktop INSTANCE;

    private void Start()
    {
        INSTANCE = this;
    }

    public void Init() {
        toolbar = GameObject.FindGameObjectWithTag("AppToolbar").GetComponent<AppToolbar>();
    }

    public void InstantiateIconOnToolbar(App app) {
        toolbar.InstantiateIcon(app);
    }
    
}