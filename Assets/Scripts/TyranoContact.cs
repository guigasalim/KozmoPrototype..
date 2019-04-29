using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class TyranoContact : MonoBehaviour
{
    public GameObject explosion;
    public GameController gameController;
    private float spawnHP;

    // Start is called before the first frame update
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
        spawnHP = 6;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Boundary")
        {
            return;

        }
        if ((other.tag == "Boss") || (other.tag == "Hazard") || (other.tag == "EnemyShot")) return;
        if (other.tag == "Player")
        {
            Debug.Log("Shots on: " + other.tag);
            Debug.Log("Ship HP: " + gameController.shipHP);

            gameController.shipHP -= gameController.shipHP;


            if (gameController.shipHP <= 0)
            {
                gameController.death(other.gameObject);
                
                SceneManager.LoadScene("GameOver");

            }



        }
        if ((other.tag == "Shot"))
        {
            spawnHP -= 1;

            if (spawnHP <= 0) gameController.death(gameObject);

        }
        
        

    }
}
