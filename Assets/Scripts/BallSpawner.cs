using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public int ballsToSpawnAtStart = 100;
    public int maxBallCount = 1000;
    public int spawnRate = 1;
    public float timeBetweenSpawns = 1;
    public float spawnDistance = 50.0f;
    public GameObject ball;
    public GameObject player;

	void Start()
    {
        SpawnBall(ballsToSpawnAtStart);
        StartCoroutine(SpawnBalls());
        
	}


    void SpawnBall(int number)
    {
        Vector2 playerPos = player.transform.position;
        float playerRadius = player.GetComponent<CircleCollider2D>().radius * player.transform.localScale.x;
        //player.GetComponent<CircleCollider2D>().bounds

        for (int i = 0; i < number; i++)
        {
            float xCoord = Random.Range(playerPos.x - playerRadius - spawnDistance, playerPos.x + playerRadius + spawnDistance);
            float yCoord = Random.Range(playerPos.y - playerRadius - spawnDistance, playerPos.y + playerRadius + spawnDistance); 

            Instantiate(ball, new Vector3(xCoord, yCoord, 0), Quaternion.identity);
        }

    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            if(Ball.currentNumberOfBalls < maxBallCount)
            {
                SpawnBall(spawnRate);
            }
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

}
