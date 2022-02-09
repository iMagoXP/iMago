using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlaBotoesInstagram : MonoBehaviour
{
    private Image background;
    private Button[] buttons;

    void Start()
    {
        Time.timeScale = 0;
        background = gameObject.transform.parent.gameObject.GetComponentInChildren<Image>(true);
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
        background.gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[0].gameObject.SetActive(false);
    }
}
