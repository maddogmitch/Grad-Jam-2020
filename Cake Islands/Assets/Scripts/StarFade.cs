using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarFade : MonoBehaviour
{
     [SerializeField] float currentTime;
     [SerializeField] float startingTime; 
     
    // [SerializeField] float fadeOutTime;
    // [SerializeField] float fadeInTime;

     [SerializeField] CanvasGroup uiElement;
    
    //Timer https://www.youtube.com/watch?v=o0j7PdU88a4

     private void Start()
     {
         currentTime = startingTime; //Getting time

     }

     private void Update()
     {
         currentTime -= 1 * Time.deltaTime; //decrease time by 1
       //  Debug.Log(currentTime);
        
        
         if (currentTime <= 0) //When time less then 0 /fadeOutTime reset time and start fade out
        {
            currentTime = startingTime;
            FadeOut();
         }

         if (currentTime <= 3) //when time is greater then 3 /fadeInTime fade in 
        {
            FadeIn();
        }
             

     }


    //Bellow script from https://www.youtube.com/watch?v=92Fz3BjjPL8 

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, .5f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0, .5f));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }

        print("done");
    }
}
