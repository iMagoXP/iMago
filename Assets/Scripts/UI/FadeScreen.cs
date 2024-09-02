using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator.Play("FadeImageOut");
    }

    public void FadeIn()
    {
        animator.Play("FadeImageIn");
    }

    private void FadeOut()
    {
        animator.Play("FadeImageOut");
    }
}
