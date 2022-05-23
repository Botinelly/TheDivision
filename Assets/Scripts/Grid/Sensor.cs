using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {

    void OnTriggerStay2D(Collider2D collision)
    {
        //GetComponentInParent<Grid>().SpawnGrid(name);
        print("colliding " + Random.Range(0f,1f));
    }

}
