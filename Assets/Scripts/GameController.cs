using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject cyberEnemy;
    public GameObject boss;
    public SpriteRenderer bossRenderer;
    public SpriteRenderer playerRenderer;
    
    public Color bossOriginalColor;
    public Color playerOriginalColor;
    
    private Color tmpBoss;
    private Color tmpPlayer;
    
    public bool hitPlayer = false;
    public bool hitBoss = false;
 

    
    
    public Image hpBarBackground;
    public Image hpBarForeground;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public bool EnableL;
    public bool EnableS;
    private Scene scene;
    public float shipHP;
    public float bossHP;
    public float bossDamage;
    public float spawnsHP;
    public float spawnsDamage;
    public GameObject explosion;
    public float bossMaxHP;
    private bool rage;
    public float rageSpeed;
    public float difficult;


    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(cyberEnemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

        }


    }
    // Start is called before the first frame update
    void Start()
    {
     bossOriginalColor= bossRenderer.material.color;
     playerOriginalColor =  playerRenderer.material.color;
     
        rageSpeed = 1 * difficult;
        hazardCount = Mathf.RoundToInt(hazardCount * rageSpeed);
        spawnWait = spawnWait / rageSpeed;
        startWait = startWait / rageSpeed;
        waveWait = waveWait / rageSpeed;
        rage = false;

        StartCoroutine(spawnWaves());
        StartCoroutine(flasher());
        scene = SceneManager.GetActiveScene();
        bossMaxHP = bossHP;

    }

    // Update is called once per frame
    void Update()
    {
        hpBarForeground.fillAmount = bossHP / bossMaxHP;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        AddjustCurrentHealth(0);
        if ((bossHP / bossMaxHP <= 0.5))
        {
            if (!rage)
            {
                rageSpeed = 4f;
                hazardCount = Mathf.RoundToInt(hazardCount * rageSpeed);
                spawnWait = spawnWait / rageSpeed;
                startWait = startWait / rageSpeed;
                waveWait = waveWait / rageSpeed;
                rage = true;
            }
        }



    }

    public void death(GameObject g)
    {
        Instantiate(explosion, g.transform.position, g.transform.rotation);
        Destroy(g);

    }
    private void AddjustCurrentHealth(int adj)
    {
        bossHP += adj;

        if (bossHP < 0)
            bossHP = 0;

        if (bossHP > bossMaxHP)
            bossHP = bossMaxHP;



   
    }
    IEnumerator flasher()
    {
        while (true)
        {
            if ((hitPlayer)&& (playerRenderer!=null))
            {
                tmpPlayer = playerRenderer.material.color;
                tmpPlayer.a = 0f;
                playerRenderer.material.color = tmpPlayer;
                yield return new WaitForSeconds(.05f);

                playerRenderer.material.color = playerOriginalColor;
               
                yield return new WaitForSeconds(.05f);
                hitPlayer = false;

            }
            if ((hitBoss)&&(bossRenderer != null))
            {
                if ((bossHP / bossMaxHP >= 0.5))
                {
                    bossRenderer.material.color = Color.blue;
                   
                    
                    yield return new WaitForSeconds(.05f);


                    bossRenderer.material.color = bossOriginalColor;
                    
                    yield return new WaitForSeconds(.05f);

                }

                if ((bossHP / bossMaxHP <= 0.5))
                {
                    bossRenderer.material.color = Color.red;
                    yield return new WaitForSeconds(.05f);
                    
                    bossRenderer.material.color = bossOriginalColor;
                    yield return new WaitForSeconds(.05f);

                }
                hitBoss = false;

            }

            yield return new WaitForSeconds(.05f);

        }




    }

}
    
