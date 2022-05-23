using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public static List<Vector3> gridLocations = new List<Vector3>();

    public Sprite smooth;
    public Sprite sharp;
    public float maxCamSize = 15;

    private bool isInvisible = true;
    
    private Camera cam;
    private SpriteRenderer sr;

	void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        cam = Camera.main;
        
	}

    void Start()
    {
        gridLocations.Add(transform.position);
        Invoke("CheckForInvisibility", 2f);
    }

    void Update()
    {
		if(cam.orthographicSize > maxCamSize)
        {
            sr.sprite = smooth;
        }
        else
        {
            sr.sprite = sharp;
        }
	}

    void CheckForInvisibility()
    {
        if (isInvisible)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnGrid(Vector3 position)
    {
        while (true)
        {
            GridSpawner.Instance.SpawnGrids(position);
            yield return new WaitForSeconds(1f);
        }
    }

    void OnDestroy()
    {
        gridLocations.Remove(transform.position);
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);
        
    }

    void OnBecameVisible()
    {
        isInvisible = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(SpawnGrid(transform.position));
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopCoroutine(SpawnGrid(transform.position));
        }
    }


}
