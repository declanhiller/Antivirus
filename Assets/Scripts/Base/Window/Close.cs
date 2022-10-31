using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Close : MonoBehaviour, IPointerClickHandler
{
    private Window window;
    private int limit = 10;
    
    private void Start()
    {
        Transform windowGameObj = null;

        int counter = 0;
        while (windowGameObj is null || !windowGameObj.CompareTag("Window"))
        {
            windowGameObj = windowGameObj == null ? transform.parent : windowGameObj.transform.parent;
            counter++;
            if (counter >= limit)
            {
                break;
            }
        }

        window = windowGameObj.GetComponent<Window>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        window.Close();
    }
}
