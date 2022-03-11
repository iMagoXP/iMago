using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonController : MonoBehaviour
{
    private RawImage background;
    private Button[] buttons;
    private GameObject[] panel;
    private Image[] childrenImage;
    private Text[] childrenText;
    private AudioSource audioSource;
    private int state;
    private float dt;

    void Start()
    {
        state = 0;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Instagram") Time.timeScale = 0;
        background = gameObject.transform.parent.gameObject.GetComponent<RawImage>();
        buttons = gameObject.transform.parent.gameObject.GetComponentsInChildren<Button>(true);
        childrenImage = gameObject.transform.parent.gameObject.GetComponentsInChildren<Image>(true);
        childrenText = gameObject.transform.parent.gameObject.GetComponentsInChildren<Text>(true);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void Volta()
    {
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("hi");
    }

    // Update is called once per frame
    public void IniciaCI()
    {
        audioSource.Play();
        Time.timeScale = 1;
        background.enabled = false;
        buttons[1].gameObject.SetActive(false);
        buttons[0].gameObject.SetActive(false);
        childrenImage[3].gameObject.SetActive(true);
        childrenText[0].gameObject.SetActive(false);
        childrenText[2].gameObject.SetActive(false);
    }
    
    public void VamosPassear()
    {
        audioSource.Play();
        childrenImage[5].color = new Color(0, 0, 0, 10);
        childrenImage[5].CrossFadeAlpha(1, 1.5f, false);
        state = 1;
    }

    public void Sobre()
    {
        audioSource.Play();
        buttons[1].gameObject.SetActive(false);
        buttons[0].gameObject.SetActive(false);
        childrenImage[1].enabled = false;
        childrenImage[4].enabled = false;
        childrenText[3].enabled = false;
        childrenText[4].enabled = false;
        childrenImage[6].enabled = true;
        childrenImage[7].enabled = true;
        childrenText[5].gameObject.SetActive(true);
        childrenText[6].gameObject.SetActive(true);
        childrenText[7].gameObject.SetActive(true);
        childrenText[8].gameObject.SetActive(true);
        childrenText[9].gameObject.SetActive(true);
        childrenText[10].gameObject.SetActive(true);
    }

    public void BaixarManual()
    {
        audioSource.Play();
        Application.OpenURL("https://drive.google.com/file/d/0B1LtQQO3eKRfV0E1SjZHa3V6ME0/view?resourcekey=0-Z9JXvZZoxhV51o4NAjk3Cw");
    }

    void Update() 
    {
        if(state == 1) dt += Time.deltaTime;
        if ( dt > 2 ) SceneManager.LoadScene("Explanation");
    }
}
