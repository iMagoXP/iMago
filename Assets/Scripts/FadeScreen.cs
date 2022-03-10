using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    private Image fade;

    private void Start()
    {
        fade = gameObject.GetComponent<Image>();
        FadeOut();
    }

    public void FadeIn()
    {
        fade.CrossFadeAlpha(1, 2.0f, false);
    }

    private void FadeOut()
    {
        fade.CrossFadeAlpha(0, 2.0f, false);
    }
}
