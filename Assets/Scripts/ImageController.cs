using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    bool gazedAt = false;
    float timer = 0.0f;
    [SerializeField]
    float actionTime;
    private Animator animator;

    void Start()
    {
    }

    void Update()
    {
        if (gazedAt == true)
        {
            timer += Time.deltaTime;
            if (timer > actionTime)
            {
                Material mats = gameObject.GetComponent<Renderer>().material;
                mats.SetColor("_Color", new Color(1.0f, 0.0f, 0.0f, 1.0f));
                gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                animator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
                animator.Play("PrefabFade");
            }
        }
    }

    public void OnPointerEnter()
    {
        gazedAt = true;
        timer = 0.0f;
    }

    public void OnPointerExit()
    {
        gazedAt = false;
        timer = 0.0f;
    }
}
