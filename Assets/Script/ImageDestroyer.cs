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
        initialRotation = GetCurrentParentRotation();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion curRotation = GetCurrentParentRotation();
        float angle = Quaternion.Angle(initialRotation, curRotation);

        if (ShouldDestroy(angle))
            GameObject.Destroy(gameObject);
    }

    public Quaternion GetCurrentParentRotation()
    {
        return transform.parent.rotation;
    }

    public bool ShouldDestroy(float angle)
    {
        if (angle >= 175.0f)
            falling = true;

        return falling && angle <= 45.0f;
    }

    public bool TestingGetterFalling()
    {
        return falling;
    }
}