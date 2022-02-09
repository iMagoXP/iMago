using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR.Cardboard;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class VRSwitch : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");

        Debug.Log("Deinitializing XR...");
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
