using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR.Cardboard;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class VROn : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator EnterVr()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR initialized.");

            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");
        }
    }

    // Update is called once per frame
    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        StartCoroutine(EnterVr());
        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }
    }
}
