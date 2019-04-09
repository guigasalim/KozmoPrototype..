using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject shot;
    public Vector3 shotValues;
    private Vector3 explosions;
    public int shotCount;
    public float shotSpawnWait;
    public float shotStartWait;
    public float shotWaveWait;
    public GameObject explosion;
    public Image hpBarBackground;
    public Image hpBarForeground;
    private float bossHP;
    private float bossMaxHP;
    private float time = 0.0f;
    public float period = 10f;

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

                Instantiate(shot, shotPosition, Quaternion.Euler(0.0f, 0.0f, Random.Range(225.0f, 135.0f)));
                yield return new WaitForSeconds(shotSpawnWait);
            }
            yield return new WaitForSeconds(shotWaveWait);
        }

    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Shot")
        {   
            Debug.Log("Shoted! HP: " + bossHP);
            bossHP -= 1;
            Destroy(other.gameObject);
            hpBarForeground.fillAmount = bossHP / bossMaxHP;

        }
        if (bossHP == 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        bossMaxHP = 180.0f;
        bossHP = 180.0f;
        
        StartCoroutine(shotWaves());

    }
    // Update is called once per frame
    void Update()

    {
        explosions = new Vector3(Random.Range(-4f, 4f), Random.Range(1.2f, 5.5f), 0.0f);
        if (bossHP/bossMaxHP <= 0.5)
        {
            if (Time.time > time)
            {
                time += period;
                Instantiate(explosion, explosions, transform.rotation);
            }

        }
            hpBarForeground.fillAmount = bossHP / bossMaxHP;
        AddjustCurrentHealth(0);


    }

    private void AddjustCurrentHealth(int adj)
    {
        bossHP += adj;
        if (bossHP < 0)
            bossHP = 0;

        if (bossHP > bossMaxHP)
            bossHP = bossMaxHP;
    }
}
