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
    private int state;
    private float dt;
    private bool playSound;


    void Start()
    {
        state = 0;

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Instagram") Time.timeScale = 0;

        panel = GameObject.Find("Panel");

        if (scene.name == "Interface")
        {
            buttons = panel.gameObject.GetComponentsInChildren<Button>(true);
            childrenImage = panel.gameObject.GetComponentsInChildren<Image>(true);
            childrenText = panel.gameObject.GetComponentsInChildren<Text>(true);
        }

        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void Update()
    {
        if (state == 1)
        {

            dt += Time.deltaTime;

            if (dt > 2) SceneManager.LoadScene("Explanation");

        }
        else if(state == 2)
        {

            dt += Time.deltaTime;

            if (playSound == true) 
            { 
                audioSource.Play();
                playSound = false;
            }

            buttons[1].enabled = false;
            buttons[0].enabled = false;
            childrenImage[1].CrossFadeAlpha(0, 0.2f, false);
            childrenImage[2].CrossFadeAlpha(0, 0.2f, false);
            childrenImage[3].CrossFadeAlpha(0, 0.2f, false);
            childrenImage[4].CrossFadeAlpha(0, 0.2f, false);
            childrenText[1].CrossFadeAlpha(0, 0.2f, false);
            childrenText[2].CrossFadeAlpha(0, 0.2f, false);
            childrenText[3].CrossFadeAlpha(0, 0.2f, false);
            childrenText[4].CrossFadeAlpha(0, 0.2f, false);

            if(dt > 0.3f)
            {
                childrenImage[5].CrossFadeAlpha(1, 1.0f, false);
                childrenImage[6].CrossFadeAlpha(1, 1.0f, false);
                childrenImage[7].CrossFadeAlpha(1, 1.0f, false);
                childrenText[5].CrossFadeAlpha(1, 1.0f, false);
                childrenText[6].CrossFadeAlpha(1, 1.0f, false);
                dt = 0.0f;
                state = 0;
            }
        }
    }

    // Start is called before the first frame update
    public void Volta()
    {
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Update is called once per frame
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
    
    public void VamosPassear()
    {
        audioSource.Play();
        GameObject.Find("Fade").GetComponent<Image>().CrossFadeAlpha(1, 1.5f, false);
        state = 1;
    }

    public void Sobre()
    {
        state = 2;
        playSound = true;
    }

    public void BaixarManual()
    {
        audioSource.Play();
        Application.OpenURL("https://drive.google.com/file/d/0B1LtQQO3eKRfV0E1SjZHa3V6ME0/view?resourcekey=0-Z9JXvZZoxhV51o4NAjk3Cw");
    }
}
