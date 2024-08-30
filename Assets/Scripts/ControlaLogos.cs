using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaLogos : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.Play("FadeIn");
    }
    
    public void FadeOut()
    {
        animator.Play("FadeOut");
    }

    public void StopAnimation()
    {
        animator.enabled = false;
    }
}
