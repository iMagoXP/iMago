using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private Image imagem;
    private float dt;
    private Text[] texto = new Text[2];
    public float screenTime;
    private int state = 0;
    private Button[] buttons = new Button[2];

    // Start is called before the first frame update
    void Awake()
    {
        imagem = gameObject.GetComponentInChildren < Image > ();
        texto = gameObject.GetComponentsInChildren < Text > (true);
        buttons = gameObject.GetComponentsInChildren < Button >(true);
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt > screenTime && state <= 5)
        {
            UpdateUI(state);
            state++;
            dt = 0;
        }

    }

    private void UpdateUI(int state)
    {
        switch (state)
        {
            case 1:
                texto[0].CrossFadeAlpha(0, 1.5f, false);
                texto[1].CrossFadeAlpha(0, 1.5f, false);
                break;
            case 2:
                texto[0].text = " Orgulhosamente ";
                texto[1].text = " Apresenta... ";
                texto[1].color = new Color(1, 1, 1, 1);
                texto[0].CrossFadeAlpha(1, 1.5f, false);
                texto[1].CrossFadeAlpha(1, 1.5f, false);
                break;
            case 3:
                texto[0].CrossFadeAlpha(0, 1.5f, false);
                texto[1].CrossFadeAlpha(0, 1.5f, false);
                break;
            case 4:
                texto[0].text = " A Cidade ";
                texto[0].color = new Color(0, 0, 0, 1);
                texto[1].text = " Instagram ";
                texto[0].CrossFadeAlpha(1, 1.5f, false);
                texto[1].CrossFadeAlpha(1, 1.5f, false);
                break;
            case 5:
                buttons[0].gameObject.SetActive(true);
                buttons[1].gameObject.SetActive(true);
                break;
            default:
                break;
        }

    } 
}
