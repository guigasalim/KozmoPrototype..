using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelControlScript : MonoBehaviour
{
    public static LevelControlScript instance = null;
  
     
    private GameObject levelsign;
    int sceneIndex, levelPassed, numberPlanets;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        numberPlanets = PlayerPrefs.GetInt("NumberPlanets");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void youWin()
    {
        if (sceneIndex == numberPlanets)
        {
            SceneManager.LoadScene("Gameover");
        }
        if (levelPassed < sceneIndex)
        {
            PlayerPrefs.SetInt("LevelPassed", sceneIndex);
            SceneManager.LoadScene("Victory");
        }

    }
}
