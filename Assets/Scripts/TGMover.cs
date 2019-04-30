
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class TGMover : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;
    public Rigidbody2D rb;
    
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    

    void FixedUpdate()
    {
        rb.position = new Vector2(
          Mathf.Clamp(rb.position.x, xMin, xMax),


          Mathf.Clamp(rb.position.y, yMin, yMax)
          );
       
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        if((transform.position.x <= -9)&& (transform.position.y <= -9))
        movementDirection = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)).normalized;
        if((transform.position.x >= 9) && (transform.position.y <= -9))
                movementDirection = new Vector2(Random.Range(-1.0f, 0.0f), Random.Range(0.0f, 1.0f)).normalized;
       else if ((transform.position.x <= -9) && (transform.position.y >= 9))
            movementDirection = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 0.0f)).normalized;
        else if ((transform.position.x >= 9) && (transform.position.y >= 9))
            movementDirection = new Vector2(Random.Range(-1.0f, 0.0f), Random.Range(-1.0f, 0.0f)).normalized;

        else if (transform.position.x <= -9)
            movementDirection = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        else if  (transform.position.y <= -9)
            movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f)).normalized;
        else if (transform.position.y >= 9)
            movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 0.0f)).normalized;
        else if (transform.position.x >= 9)
            movementDirection = new Vector2(Random.Range(-1.0f, 0.0f), Random.Range(-1.0f, 1.0f)).normalized;
        else
            movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }
    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));

    }
}
