using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    bool gazedAt = false;
    bool playSound = false;
    bool playSoundLike = false;
    bool liked = false;
    float timer = 0.0f;
    float soundTimer = 0.0f;
    [SerializeField]
    float actionTime;
    private Animator animatorFade;
    private Animator[] animatorLike;
    private AudioSource[] audioSource;
    private Object[] audioClips;
    private Object audioClipHeart;

    void Start()
    {
        animatorLike = gameObject.transform.parent.gameObject.GetComponentsInChildren<Animator>();
        animatorFade = gameObject.transform.parent.gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponents<AudioSource>();
        audioClips = Resources.LoadAll("Music/FadeImages");
        audioClipHeart = Resources.Load("Music/Like/485076__inspectorj__heartbeat-regular-single-01-01-loop_RED");
    }

    void Update()
    {
        if (gazedAt == true && liked == false)
        {
            timer += Time.deltaTime;
            if (timer > actionTime)
            {
                Material mats = gameObject.GetComponent<Renderer>().material;
                mats.SetColor("_Color", new Color(1.0f, 0.0f, 0.0f, 1.0f));
                animatorLike[1].enabled = true;
                animatorLike[2].enabled = true;
                audioSource[1].Play();
                animatorFade.Play("PrefabFade");
                playSound = true;
                playSoundLike = true;
                liked = true;
            }
        }

        if(playSound == true)
        {
            soundTimer += Time.deltaTime;
            if(playSoundLike == true)
            {
                audioSource[1].PlayOneShot((AudioClip) audioClipHeart);
                playSoundLike = false;
            }
            if (soundTimer > 2)
            {
                int randomAudio = Random.Range(0, audioClips.Length);
                AudioClip fadeAudio = (AudioClip)audioClips[randomAudio];
                switch (randomAudio) 
                {
                    case 0:
                        Debug.Log("Case1");
                        audioSource[0].PlayOneShot(fadeAudio, 0.15f);
                        break;
                    case 1:
                        Debug.Log("Case2");
                        audioSource[0].PlayOneShot(fadeAudio, 0.4f);
                        break;
                    case 2:
                        Debug.Log("Case3");
                        audioSource[0].PlayOneShot(fadeAudio, 0.45f);
                        break;

                }

                playSound = false;
            }
        }
    }

    public void OnPointerEnter()
    {
        gazedAt = true;
        timer = 0.0f;
    }

    public void OnPointerExit()
    {
        gazedAt = false;
        timer = 0.0f;
    }
}
