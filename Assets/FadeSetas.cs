using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeSetas : MonoBehaviour
{
    public HorizontalSlider scriptHorizontalSlider;
    public Animator animatorEsquerdo;
    public Animator animatorGeral;
    private bool selfFaded = true;
    private bool allFaded = false;

    void Start()
    {
        animatorEsquerdo = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(scriptHorizontalSlider.sliderObjects[0].name == "Atenção" && selfFaded == false)
        {
            selfFaded = true;
            animatorEsquerdo.Play("FadeImageOut");
        }
        else if(scriptHorizontalSlider.sliderObjects[0].name == "Tudo Pronto" && selfFaded == true)
        {
            selfFaded = false;
            animatorEsquerdo.Play("FadeImageIn");
        }
        else if(scriptHorizontalSlider.sliderObjects[0].name == "Prepare-se" && allFaded == false)
        {
            allFaded = true;
            StartCoroutine(transitionScene());
        } 
    }

    public IEnumerator transitionScene()
    {
            animatorGeral.Play("FadeOut");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Instagram");
    }
}
