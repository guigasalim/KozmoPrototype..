using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroyObjectBossShot : MonoBehaviour
{
    public GameObject explosion;
    public GameController gameController;
    private bool win = true;

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
        if ((other.tag == "Hazard")|| (other.tag == "Boss") || (other.tag == "Shot") || (other.tag == "EnemyShot")) return;
        if (other.tag == "Player")
        {
            gameController.hitPlayer = true;
            
            
            
            gameController.shipHP -= gameController.bossDamage;
           


            if (gameController.shipHP <= 0)
            {
                gameController.death(other.gameObject);
                Destroy(gameObject);

                InvokeRepeating("gameover", 10f,10f);
                SceneManager.LoadScene("GameOver");
            }

        }

        Destroy(gameObject);

    }

    void gameover()

    {
        if (win) { 
            SceneManager.LoadScene("GameOver");
            win = false;
        }
    }

   
}
