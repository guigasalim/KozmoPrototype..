using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour

    

{
   
    private Vector3 originalPosition;
    
    public float period = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        
        InvokeRepeating("shakeShake", 2.0f, 2.0f);



    }

    void shakeShake()
    {
        StartCoroutine(Shake(.2f,.4f));
        GetComponent<AudioSource>().Play();

    }

    IEnumerator Shake (float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            

            transform.localPosition = new Vector3(x, originalPosition.y, originalPosition.z);
            
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
    // Update is called once per frame
    void Update()

    {

     

       
    }
}
