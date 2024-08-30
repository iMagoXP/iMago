using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIDragger : MonoBehaviour
{
    private Vector3 touchposition;
    private Vector2 startPos;
    private Vector2 direction;
    private Image[] childrenImage;
    private Image[] parentImage;
    public float magnitude;
    private bool limit;
    private float dt;
    private float fadeOutTimer;
    private Text[] childrenText;
    private Button[] buttons;
    public bool apertou;
    private UIDragger scriptMural;
    public string objectName;
    private Scene scene;
    private GameObject panel;
    public bool desativaSobre = false;
    public Animator panelSobre;
    public Animator panelInicial;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        objectName = gameObject.name;

        if (scene.name == "Menu")
        {
            if(objectName != "MuralSobre")
            {
                panel = GameObject.Find("Tela inicial");
                buttons = panel.gameObject.GetComponentsInChildren<Button>(true);
                childrenImage = panel.gameObject.GetComponentsInChildren<Image>(true);
                childrenText = panel.gameObject.GetComponentsInChildren<Text>(true);
                scriptMural = GameObject.Find("MuralSobre").gameObject.GetComponent<UIDragger>();
            }
            else if(objectName == "MuralSobre")
            {
                parentImage = GameObject.Find("MuralContainer").gameObject.GetComponentsInChildren<Image>(true);
            }

            apertou = false;
        }
        else if(scene.name == "Explanation")
        {
            childrenImage = gameObject.GetComponentsInChildren<Image>(true);
            parentImage = gameObject.transform.parent.gameObject.GetComponentsInChildren<Image>(true);
        }
    }
    
    
    void Update()
    {

        switch (objectName)
        {
            case "Sobre":
                verticalPanelsDrag(0.0f, -250.0f, 7500.0f);
                break;

            case "FichaTecnica":
                verticalPanelsDrag(1.0f, -250.0f, 3050.0f);
                break;

            case "LabGeist":
                verticalPanelsDrag(2.0f, -250.0f, 2000.0f);
                break;

            case "RITe":
                verticalPanelsDrag(3.0f, -250.0f, 5.0f);
                break;

            case "TrilhaEfeitosSonoros":
                verticalPanelsDrag(4.0f, -250.0f, 5.0f);
                break;

            case "MuralSobre":
                muralSobre();
                break;

            case "MuralExplanation":
                muralExplanation();
                break;
        }

        if(desativaSobre == true)
        {
            disableSobre();
            desativaSobre = false;
        }
    }

    private void manageTouch() 
    {

        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            
            case TouchPhase.Began:
                
                startPos = touch.position;
                break;

            case TouchPhase.Moved:

                direction = touch.position - startPos;
                if ((objectName == "MuralSobre" || objectName == "MuralExplanation")  && (direction.x > 88.0f || direction.x < -88.0f)) transform.localPosition += new Vector3(direction.normalized.x * magnitude, 0.0f, 0.0f);
                else transform.localPosition += new Vector3(0.0f, direction.normalized.y * magnitude, 0.0f);
                break;
        }
    }

    public void disableSobre()
    {
        StartCoroutine(VoltaInicio());
    }

    public IEnumerator VoltaInicio()
    {
        panelSobre.Play("FadeOut");
        yield return new WaitForSeconds(2);
        panelInicial.Play("FadeIn");
    }

    public void verticalPanelsDrag(float panelNumber, float disableHeight, float maxHeight)
    {
        float parentMinPosition;
        float parentMaxPosition;

        parentMinPosition = (-1125.0f * panelNumber) + 200;
        parentMaxPosition = (-1125.0f * panelNumber) - 200 ;

        if (Input.touchCount > 0 && apertou == true && transform.parent.transform.localPosition.x < parentMinPosition && transform.parent.transform.localPosition.x > parentMaxPosition)
        {

            if (transform.localPosition.y >= disableHeight && transform.localPosition.y < maxHeight)
            {
                manageTouch();
            }
            else
            {
                if (transform.localPosition.y > maxHeight) correctPositionY(maxHeight-1);
                else if (transform.localPosition.y < disableHeight-1.0f)
                {
                    desativaSobre = true;
                }
            }
        }
        else if (transform.parent.transform.localPosition.x < parentMaxPosition)
        {
            resetPosition();
        }
    }

    private void muralExplanation()
    {
        if (transform.localPosition.x < -5000.0f)
        {
            dt += Time.deltaTime;
            if (dt > 2) SceneManager.LoadScene("Instagram");
        }

        if (Input.touchCount > 0)
        {
            if (transform.localPosition.x <= 0.0f && transform.localPosition.x > -5562.5f)
            {
                manageTouch();
            }
            else if (transform.localPosition.x > 0.0f) correctPositionX(-1.0f);
        }
        else
        {
            if (transform.localPosition.x > -562.5f)
            {
                parentImage[2].CrossFadeAlpha(0, 0.5f, false);
                lerpPosition(-1.0f);
            }
            else if (transform.localPosition.x < -562.5f && transform.localPosition.x > -1687.5f)
            {
                parentImage[2].CrossFadeAlpha(1, 0.5f, false);
                lerpPosition(-1125.0f);
            }
            else if (transform.localPosition.x < -1687.5f && transform.localPosition.x > -2812.5f) lerpPosition(-2250.0f);
            else if (transform.localPosition.x < -2812.5f && transform.localPosition.x > -3937.5f) lerpPosition(-3375.0f);
            else if (transform.localPosition.x < -3937.5f && transform.localPosition.x > -5000.0f) lerpPosition(-4500f);
            else if (transform.localPosition.x < -5000.0f && transform.localPosition.x > -6125.0f)
            {
                lerpPosition(-5600.5f);
                childrenImage[7].CrossFadeAlpha(1, 0.5f, false);
            }
        }
    }

    private void muralSobre()
    {
        if (Input.touchCount > 0 && apertou == true)
        {
            if (transform.localPosition.x <= 0.0f && transform.localPosition.x > -4500.0f)
            {
                manageTouch();
            }
            else
            {
                if (transform.localPosition.x > 0.0f) correctPositionX(-1.0f);
                else if (transform.localPosition.x < -4500.0f) correctPositionX(-4499.0f);
            }
        }
        else
        {
            if (transform.localPosition.x > -562.5f)
            {
                parentImage[1].CrossFadeAlpha(0, 0.5f, false);
                lerpPosition(-1.0f);
            }
            else if (transform.localPosition.x < -562.5f && transform.localPosition.x > -1687.5f)
            {
                parentImage[1].CrossFadeAlpha(1, 0.5f, false);
                lerpPosition(-1125.0f);
            }
            else if (transform.localPosition.x < -1687.5f && transform.localPosition.x > -2812.5f) lerpPosition(-2250.0f);
            else if (transform.localPosition.x < -1687.5f && transform.localPosition.x > -3937.5f)
            {
                lerpPosition(-3375.0f);
                parentImage[0].CrossFadeAlpha(1, 0.5f, false);
            }
            else if (transform.localPosition.x < -3937.5f && transform.localPosition.x > -5062.5f)
            {
                lerpPosition(-4500.0f);
                parentImage[0].CrossFadeAlpha(0, 0.5f, false);
            }
        }

    }

    private void lerpPosition(float position)
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(position, transform.localPosition.y, transform.localPosition.z), 0.25f);
    }

    private void correctPositionX(float position)
    {
        transform.localPosition = new Vector3(position, transform.localPosition.y, transform.localPosition.z);
    }

    private void correctPositionY(float position)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, position, transform.localPosition.z);
    }

    public void ApertouBotao()
    {
        apertou = true;
    }

    public void apertaX()
    {
        disableSobre();
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void resetPosition()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0.0f, transform.localPosition.z);
    }
}
