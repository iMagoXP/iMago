using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISobre : MonoBehaviour
{
    private Vector3 touchposition;
    private Vector2 startPos;
    private Vector2 direction;
    public float magnitude;
    private bool limit;
    private Image[] childrenImage;
    private Text[] childrenText;
    private Button[] buttons;

    void Start()
    {
        buttons = gameObject.transform.parent.gameObject.GetComponentsInChildren<Button>(true);
        childrenImage = gameObject.transform.parent.gameObject.GetComponentsInChildren<Image>(true);
        childrenText = gameObject.transform.parent.gameObject.GetComponentsInChildren<Text>(true);
    }

    // Start is called before the first frame update
    void Update()
    {
        Debug.Log(transform.position.y);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Update the Text on the screen depending on current position of the touch each frame
            //touchposition = new Vector3(touch.position.x, 0.0f, 0.0f);
            //transform.position -= touchposition.normalized;
            // Debug.Log(touch.position);
            if (transform.position.y >= -118.0f && transform.position.y < 125.0f)
            {
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
                        transform.position += new Vector3(0.0f, direction.normalized.y * magnitude, 0.0f);
                        break;

                    case TouchPhase.Ended:
                        // Report that the touch has ended when it ends
                        Debug.Log("Ended");
                        break;
                }
            }
            else
            {
                if (transform.position.y > 125.0f) transform.position = new Vector3(transform.position.x, 123.0f, transform.position.z);
                else if (transform.position.y < -118.0f)
                {
                    buttons[1].gameObject.SetActive(true);
                    buttons[0].gameObject.SetActive(true);
                    childrenImage[1].enabled = true;
                    childrenImage[4].enabled = true;
                    childrenText[3].enabled = true;
                    childrenText[4].enabled = true;
                    childrenText[5].gameObject.SetActive(false);
                    childrenText[6].gameObject.SetActive(false);
                }
            }
        }
    }
}
