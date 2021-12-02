using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void OnPointerEnter()
    {
        Debug.Log("Ihh, ta me olhando pq?");
    }

    public void OnPointerExit()
    {
        Debug.Log("Paro de me olhar :(");
    }
}
