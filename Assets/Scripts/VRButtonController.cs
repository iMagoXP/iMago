using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRButtonController : MonoBehaviour
{
    bool gazedAt = false;
    float timer = 0.0f;
    float activeTimer = 0.0f;
    [SerializeField]
    float actionTime;
    private Animator animator;
    private SpriteRenderer[] spriteRenderers;
    private TextMesh[] textMesh;
    private GameObject spawners;
    private GameObject carrousel;
    private AudioSource audioSource;
    private Color fadeOut;
    private Color hoverIn;
    private Color hoverOut;
    private bool activated;
    private bool playSound = false;
    

    void Start()
    {
        spriteRenderers = gameObject.transform.parent.gameObject.GetComponentsInChildren<SpriteRenderer>();
        textMesh = gameObject.transform.parent.gameObject.GetComponentsInChildren<TextMesh>();
        spawners = GameObject.FindGameObjectWithTag("ImageSpawners");
        carrousel = GameObject.FindGameObjectWithTag("Carrousel");
        audioSource = gameObject.GetComponent<AudioSource>();
        gazedAt = false;
        activated = false;
        hoverIn = new Color(255, 255, 255, 1);
        hoverOut = new Color(255, 255, 255, 0.3f);
        fadeOut = new Color(255, 255, 255, 0);
    }

    void Update()
    {
        if (gazedAt == true && activated == false)
        {
            if (gameObject.name == "Entrar !") spriteRenderers[0].color = Color.Lerp(spriteRenderers[0].color, hoverIn, Time.deltaTime * 2.5f);
            else if (gameObject.name == "Voltar") spriteRenderers[2].color = Color.Lerp(spriteRenderers[2].color, hoverIn, Time.deltaTime * 2.5f);

            timer += Time.deltaTime;

            if (timer > actionTime)
            {
                activated = true;
                playSound = true;
                timer = 0.0f;
            }
        }
        else if (gazedAt == false && activated == false)
        {
            if (gameObject.name == "Entrar !") spriteRenderers[0].color = Color.Lerp(spriteRenderers[0].color, hoverOut, Time.deltaTime * 2.5f);
            else if (gameObject.name == "Voltar") spriteRenderers[2].color = Color.Lerp(spriteRenderers[2].color, hoverOut, Time.deltaTime * 2.5f);
        }

        if (gameObject.name == "Entrar !" && activated == true)
        {
            
            activeTimer += Time.deltaTime;

            foreach (Transform child in spawners.transform)
            {
                child.gameObject.SetActive(true);
            }

            CarrouselRotator rotator = carrousel.GetComponent<CarrouselRotator>();
            rotator.DegreesPerSecond = 1.2f;

            spriteRenderers[0].color = Color.Lerp(spriteRenderers[0].color, fadeOut, Time.deltaTime * 2.5f);
            spriteRenderers[1].color = Color.Lerp(spriteRenderers[1].color, fadeOut, Time.deltaTime * 2.5f);
            spriteRenderers[2].color = Color.Lerp(spriteRenderers[2].color, fadeOut, Time.deltaTime * 12.5f);
            spriteRenderers[3].color = Color.Lerp(spriteRenderers[3].color, fadeOut, Time.deltaTime * 2.5f);

            textMesh[0].color = Color.Lerp(textMesh[0].color, fadeOut, Time.deltaTime * 2.5f);
            textMesh[1].color = Color.Lerp(textMesh[1].color, fadeOut, Time.deltaTime * 2.5f);
            textMesh[2].color = Color.Lerp(textMesh[2].color, fadeOut, Time.deltaTime * 2.5f);

            if (playSound == true)
            {
                audioSource.Play();
                playSound = false;
            }
                    
            if (activeTimer > actionTime + 1.0f)
            {
                GameObject.Destroy(textMesh[0].gameObject);
                GameObject.Destroy(spriteRenderers[2].gameObject);
                GameObject.Destroy(gameObject);
            }
        }
        else if (gameObject.name == "Voltar" && activated == true)
        {
            audioSource.Play();
            SceneManager.LoadScene("Menu");
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