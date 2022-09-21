using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IconHolder : MonoBehaviour, IPointerEnterHandler,  IPointerExitHandler, IPointerClickHandler {
    
    private Image image;
    public bool isOccupied { get; set; }
    
    private Action appStarter;
    

    private void Start() {
        image = GetComponent<Image>();
    }


    public void OnPointerEnter(PointerEventData eventData) {
        if (isOccupied) {
            image.color = new Color(0, 0, 0, 0.2f);
        }
    }


    public void OnPointerExit(PointerEventData eventData) {
        image.color = new Color(0, 0, 0, 0);
    }


    public void OnPointerClick(PointerEventData eventData) {
        appStarter();
    }

    public void SetAppFunc(Action func) {
        appStarter = func;
    }
    
}