using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour

{
    // Start is called before the first frame update
    public float HP;
    private float shipHP = 6;
    private float hits;
    private float hitsShip = 0;
    public GameObject explosion;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        hits = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.tag + "hits" + other.tag);
;        
        if ((other.tag == "Boundary") )
        {
            return;
        }
        if ((gameObject.tag == "Player") && (other.tag == "Shot") || (gameObject.tag == "Shot") && (other.tag == "Player")) return;
        if ((gameObject.tag == "Boss") && ((other.tag == "EnemyShot") || (other.tag == "Hazard")) || (other.tag == "Boss") && ((gameObject.tag == "EnemyShot") || (gameObject.tag == "Hazard"))) return;

        hits += 1;
        if (other.tag == "Player")
        {
            hitsShip += 1;
            if (hitsShip == shipHP)
            {
               
                Instantiate(explosion, transform.position, transform.rotation);
                
                Destroy(other.gameObject);

                gameController.GameOver();


            }

        }

        Destroy(other.gameObject);

        
        if (hits == HP)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            hits = 0;
            
        }
        
        
        
    }
}
