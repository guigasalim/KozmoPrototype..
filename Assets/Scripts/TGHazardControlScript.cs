using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGHazardControlScript : MonoBehaviour
{
    public GameObject tgStar;
    public GameObject tgTrid;
    public Vector3 spawnValues;
    
    public int spawnCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Vector3 spawn2Values;

    public int spawn2Count;
    public float spawn2Wait;
    public float start2Wait;
    public float wave2Wait;

    public GameController gameController;

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {

            for (int i = 0; i < spawnCount; i++)
            {
                
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Debug.Log("funcionou :" + spawnPosition);



                Instantiate(tgStar, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            



        }
    }


    IEnumerator spawn2Waves()
    {
        yield return new WaitForSeconds(start2Wait);

        while (true)
        {

            for (int i = 0; i < spawn2Count; i++)
            {

                Vector3 spawn2Position = new Vector3(spawn2Values.x, Random.Range(-spawn2Values.y, spawn2Values.y), spawn2Values.z);
                Quaternion spawn2Rotation = Quaternion.identity;
                Debug.Log("funcionou :" + spawn2Position);



                Instantiate(tgTrid, spawn2Position, spawn2Rotation);
                yield return new WaitForSeconds(spawn2Wait);
            }
            yield return new WaitForSeconds(wave2Wait);




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
        spawnCount = Mathf.RoundToInt(spawnCount * gameController.rageSpeed);
        spawnWait = spawnWait / gameController.rageSpeed;
        startWait = startWait / gameController.rageSpeed;
        waveWait = waveWait / gameController.rageSpeed;
        StartCoroutine(spawnWaves());

        spawn2Count = Mathf.RoundToInt(spawn2Count * gameController.rageSpeed);
        spawn2Wait = spawn2Wait / gameController.rageSpeed;
        start2Wait = start2Wait / gameController.rageSpeed;
        wave2Wait = wave2Wait / gameController.rageSpeed;
        StartCoroutine(spawn2Waves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
