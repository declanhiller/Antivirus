using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    
    private KeybindManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = new KeybindManager();
        manager.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        TrackCursor();
    }

    public void Click(InputAction.CallbackContext context)
    {
        Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(transform.position);
        RaycastHit2D[] raycasts = Physics2D.RaycastAll(screenToWorldPoint, Vector2.zero);
        
    }

    public void TrackCursor()
    {
        
    }
    
}
