using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BlazarController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject shot;
    public Vector3 shotValues;
    private Vector3 explosions;
    public int shotCount;
    public float shotSpawnWait;
    public float shotStartWait;
    public float shotWaveWait;
    private bool switchhands = true;
    public GameObject explosion;
    public GameObject player;
    public Image hpBarBackground;
    public Image hpBarForeground;
    private bool rage;
    private float time = 0.1f;
    public float period = 10f;
    private Vector3 playerPosition;
    private Vector3 dis;
    private float angle;
    public GameController gameController;
    // Start is called before the first frame update
    IEnumerator shotWaves()
    {
        yield return new WaitForSeconds(shotStartWait);

        while (true)
        {

            for (int i = 0; i < shotCount; i++)
            {

                Vector3 shotPosition = new Vector3(shotValues.x, shotValues.y, shotValues.z);
                Quaternion shotRotation = Quaternion.identity;
                dis = shotPosition - playerPosition;
                var angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;


                Instantiate(shot, shotPosition, Quaternion.Euler(0.0f, 0.0f, angle + 90));
                yield return new WaitForSeconds(shotSpawnWait);
            }
            yield return new WaitForSeconds(shotWaveWait);
            switchhands = (Random.value > 0.5f);



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
        shotCount = Mathf.RoundToInt(shotCount * gameController.rageSpeed);
        shotSpawnWait = shotSpawnWait / gameController.rageSpeed;
        shotStartWait = shotStartWait / gameController.rageSpeed;
        shotWaveWait = shotWaveWait / gameController.rageSpeed;
        rage = false;
        StartCoroutine(shotWaves());
        playerPosition = player.transform.position;


    }
    // Update is called once per frame
    void Update()

    {
        if (player != null)
            playerPosition = player.transform.position;


        explosions = new Vector3(Random.Range(-4f, 4f), Random.Range(1.2f, 5.5f), 0.0f);
        if (gameController.bossHP / gameController.bossMaxHP <= 0.5)
        {
            if (Time.time > time)
            {
                time += period;
                Instantiate(explosion, explosions, transform.rotation);
            }

        }
        if ((gameController.bossHP / gameController.bossMaxHP <= 0.49) && (gameController.bossHP / gameController.bossMaxHP >= 0.31))
        {
            if (!rage)
            {

                shotCount = Mathf.RoundToInt(shotCount * (gameController.rageSpeed / 3));
                shotSpawnWait = shotSpawnWait / (gameController.rageSpeed / 3);
                shotStartWait = shotStartWait / (gameController.rageSpeed / 3);
                shotWaveWait = shotWaveWait / (gameController.rageSpeed / 3);
                rage = true;

            }



        }


    }
}
