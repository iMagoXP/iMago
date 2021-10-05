using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaredPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int DistMax, DistMin, MultTam;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform, new Vector3(0,1,0));
    }
}
