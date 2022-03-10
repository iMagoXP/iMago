using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Google.XR.Cardboard;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class OrientationController : MonoBehaviour
{
    private Scene scene;
    private float dt;
    private bool vrOn;

    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        dt = 0.0f;
        vrOn = false;

        if (scene.name == "Explanation" || scene.name == "Interface")
        {
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else if (scene.name == "Instagram")
        {
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }

    private void Update()
    {
        dt += Time.deltaTime;
        if (scene.name == "Instagram" && dt > 2.0f && vrOn == false) StartVR();
    }

    IEnumerator EnterVr()
    {
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.Log("Initializing XR Failed.");
        }
        else
        {
            XRGeneralSettings.Instance.Manager.StartSubsystems();
        }
    }
    
    public void StartVR()
    {
        StartCoroutine(EnterVr());
        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }
    }
}
