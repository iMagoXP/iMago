using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSpawner : MonoBehaviour
{
    public GameObject CarrouselObject;
    public GameObject ImagePrefab;

    [SerializeField]
    protected int rowCount = 7;
    [SerializeField]
    protected int rotatedRows = 3;
    [SerializeField]
    protected float rowHeightDropOffset = 0.016f;

    protected float spawnTimer;

    [SerializeField]
    protected float baseImagesPerSecond;
    protected float imagesPerSecond;
    [SerializeField]
    protected float imagesPerSecondIncrement;

    [SerializeField]
    protected float imageLevelCooldown;
    protected float imageLevelTimer;

    protected float[] images_scales;

    protected TextureLoaderInterface textureLoader = new TextureLoader();
    protected Object[] textures;

    void Start()
    {
        textures = LoadTextures();
        SetTimers();
        images_scales = new float[5];
        images_scales[0] = 2.5f;
        images_scales[1] = 5.0f;
        images_scales[2] = 10.0f;
        images_scales[3] = 25.0f;
        images_scales[4] = 50.0f;
    }

    public Object[] LoadTextures()
    {
        Object[] tex = textureLoader.LoadTextures();

        if (tex == null)
        {
            tex = new Object[1];
            tex[0] = new Texture2D(64, 64);
        }

        return tex;
    }

    public void SetTimers()
    {
        imagesPerSecond = baseImagesPerSecond;
        spawnTimer = GetSpawnCooldown();
    }

    public void Update()
    {
        float dt = GetDeltaTime();
        spawnTimer += dt;
        imageLevelTimer += dt;

        UpdateImageLevel();

        if (spawnTimer >= GetSpawnCooldown())
        {
            SpawnImage();
            spawnTimer -= GetSpawnCooldown();
        }
    }

    public virtual float GetDeltaTime()
    {
        return Time.deltaTime;
    }

    public virtual float GetSpawnCooldown()
    {
        return 1 / imagesPerSecond;
    }

    public void UpdateImageLevel()
    {
        if (imageLevelTimer >= imageLevelCooldown)
        {
            imageLevelTimer = 0;
            imagesPerSecond += imagesPerSecondIncrement;
        }
    }


    public virtual void SpawnImage()
    {
        int row = GetSpawnRow();
        Vector3 spawnPosition = GetSpawnPosition(row);
        Quaternion spawnRotation = GetSpawnRotation(row);

        GameObject image = Instantiate(
            ImagePrefab,
            spawnPosition,
            spawnRotation,
            CarrouselObject.transform
        );
        SetChildSize(image);
        SetChildTexture(image);
    }

    public int GetSpawnRow()
    {
        return Random.Range(-rowCount, rowCount + 1);
    }

    public Vector3 GetSpawnPosition(int row)
    {
        Vector3 pos = transform.position;
        pos.z += row * 2;
        // pos.y -= Mathf.Abs(row) * row * row * rowHeightDropOffset;

        if (Mathf.Abs(row) >= rotatedRows)
        {
            pos.z += Random.Range(-1.0f, 1.0f);
            pos.y += Random.Range(-0.5f, 0.5f);
        }

        return pos;
    }

    public Quaternion GetSpawnRotation(int row)
    {
        Vector3 lookDirection = new Vector3(
            -transform.position.y,
            transform.position.x,
            -transform.position.z
        );

        return Quaternion.LookRotation(
            lookDirection,
            new Vector3(0.0f, 1.0f, 0.0f)
        );
    }

    public virtual void SetChildSize(GameObject child)
    {
        int index = Random.Range(0, images_scales.Length);
        child.transform.localScale *= index;
    }

    public void SetChildTexture(GameObject child)
    {
        Texture2D tex = (Texture2D)textures[Random.Range(0, textures.Length)];

        Material mats = child.GetComponent<Renderer>().material;
        mats.SetTexture("_MainTex", tex);
        mats = child.transform.GetChild(0).GetComponent<Renderer>().material;
        mats.SetTexture("_MainTex", tex);
        mats = child.transform.GetChild(1).GetComponent<Renderer>().material;
        mats.SetTexture("_MainTex", tex);
    }
}