using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlaBotoesInstagram : MonoBehaviour
{
    private Image background;
    private Button[] buttons;
    private GameObject[] panel;
    private Image[] childrenImage;
    private Text[] childrenText;
    private Text[] sobreText;

    void Start()
    {
        Time.timeScale = 0;
        background = gameObject.transform.parent.gameObject.GetComponent<Image>();
        buttons = gameObject.transform.parent.gameObject.GetComponentsInChildren<Button>(true);
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

        childrenImage = gameObject.transform.parent.gameObject.GetComponentsInChildren<Image>(true);
        background.enabled = false;
        childrenText = gameObject.transform.parent.gameObject.GetComponentsInChildren<Text>(true);
        buttons[1].gameObject.SetActive(false);
        buttons[0].gameObject.SetActive(false);
        childrenImage[4].gameObject.SetActive(true);
        childrenText[2].gameObject.SetActive(false);
    }

    public void OpenUrlManual()
    {
        Application.OpenURL("https://arvr.google.com/intl/pt-BR_pt/cardboard/manufacturers/");
    }

    public void Sobre()
    {
        panel = GameObject.FindGameObjectsWithTag("Panel");
        childrenImage = panel[0].gameObject.GetComponentsInChildren<Image>(true);
        childrenText = panel[0].gameObject.GetComponentsInChildren<Text>(true);
        foreach (Image img in childrenImage)
        {
            img.enabled = false;
        }
        foreach (Text txt in childrenText)
        {
            txt.enabled = false;
        }
        sobreText = panel[1].gameObject.GetComponentsInChildren<Text>(true);
        foreach (Text txt in sobreText)
        {
            txt.gameObject.SetActive(true);
        }
    }
}
