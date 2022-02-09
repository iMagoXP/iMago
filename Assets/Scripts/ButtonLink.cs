using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLink : MonoBehaviour
{
    // Update is called once per frame
    public void OpenUrl()
    {
        Application.OpenURL("https://arvr.google.com/intl/pt-BR_pt/cardboard/manufacturers/");
    }
}
