using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotator : MonoBehaviour
{
    // Start is called before the first frame update
    public float DegreesPerSecond;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, DegreesPerSecond * Time.deltaTime, 0);
        transform.Rotate(rotation);
    }
}
