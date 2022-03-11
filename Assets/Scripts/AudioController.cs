using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    private bool played;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "AudioSource")   DontDestroyOnLoad(this.gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Mural")
        {
            if (transform.localPosition.x < -600.0f && transform.localPosition.x > -800.0f && played == false)
            {
                audioSource.Play();
                played = true;
            }
            else if (transform.localPosition.x < -1600.0f && transform.localPosition.x > -1800.0f && played == false)
            {
                audioSource.Play();
                played = true;
            }
            else if (transform.localPosition.x < -2700.0f && transform.localPosition.x > -2900.0f && played == false)
            {
                audioSource.Play();
                played = true;
            }
            else if (transform.localPosition.x < -3800.0f && transform.localPosition.x > -4000.0f && played == false)
            {
                played = true;
                audioSource.Play();
            }
            else if (transform.localPosition.x < -5000.0f && transform.localPosition.x > -5200.0f && played == false)
            {
                audioSource.Play();
                played = true;
            }
            else if (transform.localPosition.x < -0.0f && transform.localPosition.x > -1125.0f) played = false;
            else if (transform.localPosition.x < -1800.0f && transform.localPosition.x > -2700.0f) played = false;
            else if (transform.localPosition.x < -2900.0f && transform.localPosition.x > -3800.0f) played = false;
            else if (transform.localPosition.x < -4000.0f && transform.localPosition.x > -5000.0f) played = false;
        }
    }
}
