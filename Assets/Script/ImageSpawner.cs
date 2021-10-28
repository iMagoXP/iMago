using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSpawner : MonoBehaviour
{
    public GameObject CarrouselObject;
    public GameObject ImagePrefab;

    [SerializeField]
    private int rowCount;
    [SerializeField]
    private int rotatedRows;
    [SerializeField]
    private float rowHeightDropOffset;

    [SerializeField]
    private float initalSpawnCooldown;
    [SerializeField]
    private float targetSpawnCooldown;
    private float spawnCooldown;
    private float spawnTimer;
    [SerializeField]
    private float targetLifetime;
    private float curLifetime;

    private Object[] textures;

    // Start is called before the first frame update
    void Start()
    {
        textures = LoadTextures();
        SetTimers();
    }

    Object[] LoadTextures()
    {
        Object[] tex = Resources.LoadAll("Texture");

        if (tex == null)
        {
            tex = new Object[1];
            tex[0] = new Texture2D(64, 64);
        }

        return tex;
    }

    void SetTimers()
    {
        spawnCooldown = initalSpawnCooldown;
        spawnTimer = spawnCooldown;
        curLifetime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        curLifetime += Time.deltaTime;

        if (spawnTimer >= spawnCooldown)
        {
            SpawnImage();
            spawnTimer -= spawnCooldown;
        }

        float completeness = curLifetime / targetLifetime;
        spawnCooldown = GetCurrentCooldown(completeness);
    }

    float GetCurrentCooldown(float completeness)
    {
        return Mathf.Lerp(initalSpawnCooldown, targetSpawnCooldown, completeness);
    }

    void SpawnImage()
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

    int GetSpawnRow()
    {
        return Random.Range(-rowCount, rowCount + 1);
    }

    Vector3 GetSpawnPosition(int row)
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

    Quaternion GetSpawnRotation(int row)
    {
        Vector3 lookDirection = (Mathf.Abs(row) < rotatedRows)
            ? new Vector3(1.0f, 0.0f, 0.0f)
            : new Vector3(0.0f, 0.0f, 1.0f);

        return Quaternion.LookRotation(
            lookDirection,
            new Vector3(0.0f, -1.0f, 0.0f)
        );
    }

    void SetChildSize(GameObject child)
    {
        float scale = Random.Range(0.5f, 2.0f);
        child.transform.localScale *= scale;
    }

    void SetChildTexture(GameObject child)
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