using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private Image[] image;
    private float dt;
    private Text[] texto;
    public float screenTime;
    private int state = 0;

    // Start is called before the first frame update
    void Awake()
    {
        image = gameObject.GetComponentsInChildren < Image > (true);
        texto = gameObject.GetComponentsInChildren < Text > (true);
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt > screenTime && state <= 6)
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
                image[0].CrossFadeAlpha(0, 1.5f, false);
                image[1].CrossFadeAlpha(0, 1.5f, false);
                image[2].CrossFadeAlpha(0, 1.5f, false);
                image[3].CrossFadeAlpha(0, 1.5f, false);
                image[4].CrossFadeAlpha(0, 1.5f, false);
                texto[0].CrossFadeAlpha(0, 1.5f, false);
                texto[1].CrossFadeAlpha(0, 1.5f, false);
                texto[2].CrossFadeAlpha(0, 1.5f, false);
                texto[3].CrossFadeAlpha(0, 1.5f, false);
                texto[4].CrossFadeAlpha(0, 1.5f, false);
                break;

            case 2:
                texto[0].text = " Orgulhosamente \n Apresenta . . .";
                texto[1].text = "  Vamos passear ? ";
                texto[2].text = "  Sobre o projeto  ";
                texto[3].text = " iMago ";
                texto[4].text = " 2021 ";
                texto[0].CrossFadeAlpha(1, 1.5f, false);
                break;
            case 3:
                texto[0].CrossFadeAlpha(0, 1.5f, false);
                break;
            case 4:
                image[1].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Logo Cidade Instagram");
                image[1].color = new Color(255, 255, 255, 100);
                image[1].CrossFadeAlpha(1, 1.5f, false);
                break;
            case 5:
                texto[3].CrossFadeAlpha(1, 1.5f, false);
                texto[4].CrossFadeAlpha(1, 1.5f, false);
                image[4].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Pictograma CC");
                image[4].color = new Color(255, 255, 255, 100);
                image[4].CrossFadeAlpha(1, 1.5f, false);
                image[2].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Botão");
                image[2].color = new Color(255, 255, 255, 100);
                image[3].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Botão");
                image[3].color = new Color(255, 255, 255, 50);
                image[2].CrossFadeAlpha(1, 1.5f, false);
                texto[1].CrossFadeAlpha(1, 1.5f, false);
                image[3].CrossFadeAlpha(0.25f, 1.5f, false);
                texto[2].CrossFadeAlpha(1, 1.5f, false);
                break;

            default:
                break;
        }

    } 
}
