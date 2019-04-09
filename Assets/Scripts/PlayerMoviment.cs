using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    float xMin, xMax, yMin, yMax;
}
public class PlayerMoviment : MonoBehaviour
{

    public Boundary boundary;
    public Rigidbody2D rb;
    public float speed;
    public float xMin, xMax, yMin, yMax;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moverHorizontal, moverVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector2(
            Mathf.Clamp(rb.position.x, xMin, xMax),

         
            Mathf.Clamp(rb.position.y, yMin, yMax)
            );
        
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
        
}

