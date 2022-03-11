using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    bool gazedAt = false;
    float timer = 0.0f;
    [SerializeField]
    float actionTime;
    private Animator animatorFade;
    private Animator[] animatorLike;
    private AudioSource[] audioSource;
    private Object[] audioClips;

    void Start()
    {
        animatorLike = gameObject.transform.parent.gameObject.GetComponentsInChildren<Animator>();
        animatorFade = gameObject.transform.parent.gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponents<AudioSource>();
        audioClips = Resources.LoadAll("/Music/");
    }

    void Update()
    {
        if (gazedAt == true)
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
                audioSource[0].PlayOneShot((AudioClip) audioClips[Random.Range(0, audioClips.Length)]);
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
