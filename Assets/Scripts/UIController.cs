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
    private AspectRatioFitter aspectRatioFitter;
    private Resolution resolution;
    public float screenTime;
    [SerializeField]
    private float transitions;
    private int state = 0;
    private Button[] buttons;

    // Start is called before the first frame update
    void Awake()
    {
        image = gameObject.GetComponentsInChildren < Image > (true);
        texto = gameObject.GetComponentsInChildren < Text > (true);
        buttons = gameObject.GetComponentsInChildren< Button >(true);
        aspectRatioFitter = gameObject.GetComponentInChildren< AspectRatioFitter >(true);
        buttons[0].enabled = false;
        buttons[1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt > screenTime && state <= 7)
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
                image[5].CrossFadeAlpha(0, transitions, false);
                break;

            case 2:
                image[0].CrossFadeAlpha(0, transitions, false);
                image[1].CrossFadeAlpha(0, transitions, false);
                image[2].CrossFadeAlpha(0, transitions, false);
                image[3].CrossFadeAlpha(0, transitions, false);
                image[4].CrossFadeAlpha(0, transitions, false);
                image[5].CrossFadeAlpha(0, transitions, false);
                texto[0].CrossFadeAlpha(0, transitions, false);
                texto[1].CrossFadeAlpha(0, transitions, false);
                texto[2].CrossFadeAlpha(0, transitions, false);
                texto[3].CrossFadeAlpha(0, transitions, false);
                texto[4].CrossFadeAlpha(0, transitions, false);
                break;

            case 3:
                texto[0].text = " Orgulhosamente \n Apresenta . . .";
                texto[1].text = "  Vamos passear ? ";
                texto[2].text = "  Sobre o projeto  ";
                texto[3].text = " iMago ";
                texto[4].text = " 2021 ";
                texto[0].CrossFadeAlpha(1, transitions, false);
                break;
            case 4:
                texto[0].CrossFadeAlpha(0, transitions, false);
                break;
            case 5:
                image[1].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Logo Cidade Instagram");
                image[1].color = new Color(255, 255, 255, 100);
                image[1].CrossFadeAlpha(1, transitions, false);
                texto[3].CrossFadeAlpha(1, transitions, false);
                texto[4].CrossFadeAlpha(1, transitions, false);
                image[4].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Pictograma CC");
                image[4].color = new Color(255, 255, 255, 100);
                image[4].CrossFadeAlpha(1, transitions, false);
                break;
            case 6:
                image[2].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Botão");
                image[2].color = new Color(255, 255, 255, 100);
                image[3].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Botão");
                image[3].color = new Color(255, 255, 255, 50);
                image[2].CrossFadeAlpha(1, transitions, false);
                texto[1].CrossFadeAlpha(1, transitions, false);
                image[3].CrossFadeAlpha(0.25f, transitions, false);
                texto[2].CrossFadeAlpha(1, transitions, false);
                buttons[0].enabled = true;
                buttons[1].enabled = true;
                break;

            default:
                break;
        }

    } 
}
