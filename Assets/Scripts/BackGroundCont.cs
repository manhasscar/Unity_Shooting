using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCont : MonoBehaviour
{
    
    public SpriteRenderer sprite;
    
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        

    }

    public void FadeInBG()
    {

        sprite.color = new Color(1, 1, 1, 0);
        StartCoroutine(Fadein());

        
    }

    public void FadeOutBG()
    {
        sprite.color = new Color(1, 1, 1, 1);
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadein()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.05f);
            sprite.color = new Color(1, 1, 1, fadeCount);
        } 
     }
    IEnumerator Fadeout()
    {
        float fadeCount = 1.0f;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.05f);
            sprite.color = new Color(1, 1, 1, fadeCount);
        }
    }
}
