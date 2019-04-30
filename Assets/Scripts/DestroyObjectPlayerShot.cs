using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObjectPlayerShot : MonoBehaviour
{
    public GameObject explosion;
    public GameController gameController;
    private bool flash;
  
    
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
        if ((other.tag == "Player")|| (other.tag == "Shot") || (other.tag == "EnemyShot") || (other.tag == "Field")) return;
        if (other.tag == "Boss")
        {
            gameController.hitBoss = true;
            


            

            gameController.bossHP -= 1;
            gameController.hpBarForeground.fillAmount = gameController.bossHP / gameController.bossMaxHP;

            if (gameController.bossHP <= 0)
            {
                gameController.death(other.gameObject);

                LevelControlScript.instance.youWin ();
            }
            Destroy(gameObject);
        }

        
        
    }

  
}
