using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private Button[] buttons;
    private Image[] image;
    private Text[] texto;
    private float dt;

    private AspectRatioFitter aspectRatioFitter;

    [SerializeField]
    private float screenTimeOffScreen;
    [SerializeField]
    private float screenTimeOnScreen;
    [SerializeField]
    private float startTime;
    [SerializeField]
    private float transitions;

    private int state;

    // Start is called before the first frame update
    void Awake()
    {
        image = gameObject.GetComponentsInChildren < Image > (true);
        texto = gameObject.GetComponentsInChildren < Text > (true);
        buttons = gameObject.GetComponentsInChildren< Button >(true);
        aspectRatioFitter = gameObject.GetComponentInChildren< AspectRatioFitter >(true);

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Splashs")
        {
            state = 0;
            image[0].CrossFadeAlpha(0, 0.1f, false);
        }
        else if(scene.name == "Menu")
        {
            buttons[0].enabled = false;
            buttons[1].enabled = false;

            image[0].CrossFadeAlpha(0, transitions, false);
            image[1].CrossFadeAlpha(0, transitions, false);
            image[2].CrossFadeAlpha(0, transitions, false);
            image[3].CrossFadeAlpha(0, transitions, false);
            image[4].CrossFadeAlpha(0, 0.1f, false);
            image[5].CrossFadeAlpha(0, 0.1f, false);
            image[6].CrossFadeAlpha(0, 0.1f, false);
            image[12].CrossFadeAlpha(0, 1.5f, false);

            texto[0].CrossFadeAlpha(0, transitions, false);
            texto[1].CrossFadeAlpha(0, transitions, false);
            texto[2].CrossFadeAlpha(0, transitions, false);
            texto[3].CrossFadeAlpha(0, transitions, false);
            texto[4].CrossFadeAlpha(0, transitions, false);
            texto[5].CrossFadeAlpha(0, 0.1f, false);
            texto[6].CrossFadeAlpha(0, 0.1f, false);

            state = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if ((startTime > 0  && dt > startTime) || (dt > screenTimeOnScreen && state <= 7 && state%2 == 0)|| (dt > screenTimeOffScreen && state <= 7 && state % 2 != 0))
        {
            UpdateUI(state);
            state++;
            dt = 0;
            if (state == 2) startTime = 0;
        }

    }

    private void UpdateUI(int state)
    {
        switch (state)
        {
            case 0:

                image[1].CrossFadeAlpha(0, transitions, false);
                break;

            case 1:

                image[0].CrossFadeAlpha(1, transitions, false);
                break;

            case 2:

                image[0].CrossFadeAlpha(0, transitions, false);
                break;

            case 3:

                texto[0].text = " Orgulhosamente \n Apresenta . . .";
                texto[0].CrossFadeAlpha(1, transitions, false);
                break;

            case 4:

                texto[0].CrossFadeAlpha(0, transitions, false);
                break;

            case 5:

                SceneManager.LoadScene("Menu");
                break;

            case 6:

                image[0].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Logo Cidade Instagram");
                image[0].color = new Color(255, 255, 255, 100);
                image[0].CrossFadeAlpha(1, transitions, false);

                texto[0].text = "  Vamos passear ? ";
                texto[1].text = "  Sobre o projeto  ";
                texto[2].text = " iMago ";
                texto[3].text = " 2021-22 ";
                texto[2].CrossFadeAlpha(1, transitions, false);
                texto[3].CrossFadeAlpha(1, transitions, false);

                image[3].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Pictograma CC");
                image[3].color = new Color(255, 255, 255, 100);
                image[3].CrossFadeAlpha(1, transitions, false);
                break;

            case 7:

                image[1].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Bot�o");
                image[1].color = new Color(255, 255, 255, 100);
                image[2].sprite = Resources.Load<Sprite>("UI/220202 Cidade Instagram - Artboards__Bot�o");
                image[2].color = new Color(255, 255, 255, 50);
                image[1].CrossFadeAlpha(1, transitions, false);

                texto[0].CrossFadeAlpha(1, transitions, false);
                image[2].CrossFadeAlpha(0.25f, transitions, false);
                texto[1].CrossFadeAlpha(1, transitions, false);

                buttons[0].enabled = true;
                buttons[1].enabled = true;
                break;

            default:

                break;
        }

    } 
}
