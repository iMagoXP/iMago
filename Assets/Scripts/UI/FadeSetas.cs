using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeSetas : MonoBehaviour
{
    public HorizontalSlider scriptHorizontalSlider;
    public Animator animatorEsquerdo;
    public Animator animatorBlack;
    private bool selfFaded = true;
    private bool allFaded = false;

    void Start()
    {
        animatorEsquerdo = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(scriptHorizontalSlider.sliderObjects[2].name == "Bem vindes !" && selfFaded == false)
        {
            selfFaded = true;
            animatorEsquerdo.Play("FadeImageOut");
        }
        else if(scriptHorizontalSlider.sliderObjects[2].name == "Prepare-se" && selfFaded == true)
        {
            selfFaded = false;
            animatorEsquerdo.Play("FadeImageIn");
        }
        else if(scriptHorizontalSlider.sliderObjects[2].name == "Entrar" && allFaded == false)
        {
            allFaded = true;
            StartCoroutine(transitionScene());
        } 
    }

    public IEnumerator transitionScene()
    {
            animatorBlack.Play("FadeImageIn");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Instagram");
    }
}
