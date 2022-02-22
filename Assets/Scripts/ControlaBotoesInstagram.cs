using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlaBotoesInstagram : MonoBehaviour
{
    private RawImage background;
    private Button[] buttons;
    private GameObject[] panel;
    private Image[] childrenImage;
    private Text[] childrenText;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Instagram") Time.timeScale = 0;
        background = gameObject.transform.parent.gameObject.GetComponent<RawImage>();
        buttons = gameObject.transform.parent.gameObject.GetComponentsInChildren<Button>(true);
        childrenImage = gameObject.transform.parent.gameObject.GetComponentsInChildren<Image>(true);
        childrenText = gameObject.transform.parent.gameObject.GetComponentsInChildren<Text>(true);
    }

    // Start is called before the first frame update
    public void Volta()
    {
        SceneManager.LoadScene("Explanation");
    }

    // Update is called once per frame
    public void IniciaCI()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Sobre()
    {
        buttons[1].gameObject.SetActive(false);
        buttons[0].gameObject.SetActive(false);
        childrenImage[1].enabled = false;
        childrenImage[4].enabled = false;
        childrenText[3].enabled = false;
        childrenText[4].gameObject.SetActive(true);
        childrenText[5].gameObject.SetActive(true);
    }

    public void BaixarManual()
    {
        Application.OpenURL("https://arvr.google.com/intl/pt-BR_pt/cardboard/manufacturers/");
    }
}
