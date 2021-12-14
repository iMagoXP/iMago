using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeState()
    {
        Debug.Log("Clicou");

        if(gameObject.tag == "Direita")
        {
            animator.SetBool("Direita", true);
            animator.SetBool("Esquerda", false);
        }
        else if(gameObject.tag == "Esquerda")
        {
            animator.SetBool("Esquerda", true);
            animator.SetBool("Direita", false);
        }
    }
}
