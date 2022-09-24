using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Maximize : MonoBehaviour, IPointerClickHandler
{
    private Window window;
    
    private void Start()
    {
        Transform windowGameObj = null;
        while (windowGameObj is null || !windowGameObj.CompareTag("window"))
        {
            windowGameObj = windowGameObj == null ? transform.parent : windowGameObj.transform;
        }

        window = windowGameObj.GetComponent<Window>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        window.Maximize();
    }
}
