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
    private TextMesh textMesh;
    private GameObject spawners;
    private GameObject carrousel;

    void Start()
    {
        spriteRenderers = gameObject.transform.parent.gameObject.GetComponentsInChildren<SpriteRenderer>();
        textMesh = gameObject.transform.parent.gameObject.GetComponentInChildren<TextMesh>();
        spawners = GameObject.FindGameObjectWithTag("ImageSpawners");
        carrousel = GameObject.FindGameObjectWithTag("Carrousel");
        gazedAt = false;
    }

    void Update()
    {
        if (gazedAt == true)
        {
            if (gameObject.name == "Entrar !") spriteRenderers[0].color = Color.Lerp(spriteRenderers[0].color, new Color(255, 255, 255, 1), Time.deltaTime * 1.5f);
            else if (gameObject.name == "Voltar") spriteRenderers[2].color = Color.Lerp(spriteRenderers[2].color, new Color(255, 255, 255, 1), Time.deltaTime * 1.5f);

            timer += Time.deltaTime;

            if (timer > actionTime)
            {
                if (gameObject.name == "Entrar !")
                {
                    foreach (Transform child in spawners.transform)
                    {
                        child.gameObject.SetActive(true);
                    }
                    CarrouselRotator rotator = carrousel.GetComponent<CarrouselRotator>();
                    rotator.DegreesPerSecond = 2;
                    GameObject.Destroy(textMesh.gameObject);
                    GameObject.Destroy(spriteRenderers[2].gameObject);
                    GameObject.Destroy(gameObject);
                }
                else if (gameObject.name == "Voltar")
                {
                    SceneManager.LoadScene("Explanation");
                }
            }
        }
        else if (gazedAt == false)
        {
            if (gameObject.name == "Entrar !") spriteRenderers[0].color = Color.Lerp(spriteRenderers[0].color, new Color(255, 255, 255, 0.3f), Time.deltaTime * 6.0f);
            else if (gameObject.name == "Voltar") spriteRenderers[2].color = Color.Lerp(spriteRenderers[2].color, new Color(255, 255, 255, 0.3f), Time.deltaTime * 6.0f);
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