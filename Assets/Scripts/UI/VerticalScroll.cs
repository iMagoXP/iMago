using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class VerticalScroll : MonoBehaviour, IDragHandler
{
    public float scrollSpeed = 0.0f;
    public float maxHeight = 0.0f;
    public float minHeight = 0.0f;
    public void OnDrag(PointerEventData eventData)
    {
        float newPositionY = gameObject.transform.localPosition.y + eventData.delta.y*scrollSpeed;
        if(newPositionY > minHeight && newPositionY < maxHeight)
            gameObject.transform.localPosition += new Vector3(0.0f, eventData.delta.y*scrollSpeed, 0.0f);
        Debug.Log(gameObject.transform.localPosition.y);
    }

}