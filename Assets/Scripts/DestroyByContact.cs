using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour

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
        spawnHP = gameController.spawnsHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Boundary")
        {
            return;

        }
        if ((other.tag == "Boss")|| (other.tag == "Hazard") || (other.tag == "EnemyShot") || (other.tag == "Field")) return;
        if (other.tag == "Player")
        {
            Debug.Log("Shots on: " + other.tag);
            Debug.Log("Ship HP: " + gameController.shipHP);

            gameController.hitPlayer = true;


            gameController.shipHP -= gameController.spawnsDamage;
            

            if (gameController.shipHP <= 0)
            {
                gameController.death(other.gameObject);
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");

            }
            gameController.death(gameObject);
            Destroy(gameObject);


        }
        if ((other.tag == "Shot"))
        {

            

            spawnHP -= 1;
            Destroy(other.gameObject);
            if (spawnHP <= 0) gameController.death(gameObject);
            gameController.death(gameObject);
            Destroy(gameObject);

        }
        

    }

   
}
