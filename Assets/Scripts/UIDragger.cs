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
    public float magnitude;
    private bool limit;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Update the Text on the screen depending on current position of the touch each frame
            //touchposition = new Vector3(touch.position.x, 0.0f, 0.0f);
            //transform.position -= touchposition.normalized;
            // Debug.Log(touch.position);
            Debug.Log(transform.position.x);
            if (transform.position.x < 18.1f && transform.position.x > -242.0f)
            {
                Debug.Log(transform.position.x);
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
                        transform.position += new Vector3(direction.normalized.x * magnitude, 0.0f, 0.0f);
                        break;

                    case TouchPhase.Ended:
                        // Report that the touch has ended when it ends
                        Debug.Log("Ended");
                        break;
                }
            }
            else
            {
                if(transform.position.x > 18.1f)   transform.position = new Vector3( 17.5f, transform.position.y, transform.position.z );
                else if(transform.position.x < -242.0f)
                {
                    SceneManager.LoadScene("Instagram");
                }
            }
        }
    }
}
