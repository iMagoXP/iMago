using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrouselRotator : MonoBehaviour
{
    // Start is called before the first frame update
    public float DegreesPerSecond;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, 0, DegreesPerSecond * Time.deltaTime);
        transform.Rotate(rotation);
    }
}
