using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    
    public int numberPlanets;
    public GameObject[] planets;
    public int levelpassed;
    // Start is called before the first frame update
    void Start()
    {
        levelpassed = PlayerPrefs.GetInt("LevelPassed");
        
       
        for(int i =1; i < numberPlanets; i++)
        {
            Debug.Log(planets[i].name);
            planets[i].SetActive(false);
        }

        for (int j = 1 ; j <= (levelpassed -1); j++)
        {
            Debug.Log(planets[j].name);
            planets[j].SetActive(true);
        }
        PlayerPrefs.SetInt("NumberPlanets", numberPlanets);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
