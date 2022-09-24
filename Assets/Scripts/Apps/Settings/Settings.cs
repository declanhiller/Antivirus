using System;
using UnityEditor;
using UnityEngine;


public class Settings : App {
    
    public static readonly string NAME = "SETTINGS";


    public Settings()
    {
        iconTexture = Resources.Load<Texture2D>("Icons/" + NAME);
    }

    public override string GetName() {
        return Settings.NAME;
    }

    public override Type GetWindowContent()
    {
        return typeof(SettingsWindow);
    }
    


    public override void Start() {
        
    }

    public override void PreStart() {
        
    }
}