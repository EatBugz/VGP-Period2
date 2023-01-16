using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // vars
    [HideInInspector] public Transform parent;
    private Canvas canvas;
    private Image image;

    // get stuff
    void Awake() { 
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Begin drag");
        // hierarchy stuff
        parent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        // turn of raycasting
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, Input.mousePosition, canvas.worldCamera, out position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End drag");
        // set the parent
        transform.SetParent(parent);

        // turn on raycasting
        image.raycastTarget = true;
    }
}
