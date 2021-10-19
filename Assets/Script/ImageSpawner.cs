using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cylinder;
    public GameObject Image;
    public int SpawnCooldown;
    private float spawnTimer;
    
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > SpawnCooldown)
        {
            Quaternion initialRotation = transform.rotation;
            initialRotation.SetLookRotation(
                new Vector3(1.0f, 0.0f, 0.0f),
                new Vector3(0.0f, -1.0f, 0.0f)
            );

            Instantiate(Image, transform.position, initialRotation, Cylinder.transform);
            spawnTimer -= SpawnCooldown;
        }
    }

}
