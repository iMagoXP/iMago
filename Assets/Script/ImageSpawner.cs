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

    [SerializeField]
    protected float initalSpawnCooldown;
    [SerializeField]
    protected float targetSpawnCooldown;
    protected float spawnCooldown;
    protected float spawnTimer;
    [SerializeField]
    protected float targetLifetime;
    protected float curLifetime;

    protected TextureLoaderInterface textureLoader = new TextureLoader(); 
    protected Object[] textures;

    void Start()
    {
        textures = LoadTextures();
        SetTimers();
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
        spawnCooldown = initalSpawnCooldown;
        spawnTimer = spawnCooldown;
        curLifetime = 0;
    }

    public void Update()
    {
        float dt = getDeltaTime();
        spawnTimer += dt;
        curLifetime += dt;

        if (spawnTimer >= spawnCooldown)
        {
            SpawnImage();
            spawnTimer -= spawnCooldown;
        }

        float completeness = curLifetime / targetLifetime;
        spawnCooldown = GetCurrentCooldown(completeness);
    }

    public virtual float getDeltaTime() 
    {
        return Time.deltaTime;
    }

    public virtual float GetCurrentCooldown(float completeness)
    {
        return Mathf.Lerp(initalSpawnCooldown, targetSpawnCooldown, completeness);
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
        pos.y += Mathf.Abs(row) * row * row * rowHeightDropOffset;

        if (Mathf.Abs(row) >= rotatedRows)
        {
            pos.z += Random.Range(-1.0f, 1.0f);
            pos.y += Random.Range(-0.5f, 0.5f);
        }

        return pos;
    }

    public Quaternion GetSpawnRotation(int row)
    {
        Vector3 lookDirection = (Mathf.Abs(row) < rotatedRows)
            ? new Vector3(1.0f, 0.0f, 0.0f)
            : new Vector3(0.0f, 0.0f, 1.0f);

        return Quaternion.LookRotation(
            lookDirection,
            new Vector3(0.0f, -1.0f, 0.0f)
        );
    }

    public void SetChildSize(GameObject child)
    {
        float scale = Random.Range(0.5f, 2.0f);
        child.transform.localScale *= scale;
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