using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDestroyer : MonoBehaviour
{
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    public void Update()
    {
        if (startY > GetPositionY())
            DestroySelf();
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