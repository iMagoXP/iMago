using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    private int j = 0;
    public List<GameObject> logos;
    private Coroutine splashCoroutine = null;
    private Coroutine waitCoroutine = null;
    
    void Start()
    {
        splashCoroutine = StartCoroutine(SplashRoutine());
    }

    public IEnumerator SplashRoutine()
    {
        for(int i = j; i < logos.Count; i++)
        { 
            j = i;


            logos[i].SetActive(true);
            waitCoroutine = StartCoroutine(EspereInterruptivel(4.2f));
            yield return waitCoroutine;

            if(i != logos.Count-1)
            {
                logos[i].GetComponent<ControlaLogos>().FadeOut();
                waitCoroutine = StartCoroutine(EspereInterruptivel(2.0f));
                yield return waitCoroutine;
                logos[i].SetActive(false);
            }
            
        }

    }

    public IEnumerator EspereInterruptivel(float tempo)
    {
        float tempoEspera = tempo;

        while (tempoEspera > 0.0f)
        {
            tempoEspera -= Time.deltaTime;
            yield return 0;
        }

    }

    private void interrompeEspera()
    {
        if (waitCoroutine != null)  StopCoroutine(waitCoroutine);
    }

    public void SkipSplash()
    {
        if(j < logos.Count-1)
        {
            interrompeEspera();
            StopCoroutine(splashCoroutine);
            if(j == logos.Count-3) logos[j].GetComponent<ControlaLogos>().StopAnimation();
            logos[j].SetActive(false);

            j++;
            splashCoroutine = StartCoroutine(SplashRoutine());
        }
        else if(j >= logos.Count-1)
            gameObject.GetComponent<Button>().enabled = false;
    }
}
