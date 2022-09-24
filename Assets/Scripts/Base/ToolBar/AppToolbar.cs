using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

[RequireComponent(typeof(RectTransform))]
public class AppToolbar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{


    private RectTransform rectTransform;
    private List<Vector2> spaces = new List<Vector2>();
    private List<GameObject> iconSpaces = new List<GameObject>();
    private Vector2 sizeOfSpace;
    private List<Vector2> worldSpace = new List<Vector2>();
    private bool isHovering = false;
    private KeybindManager _keybindManager;

    // Start is called before the first frame update
    void Start() {
        _keybindManager = new KeybindManager();
        _keybindManager.Enable();
        rectTransform = GetComponent<RectTransform>();
        CalculateSpots();
        InstantiateAllSpaces();
    }

    private void InstantiateAllSpaces() {
        int counter = 0;
        foreach (Vector2 space in spaces) {
            counter++;
            GameObject gameObj = new GameObject("IconContainer" + counter, typeof(RectTransform), typeof(Image), typeof(IconHolder));
            gameObj.transform.SetParent(transform, false);
            gameObj.transform.localScale = new Vector3(1, 1, 1);
            gameObj.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
            gameObj.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
            gameObj.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
            gameObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(space.x, space.y, 0);
            gameObj.GetComponent<RectTransform>().sizeDelta = new Vector2(rectTransform.rect.height * 1.1f, rectTransform.rect.height);
            gameObj.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            iconSpaces.Add(gameObj);
        }
    }

    public void InstantiateIcon(App app) {
        GameObject iconSpace = iconSpaces[0];
        iconSpace.GetComponent<IconHolder>().isOccupied = true;
        iconSpace.GetComponent<IconHolder>().SetAppFunc(app.Open);
        GameObject icon = new GameObject(app.GetName(), typeof(RectTransform), typeof(Image));
        icon.transform.SetParent(iconSpace.transform);
        Texture2D texture = app.iconTexture;
        icon.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        icon.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        icon.GetComponent<RectTransform>().sizeDelta = new Vector2(40f, 40f);
        icon.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        // if (isHovering) {
        //     Vector2 readValue = _keybindManager.UI.Point.ReadValue<Vector2>();
        //     
        // }
    }
    
    void CalculateSpots() {
        float rectWidth = rectTransform.rect.width;
        float widthOfSpace = rectTransform.rect.height;

        sizeOfSpace = new Vector2(widthOfSpace * 1.1f, widthOfSpace);
        
        Vector2 tempTransform = new Vector2(widthOfSpace/4, 0);
        int counter = 0;
        int limit = 50;
        while (tempTransform.x <= rectWidth - widthOfSpace) {
            spaces.Add(new Vector2(tempTransform.x, tempTransform.y));
            tempTransform.x += widthOfSpace * 1.1f;
            Debug.Log(tempTransform);
            counter++;
            if (counter >= 50)
            {
                break;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHovering = false;
    }
}
