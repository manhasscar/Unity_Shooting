using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverCon : MonoBehaviour
{
    public SpriteRenderer sprite;



    // Start is called before the first frame update
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();


    }

    public void AppearBox()
    {

        sprite.color = new Color(1, 1, 1, 1);
        


    }

    public void DisAppearBox()
    {
        sprite.color = new Color(1, 1, 1, 0);
        
    }

    
}
