using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private Image[] image;
    private float dt;
    private Text[] texto = new Text[2];
    public float screenTime;
    private int state = 0;
    private Button[] buttons = new Button[2];

    // Start is called before the first frame update
    void Awake()
    {
        image = gameObject.GetComponentsInChildren < Image > (true);
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
                image[1].CrossFadeAlpha(0, 1.5f, false);
                break;
            case 2:
                texto[0].text = " Orgulhosamente ";
                texto[1].text = " Apresenta... ";
                texto[0].CrossFadeAlpha(1, 1.5f, false);
                texto[1].CrossFadeAlpha(1, 1.5f, false);
                break;
            case 3:
                texto[0].CrossFadeAlpha(0, 1.5f, false);
                texto[1].CrossFadeAlpha(0, 1.5f, false);
                break;
            case 4:
                image[1].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Logo Cidade Instagram");
                image[1].CrossFadeAlpha(1, 1.5f, false);
                break;
            case 5:
                image[4].gameObject.SetActive(true);
                buttons[0].gameObject.SetActive(true);
                buttons[1].gameObject.SetActive(true);
                break;
            default:
                break;
        }

    } 
}
