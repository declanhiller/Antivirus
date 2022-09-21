using System;
using UnityEditor;
using UnityEngine;

public class Settings : App {
    
    public static readonly string NAME = "SETTINGS";
    
    public override string GetName() {
        return Settings.NAME;
    }

    public override Type GetWindowType() {
        return typeof(SettingsWindow);
    }


    public override void Start() {
        
    }

    public override void PreStart() {
        
    }
}