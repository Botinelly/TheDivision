using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform player;

    public MovementJoystick movementJoystick;
    public float speed = 10;
    private Rigidbody2D rb;

    // -----------------------

    // public float speed = 30;
    public Camera cam;

    private bool isCameraChanging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
   
	}

    void FixedUpdate()
    {
        if (ScoreManager.cromossomos > 1 && ScoreManager.cromossomos2 > 1 && ScoreManager.fusos > 1){
            ScoreManager.activateButton();
        }
        if(movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * speed, movementJoystick.joystickVec.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void moveCharacter(Vector2 direction){
        player.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cromossomo1")
        {
            // ConsumeBall();
            ScoreManager.IncrementCromo();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Cromossomo2")
        {
            // ConsumeBall();
            ScoreManager.IncrementCromo2();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Fuso")
        {
            // ConsumeBall();
            ScoreManager.IncrementFuso();
            Destroy(collision.gameObject);
        }

    }

    void ConsumeBall()
    {
        
        transform.localScale = new Vector3(transform.localScale.x + .1f, transform.localScale.y + .1f, 1);
        rb.mass += .01f;
        
        if((ScoreManager.GetScore() + 1) % 100  == 0)
        {
            if (!isCameraChanging)
            {
                StartCoroutine(ChangeCameraSize(cam.orthographicSize + 5f));
                isCameraChanging = true;
            }
        }
        else
        {
            //cam.orthographicSize += .1f;
        }

    }

    IEnumerator ChangeCameraSize(float targetSize)
    {
        

        while(cam.orthographicSize < targetSize)
        {
            cam.orthographicSize += Time.deltaTime;
            yield return null;
        }
      
        isCameraChanging = false;
        yield return null;
        
    }

    void MovePlayer()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
       

        Vector3 pos = Input.mousePosition;
        Vector3 convertedPos = cam.ScreenToWorldPoint(pos);

        Vector3 vel = convertedPos - transform.position;
        
        

        /*
        if(convertedPos.x > transform.position.x)
        {
            moveHorizontal = 1;
        }
        else
        {
            moveHorizontal = -1;
        }

        if(convertedPos.y > transform.position.y)
        {
            moveVertical = 1;
        }
        else
        {
            moveVertical = -1;
        }*/

        float moveHorizontal = vel.x;
        float moveVertical = vel.y;
        


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
        
    }
}
