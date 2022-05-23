using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public static int currentNumberOfBalls = 0;
    

    void Start()
    {

        // SetRandomColor();
        currentNumberOfBalls++;
        

    }

    void SetRandomColor()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        GetComponent<SpriteRenderer>().color = new Color(r, g, b, 1);
       
    }

    void OnDestroy()
    {
        currentNumberOfBalls--;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject, 10f);
    }




}
