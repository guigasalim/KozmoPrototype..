using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDown : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = transform.up * speed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
