using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class SplashController : MonoBehaviour
{
    private int j = 0;
    public bool inicia;
    public List<GameObject> logos;
    private Coroutine splashCoroutine = null;
    private Coroutine waitCoroutine = null;
    public GameObject SeenSplashes;
    public Button skipSplashes;
    
    void Start()
    {
        GameObject seenSplashes = GameObject.Find("SeenSplashes");
        if(seenSplashes != null)  j = logos.Count-1;
        else Instantiate(SeenSplashes, new Vector3 (0,0,0), Quaternion.identity).name = SeenSplashes.name;
        inicia = false;
    }

    void Update()
    {
        if(SplashScreen.isFinished && inicia == false)
        {
            inicia = true;
            skipSplashes.interactable = true;
            splashCoroutine = StartCoroutine(SplashRoutine());
        }
    }
    public IEnumerator SplashRoutine()
    {
        if(j == 0)
        {
            waitCoroutine = StartCoroutine(EspereInterruptivel(2.0f));
            yield return waitCoroutine;
        }
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
