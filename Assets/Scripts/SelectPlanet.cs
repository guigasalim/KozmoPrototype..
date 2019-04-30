using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPlanet : MonoBehaviour
{
    
    public GameObject shine;
    public Renderer shiny;
    Color color;
    public Text anyText;
    
    // Start is called before the first frame update
    void Start()
    {
        
        shiny = shine.GetComponent<Renderer>();
        color = shiny.material.color;
        color.a = 0f;
        shiny.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        StartCoroutine(FadeCanvasGroup(shiny, shiny.material.color.a, 1, .5f));
        anyText.text = shine.name;
    }

    // ...the red fades out to cyan as the mouse is held over...
    void OnMouseDown()
    {
        if (shine.name == "Cyber Network") SceneManager.LoadScene("Main");
        // load a new scene
        if (shine.name == "Lost World") SceneManager.LoadScene("Main2");
        if (shine.name == "Stardust Junktown") SceneManager.LoadScene("Main3");
        
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        StartCoroutine(FadeCanvasGroup(shiny, shiny.material.color.a, 0, .5f));
    }


    public IEnumerator FadeCanvasGroup(Renderer cg, float start, float end, float lerpTime = 1)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);
            color = shiny.material.color;
            color.a = currentValue;
            shiny.material.color = color;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }

        
    }
}
