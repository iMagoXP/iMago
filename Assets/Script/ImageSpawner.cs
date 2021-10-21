using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Carrousel;
    public GameObject Image;

    [SerializeField]
    private int rowCount;
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

    void Start()
    {
        spawnCooldown = initalSpawnCooldown;
        spawnTimer = spawnCooldown;
        curLifetime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnCooldown)
        {
            Quaternion initialRotation = Quaternion.LookRotation(
                new Vector3(-1.0f, 0.0f, 0.0f),
                new Vector3(0.0f, -1.0f, 0.0f)
            );

            int row = Random.Range(-rowCount, rowCount + 1);
            Vector3 initialPosition = transform.position;
            initialPosition.z += row * 2;
            initialPosition.y += Mathf.Abs(row) * row * row * rowHeightDropOffset;

            GameObject child = Instantiate(Image, initialPosition, initialRotation, Carrousel.transform);
            float scale = Random.Range(0.5f, 2.0f);
            child.transform.localScale *= scale;

            spawnTimer -= spawnCooldown;
        }

        curLifetime += Time.deltaTime;
        float completeness = curLifetime / targetLifetime;
        spawnCooldown = Mathf.Lerp(initalSpawnCooldown, targetSpawnCooldown, completeness);
    }
}
