using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ColliderCaster : MonoBehaviour {

    private RectTransform rectTransform;
    //collider that is tied with UI element
    private BoxCollider2D collider;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        if (collider == null) {
            collider = GenerateColliderObject();
        }

        
        
        // Vector3 transformPoint = rectTransform.TransformPoint(new Vector3());

        Vector3 screenToWorldPoint = rectTransform.transform.position;
        collider.transform.position = screenToWorldPoint;

        collider.size = GetWidth();

    }

    private BoxCollider2D GenerateColliderObject() {
        GameObject obj = new GameObject();
        obj.name = this.gameObject.name + "Collider";
        return obj.AddComponent<BoxCollider2D>();
    }

    private Vector2 GetWidth() {
        Vector3[] arr = new Vector3[4];
        rectTransform.GetWorldCorners(arr);
        Vector3 vector1 = arr[0];
        Vector3 vector2 = arr[2];
        return new Vector2(Math.Abs(vector2.x - vector1.x), Math.Abs(vector2.y - vector1.y));
    }

}
