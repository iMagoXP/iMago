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
    public float magnitude;
    private bool limit;
    private float dt;
    private Text[] childrenText;
    private Button[] buttons;
    public bool apertou;
    private UIDragger scriptMural;
    public string objectName;
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if(scene.name == "Interface")
        {
            objectName = gameObject.name;
            if(objectName != "MuralSobre")
            {
                buttons = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponentsInChildren<Button>(true);
                childrenImage = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponentsInChildren<Image>(true);
                childrenText = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponentsInChildren<Text>(true);
                scriptMural = gameObject.transform.parent.gameObject.GetComponent<UIDragger>();
            }
            apertou = false;
        }
        if(scene.name == "Explanation")
        {
            childrenImage = gameObject.GetComponentsInChildren<Image>(true);
        }
    }
    
    
    void Update()
    {
        if(objectName == "Sobre") sobre();
        else if(objectName == "FichaTecnica") fichaTecnica();
        else if(objectName == "MuralSobre") muralSobre();
        else if(objectName == "LabGeist") labGeist();
        else if(scene.name == "Explanation") explanation();
    }

    private void manageTouch() 
    {

        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            //When a touch has first been detected, change the message and record the starting position
            case TouchPhase.Began:
                // Record initial touch position.
                startPos = touch.position;
                break;

            //Determine if the touch is a moving touch
            case TouchPhase.Moved:
                // Determine direction by comparing the current touch position with the initial one
                direction = touch.position - startPos;
                if (objectName == "MuralSobre")
                {
                    if (direction.x > 85.0f || direction.x < -85.0f) transform.localPosition += new Vector3(direction.normalized.x * magnitude, 0.0f, 0.0f);
                }
                else if(objectName == "Sobre" || objectName == "FichaTecnica" || objectName == "LabGeist") transform.localPosition += new Vector3(0.0f, direction.normalized.y * magnitude, 0.0f);
                else transform.localPosition += new Vector3(direction.normalized.x * magnitude, 0.0f, 0.0f);
                break;

            case TouchPhase.Ended:
                // Report that the touch has ended when it ends
                Debug.Log("Ended");
                break;
        }
    }

    private void disableSobre()
    {
        buttons[1].gameObject.SetActive(true);
        buttons[0].gameObject.SetActive(true);
        childrenImage[1].enabled = true;
        childrenImage[4].enabled = true;
        childrenText[3].enabled = true;
        childrenText[4].enabled = true;
        childrenText[5].enabled = true;
        childrenImage[6].enabled = false;
        childrenText[5].gameObject.SetActive(false);
        childrenText[6].gameObject.SetActive(false);
        childrenText[7].gameObject.SetActive(false);
        childrenText[8].gameObject.SetActive(false);
        childrenText[9].gameObject.SetActive(false);
        childrenText[10].gameObject.SetActive(false);
        transform.localPosition = new Vector3(transform.localPosition.x, 0.0f, transform.localPosition.z);
        transform.parent.transform.localPosition = new Vector3(0.0f, transform.localPosition.y, transform.localPosition.z);
        apertou = false;
        scriptMural.apertou = false;
    }

    private void fichaTecnica()
    {
        if (Input.touchCount > 0 && apertou == true && transform.parent.transform.localPosition.x < -562.5f && transform.parent.transform.localPosition.x > -1687.5f)
        {
            if (transform.localPosition.y >= -250.0f && transform.localPosition.y < 3200.0f)
            {
                manageTouch();
            }
            else
            {
                if (transform.localPosition.y > 3200.0f) correctPositionY(3199.0f);
                else if (transform.localPosition.y < -249.0f)
                {
                    disableSobre();
                }
            }
        }
        else if (transform.parent.transform.localPosition.x > -562.5f || transform.parent.transform.localPosition.x < -1687.5f)
        {
            resetPosition();
        }
    }

    private void sobre()
    {
        if (Input.touchCount > 0 && apertou == true && transform.parent.transform.localPosition.x < 0.0f && transform.parent.transform.localPosition.x > -562.5f)
        {

            if (transform.localPosition.y >= -250.0f && transform.localPosition.y < 6300.0f)
            {
                manageTouch();
            }
            else
            {
                if (transform.localPosition.y > 6300.0f) correctPositionY(6299.0f);
                else if (transform.localPosition.y < -249.0f)
                {
                    disableSobre();
                }
            }
        }
        else if (transform.parent.transform.localPosition.x < -562.5f)
        {
            resetPosition();
        }
    }
    
    private void labGeist()
    {
        if (Input.touchCount > 0 && apertou == true && transform.parent.transform.localPosition.x < -1687.5f && transform.parent.transform.localPosition.x > -2812.5f)
        {

            if (transform.localPosition.y >= -250.0f)
            {
                manageTouch();
            }
            else if (transform.localPosition.y < -249.0f) disableSobre();
        }
        else if (transform.parent.transform.localPosition.x < -562.5f)
        {
            resetPosition();
        }
    }

    private void explanation()
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
            else
            {
                if (transform.localPosition.x > 0.0f) correctPositionX(-1.0f);
            }
        }
        else
        {
            if (transform.localPosition.x > -562.5f) lerpPosition(-1.0f);
            else if (transform.localPosition.x < -562.5f && transform.localPosition.x > -1687.5f) lerpPosition(-1125.0f);
            else if (transform.localPosition.x < -1687.5f && transform.localPosition.x > -2812.5f) lerpPosition(-2250.0f);
            else if (transform.localPosition.x < -2812.5f && transform.localPosition.x > -3937.5f) lerpPosition(-3375.0f);
            else if (transform.localPosition.x < -3937.5f && transform.localPosition.x > -5000.0f) lerpPosition(-4500f);
            else if (transform.localPosition.x < -5000.0f && transform.localPosition.x > -6125.0f)
            {
                lerpPosition(-5600.5f);
                childrenImage[15].CrossFadeAlpha(1, 0.5f, false);
            }
        }
    }

    private void muralSobre()
    {
        if (Input.touchCount > 0 && apertou == true)
        {
            if (transform.localPosition.x <= 0.0f && transform.localPosition.x > -2250.0f)
            {
                manageTouch();
            }
            else
            {
                if (transform.localPosition.x > 0.0f) correctPositionX(-1.0f);
                else if (transform.localPosition.x < 2250.0f) correctPositionX(-2249.0f);
            }
        }
        else
        {
            if (transform.localPosition.x > -562.5f) lerpPosition(-1.0f);
            else if (transform.localPosition.x < -562.5f && transform.localPosition.x > -1687.5f) lerpPosition(-1125.0f);
            else if (transform.localPosition.x < -1687.5f && transform.localPosition.x > -2812.5f) lerpPosition(-2250.0f);
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

    public void ApertouBotão()
    {
        apertou = true;
    }

    private void resetPosition()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0.0f, transform.localPosition.z);
    }
}
