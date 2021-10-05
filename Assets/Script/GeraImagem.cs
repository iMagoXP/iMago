using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraImagem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cilindro;
    public GameObject Image;
    public int TimeSpawn;
    private float time;
    
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > TimeSpawn)
        {

            Instantiate(Image, transform.position, transform.rotation, Cilindro.transform);

            time = 0;
        }
    }

}
