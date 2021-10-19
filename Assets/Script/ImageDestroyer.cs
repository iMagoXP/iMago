using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDestroyer : MonoBehaviour
{
    private Quaternion initialRotation;
    private bool falling;

    // Start is called before the first frame update
    void Start()
    {
        falling = false;
        initialRotation = transform.parent.gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion curRotation = transform.parent.gameObject.transform.rotation;
        float angle = Quaternion.Angle(initialRotation, curRotation);

        if (angle >= 175.0f)
            falling = true;

        if (falling && angle <= 45.0f)
            GameObject.Destroy(gameObject);
    }
}