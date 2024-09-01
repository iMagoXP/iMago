using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonController : MonoBehaviour
{
    private RawImage background;
    private Button[] buttons;
    private GameObject panel;
    private Image[] childrenImage;
    private Text[] childrenText;
    private AudioSource audioSource;
    private float dt;
    public Animator panelInicial;
    public Animator panelSobre;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Instagram") Time.timeScale = 0;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Volta()
    {
        audioSource.Play();
        SceneManager.LoadScene("Menu");
    }

    public void IniciaCI()
    {
        audioSource.Play();
        Time.timeScale = 1;
        buttons[1].gameObject.SetActive(false);
        buttons[0].gameObject.SetActive(false);
        childrenImage[3].gameObject.SetActive(true);
        childrenText[0].gameObject.SetActive(false);
        childrenText[2].gameObject.SetActive(false);
    }
    
    public void Iniciar()
    {
        StartCoroutine(VamosPassear());
    }
    public IEnumerator VamosPassear()
    {
        audioSource.Play();
        panelInicial.Play("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Explanation");
    }
    
    public void Sobre()
    {
        StartCoroutine(MostraSobre());
    }

    public IEnumerator MostraSobre()
    {
        audioSource.Play();
        panelInicial.Play("FadeOut");
        yield return new WaitForSeconds(2);
        panelSobre.Play("FadeIn");
    }
    public void SaiSobre()
    {
        StartCoroutine(FechaSobre());
    }

    public IEnumerator FechaSobre()
    {
        audioSource.Play();
        panelSobre.Play("FadeOut");
        yield return new WaitForSeconds(2);
        panelInicial.Play("FadeIn");
    }
    public void BaixarManual()
    {
        audioSource.Play();
        Application.OpenURL("https://drive.google.com/file/d/0B1LtQQO3eKRfV0E1SjZHa3V6ME0/view?resourcekey=0-Z9JXvZZoxhV51o4NAjk3Cw");
    }
}
