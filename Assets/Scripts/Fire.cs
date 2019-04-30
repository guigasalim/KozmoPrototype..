using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    public GameObject player;
    private Vector3 playerPosition;
    private Vector3 dis;
    private float angle;
    



    void Start()
    {
        
        InvokeRepeating("FireShot", delay, fireRate);
        player = GameObject.Find("PlayerShip");
        playerPosition = player.transform.position;
    }

    void FireShot()
    {
        dis = shotSpawn.position - playerPosition;
        var angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
        Instantiate(shot, shotSpawn.position, Quaternion.Euler(0.0f, 0.0f, angle + 90));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
