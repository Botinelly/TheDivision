using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages infinite grid spawning for the background
public class GridSpawner : MonoBehaviour {

    // references to the grid to spawn and the player
    public GameObject grid;
    public GameObject player;
   
    // default directional vector3s, each grid is 100 units
    private Vector3 up = new Vector3(0, 100, 0);
    private Vector3 right = new Vector3(100, 0, 0);
    private Vector3 down = new Vector3(0, -100, 0);
    private Vector3 left = new Vector3(-100, 0, 0);

    // instance of the spawner
    public static GridSpawner Instance;

    // start singleton, place starting grid
    void Start()
	{
        if(Instance == null) { Instance = this; }
        else if(Instance != this) { Destroy(gameObject); }

        PlaceGrid(Vector3.zero);
    }

    // spawn 3 grids based on the players position and a given grid position
    public void SpawnGrids(Vector3 position){
        Vector2 velocity = player.GetComponent<Rigidbody2D>().velocity;

        Vector3 centerUp = position + up;
        Vector3 centerLeft = position + left;
        Vector3 centerDown = position + down;
        Vector3 centerRight = position + right;

        Vector3 UpRight = position + up + right;
        Vector3 UpLeft = position + up + left;
        Vector3 DownRight = position + down + right;
        Vector3 DownLeft = position + down + left;
        
        if(velocity.x > 0){
            PlaceGrid(centerRight);
            PlaceGrid(UpRight);
            PlaceGrid(DownRight);
        }
        if(velocity.x < 0){
            PlaceGrid(centerLeft);
            PlaceGrid(UpLeft);
            PlaceGrid(DownLeft);
        }
        if(velocity.y > 0){
            PlaceGrid(centerUp);
            PlaceGrid(UpLeft);
            PlaceGrid(UpRight);
        }
        if(velocity.y < 0){
            PlaceGrid(centerDown);
            PlaceGrid(DownLeft);
            PlaceGrid(DownRight);
        }
    }

    // checks if a given position is empty and then places a grid there
    private void PlaceGrid(Vector3 position){
        if (!Grid.gridLocations.Contains(position)){
            Instantiate(grid, position, Quaternion.identity);
        }
        
    }


}
