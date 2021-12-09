using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    bool gazedAt = false;
    float timer = 0.0f;
    [SerializeField]
    float actionTime;

    void Start()
    {
    }

    void Update()
    {
        if (gazedAt) timer += Time.deltaTime;
        if (timer > actionTime)
        {
            Debug.Log("Olhou por tanto tempo");
        }
    }

    public void OnPointerEnter()
    {
        gazedAt = true;
        timer = 0.0f;
        Material mats = gameObject.GetComponent<Renderer>().material;
        mats.SetColor("_Color", new Color(1.0f, 0.0f, 0.0f, 1.0f));
        Debug.Log("Olhou pra mim");
    }

    public void OnPointerExit()
    {
        gazedAt = false;
        timer = 0.0f;
    }
}
