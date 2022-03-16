using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRecycler : MonoBehaviour
{
    private float startY;
    private Quaternion initialRotation;
    private ImageSpawner[] scriptsImageSpawner = new ImageSpawner[3];
    private Material mats;
    private Texture2D tex;
    private Vector3 initialPosition;
    private GameObject spawners;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        spawners = GameObject.Find("ImageSpawners");
        scriptsImageSpawner[0] = spawners.transform.GetChild(0).GetComponent<ImageSpawner>();
        scriptsImageSpawner[1] = spawners.transform.GetChild(1).GetComponent<ImageSpawner>();
        scriptsImageSpawner[2] = spawners.transform.GetChild(2).GetComponent<ImageSpawner>();
        tex = scriptsImageSpawner[0].GetTexture();
    }

    public void Update()
    {
        if (initialPosition.y > GetPositionY())
        {
            RecycleImage();
            scriptsImageSpawner[0].stopSpawning = true;
            scriptsImageSpawner[1].stopSpawning = true;
            scriptsImageSpawner[2].stopSpawning = true;
        }
        transform.rotation = initialRotation;
    }

    public virtual float GetPositionY()
    {
        return transform.position.y;
    }

    public virtual void RecycleImage()
    {
        Material mats = gameObject.transform.GetChild(0).GetComponent<Renderer>().material;
        mats.SetTexture("_MainTex", tex);
        mats = gameObject.transform.GetChild(1).GetComponent<Renderer>().material;
        mats.SetTexture("_MainTex", tex);
        transform.position = initialPosition;
    }
}