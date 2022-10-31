using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TopBar : MonoBehaviour, IDragHandler, IBeginDragHandler
{

    private Canvas canvas;
    private Vector2 offset;
    
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = eventData.position;
        position.z = canvas.planeDistance;
        transform.parent.position = canvas.worldCamera.ScreenToWorldPoint(position) + (Vector3) offset;
        // transform.parent.position += (Vector3) eventData.delta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 position = eventData.position;
        position.z = canvas.planeDistance;
        Vector3 pointerPos = canvas.worldCamera.ScreenToWorldPoint(position);
        offset = transform.parent.position - pointerPos;
        //y isn't offsetting correctly
    }
}
