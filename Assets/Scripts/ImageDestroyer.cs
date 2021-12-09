using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDestroyer : MonoBehaviour
{
    private float startY;
    private Quaternion initialRotation;

    void Start()
    {
        startY = transform.position.y;
        initialRotation = transform.rotation;
    }

    public void Update()
    {
        if (startY > GetPositionY())
            DestroySelf();
        transform.rotation = initialRotation;
    }

    public virtual float GetPositionY()
    {
        return transform.position.y;
    }

    public virtual void DestroySelf()
    {
        GameObject.Destroy(gameObject);
    }
}