using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class LaggiaOtherHazards : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject tyrano;
    public GameObject grass;


    public Vector3 spawnValues;
    public Vector3 spawn2Values;
    public Vector3 spawnTyranoValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private Vector3 spawnTyranoPosition;
    

   
    private bool switchsides;

    public int hazardTyranoCount;
    public float spawnTyranoWait;
    public float startTyranoWait;
    public float waveTyranoWait;



    public float spawnsHP;
    public float spawnsDamage;
    public GameObject explosion;
    public GameController gameController;



    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        switchsides = (Random.value > 0.5f);
        while (true)
        {
            if (switchsides)
            {
                for (int i = 0; i < hazardCount; i++)

                {
                    Vector3 spawnPosition = new Vector3(spawn2Values.x, Random.Range(-3.15f, -4f), spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;

                    Instantiate(fireBall, spawnPosition, Quaternion.Euler(0.0f, 0.0f, 90.0f));
                    Debug.Log(switchsides);
                    yield return new WaitForSeconds(spawnWait);
                }
                
                yield return new WaitForSeconds(waveWait);
                switchsides = (Random.value > 0.5f);

            }

            else if (!switchsides)
            {


                for (int i = 0; i < hazardCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-8.15f, -9f), spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;

                    Instantiate(fireBall, spawnPosition, Quaternion.Euler(0.0f, 0.0f, 270.0f));
                    Debug.Log(switchsides);
                    yield return new WaitForSeconds(spawnWait);
                }
                
                yield return new WaitForSeconds(waveWait);
                switchsides = (Random.value > 0.5f);


            }
            

        }


    }


  
    IEnumerator spawnTyranoWaves()
    {
        yield return new WaitForSeconds(startTyranoWait);
        while (true)
        {
            for (int i = 0; i < hazardTyranoCount; i++)
            {
                
                spawnTyranoPosition = new Vector3(Random.Range(-7.1f, 7.71f), spawnTyranoValues.y, spawnTyranoValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                
                
                InvokeRepeating("Grassiling", 2f, 0.05f);
                yield return new WaitForSeconds(4f);
                CancelInvoke();





                Instantiate(tyrano, spawnTyranoPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

        }


    }
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
        hazardCount = Mathf.RoundToInt(hazardCount * gameController.rageSpeed);
        spawnWait = spawnWait / gameController.rageSpeed;
        startWait = startWait / gameController.rageSpeed;
        waveWait = waveWait / gameController.rageSpeed;

       

        spawnTyranoWait = spawnTyranoWait / gameController.rageSpeed;
        startTyranoWait = startTyranoWait / gameController.rageSpeed;
        waveTyranoWait = waveTyranoWait / gameController.rageSpeed;




        StartCoroutine(spawnWaves());
       
        StartCoroutine(spawnTyranoWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Grassiling()
    {
        Instantiate(grass, new Vector3(Random.Range(spawnTyranoPosition.x + 3f, spawnTyranoPosition.x - 3f), Random.Range(spawnTyranoPosition.y - 1.5f, spawnTyranoPosition.y + 1.5f), spawnTyranoPosition.z), Quaternion.identity);
    }
}

    
