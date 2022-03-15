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
                animatorLike[0].enabled = true;
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
                audioSource[0].PlayOneShot((AudioClip)audioClips[Random.Range(0, audioClips.Length)]);
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
