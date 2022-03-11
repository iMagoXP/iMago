using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRButtonController : MonoBehaviour
{
    bool gazedAt = false;
    float timer = 0.0f;
    [SerializeField]
    float actionTime;
    private Animator animator;
    private SpriteRenderer[] spriteRenderers;
    private TextMesh[] textMesh;
    private GameObject spawners;
    private GameObject carrousel;
    private AudioSource audioSource;
    private bool activated;

    void Start()
    {
        spriteRenderers = gameObject.transform.parent.gameObject.GetComponentsInChildren<SpriteRenderer>();
        textMesh = gameObject.transform.parent.gameObject.GetComponentsInChildren<TextMesh>();
        spawners = GameObject.FindGameObjectWithTag("ImageSpawners");
        carrousel = GameObject.FindGameObjectWithTag("Carrousel");
        audioSource = gameObject.GetComponent<AudioSource>();
        gazedAt = false;
        activated = false;
    }

    void Update()
    {
        if (gazedAt == true)
        {
            if (gameObject.name == "Entrar !" && activated == false) spriteRenderers[0].color = Color.Lerp(spriteRenderers[0].color, new Color(255, 255, 255, 1), Time.deltaTime * 2.5f);
            else if (gameObject.name == "Voltar" && activated == false) spriteRenderers[2].color = Color.Lerp(spriteRenderers[2].color, new Color(255, 255, 255, 1), Time.deltaTime * 2.5f);

            timer += Time.deltaTime;

            if (timer > actionTime)
            {
                activated = true;
                if (gameObject.name == "Entrar !")
                {
                    foreach (Transform child in spawners.transform)
                    {
                        child.gameObject.SetActive(true);
                    }
                    CarrouselRotator rotator = carrousel.GetComponent<CarrouselRotator>();
                    rotator.DegreesPerSecond = 1.2f;

                    Color.Lerp(spriteRenderers[0].color, new Color(255, 255, 255, 0), Time.deltaTime * 2.5f);
                    Color.Lerp(spriteRenderers[1].color, new Color(255, 255, 255, 0), Time.deltaTime * 2.5f);
                    Color.Lerp(spriteRenderers[2].color, new Color(255, 255, 255, 0), Time.deltaTime * 2.5f);
                    Color.Lerp(spriteRenderers[3].color, new Color(255, 255, 255, 0), Time.deltaTime * 2.5f);
                    Color.Lerp(textMesh[0].color, new Color(255, 255, 255, 0), Time.deltaTime * 2.5f);
                    Color.Lerp(textMesh[1].color, new Color(255, 255, 255, 0), Time.deltaTime * 2.5f);
                    Color.Lerp(textMesh[2].color, new Color(255, 255, 255, 0), Time.deltaTime * 2.5f);
                    
                    if(timer > actionTime + 0.5f && timer < actionTime + 0.6f)   audioSource.Play();
                    
                    if (timer > actionTime + 2.5f)
                    {
                        GameObject.Destroy(textMesh[0].gameObject);
                        GameObject.Destroy(spriteRenderers[2].gameObject);
                        GameObject.Destroy(gameObject);
                    }
                }
                else if (gameObject.name == "Voltar")
                {
                    audioSource.Play();
                    SceneManager.LoadScene("Interface");
                }
            }
        }
        else if (gazedAt == false)
        {
            if (gameObject.name == "Entrar !") spriteRenderers[0].color = Color.Lerp(spriteRenderers[0].color, new Color(255, 255, 255, 0.3f), Time.deltaTime * 2.5f);
            else if (gameObject.name == "Voltar") spriteRenderers[2].color = Color.Lerp(spriteRenderers[2].color, new Color(255, 255, 255, 0.3f), Time.deltaTime * 2.5f);
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