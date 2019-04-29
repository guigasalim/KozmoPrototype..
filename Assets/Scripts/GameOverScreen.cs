using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text AnyKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 2)
        {


            if (((int)(Time.timeSinceLevelLoad * 2)) % 2 == 0)
                AnyKey.gameObject.SetActive(true);
            else
                AnyKey.gameObject.SetActive(false);
        }

        if (Input.anyKey)
            SceneManager.LoadScene("Main");

    }
}

