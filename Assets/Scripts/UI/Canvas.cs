using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Canvas : MonoBehaviour
{

    [NonSerialized] public Canvas instance;
    private List<Node> nodes = new List<Node>();
    private KeybindManager keybinds;

    private List<IPointerClick> clickableObjects = new List<IPointerClick>();

    private Vector2 mousePos;
    public Vector2 MousePos => mousePos;

    private void Awake()
    {
        keybinds = new KeybindManager();
        keybinds.Enable();
        

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Canvas");
        if (gameObjects.Length > 1) throw new Exception("You had more than one Canvas object");
        instance = this;
    }

    private void Update()
    {
        ReadMousePos();
    }


    public void AddNode(Node node)
    {
        
    }

    private void ReadMousePos()
    {
        mousePos = keybinds.UI.MousePos.ReadValue<Vector2>();
    }

    private void Click(InputAction.CallbackContext context)
    {
        foreach(IPointerClick clickableObj in clickableObjects)
        {
            Node node = (Node) clickableObj;
            if (node.IsPositionIsContained(mousePos))
            {
                clickableObj.OnClick(); //TODO: will need to do layer order stuff probably so there aren't multiple clicks happening
            }
        }
    }

}