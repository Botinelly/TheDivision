using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float cameraSpeed = 5;

	void LateUpdate()
    {
        Vector2 newPosition = Vector2.Lerp(transform.position, player.transform.position, cameraSpeed * Time.deltaTime);
        //Vector2.SmoothDamp(transform.position, player.transform.position, )

        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
	}

    
}
