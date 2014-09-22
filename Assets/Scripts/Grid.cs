using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    GridSpace[,] grid = new GridSpace[20, 12];
    public GameObject groundTile;
    public GameObject edgeTile;
    public GameObject environmentContainer;
    public GameObject exit;
    public GameObject enemy;
    PlayerController player;

    int currentLevel = -1;

    /*
     * Level definitions are marked as follows:
     * -1: Unmovable tile
     *  0: Player start location
     *  2: Exit location
     *  3: Enemy location
     */
    int[,] level1 = new int[12, 20]
    {
        {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}
    };

    int[,] level2 = new int[12, 20]
    {
        {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1, 0, -1, 1,  1, 1, -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, -1, 1, -1, 1, -1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, -1, 1,-1},
        {-1, 1, -1, 1, -1, 1, -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, 1,-1},
        {-1, 1, -1, 1, -1, 1, -1, 1, 1, 1, 1, -1, -1, -1, -1, 1, 1, -1, 1,-1},
        {-1, 1, -1, 1, -1, 1, -1, 1, 1, 1, 1, -1, 1, 1, 1, 1, 1, -1, 1,-1},
        {-1, 1, -1, 1, -1, 1, -1, 1, 1, 1, 1, -1, 1, 1, 1, 1, 1, -1, 1,-1},
        {-1, 1, -1, 1, -1, 1, -1, 1, 1, 1, 1, -1, 1, 1, 1, 1, 1, -1, 1,-1},
        {-1, 1, -1, 1, -1, 1, -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, 1,-1},
        {-1, 1, -1, 1, -1, 1, -1, 1, 1, 1, 1, 1, 1, -1, -1, -1, -1, 1, 1,-1},
        {-1, 1,  1, 1, -1, 1,  1, 1, 1, 1, 1, 1, 1, -1, 1, 1, 1, 1, 1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 2,-1,-1,-1,-1}
    };

    int[,] level3 = new int[12, 20]
    {
        {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1,-1},
        {-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}
    };

    List<int[,]> levels = new List<int[,]>();
    List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> Enemies { get { return enemies; } }

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);

        loadNextLevel();
    }

    public void FreeSpace(int x, int y)
    {
        grid[x, y].IsOccupied = false;
    }

    public void OccupySpace(int x, int y)
    {
        grid[x, y].IsOccupied = true;
    }

    public bool IsSpaceFree(int x, int y)
    {
        if (x >= grid.GetLength(0) || x < 0)
            return false;

        if (y >= grid.GetLength(1) || y < 0)
            return false;
        
        return !grid[x, y].IsOccupied && grid[x, y].IsWalkable;
    }

    public Vector3 PositionAtSpace(int x, int y)
    {
        return grid[x, y].Position;
    }

    public bool IsExit(int x, int y)
    {
        return grid[x, y].IsExit;
    }

    public bool IsLastLevel()
    {
        return currentLevel == levels.Count - 1;
    }

    public void loadNextLevel()
    {
        int numOfEnemies = 0;
        currentLevel++;
        if (currentLevel >= levels.Count)
            return;

        var sprites = environmentContainer.GetComponentsInChildren<SpriteRenderer>();
        foreach (var sprite in sprites)
            Destroy(sprite.gameObject);

        foreach (var e in enemies)
            Destroy(e.gameObject);
        enemies.Clear();

        var levelLayout = levels[currentLevel];
        var gridWidth = grid.GetLength(0);
        var gridHeight = grid.GetLength(1);
        var spriteWidth = groundTile.GetComponent<SpriteRenderer>().bounds.size.x;
        var spriteHeight = groundTile.GetComponent<SpriteRenderer>().bounds.size.y;

        var currentSpaceX = 0;
        var currentSpaceY = 0;

        for (int y = (gridHeight / 2); y > -(gridHeight / 2); y--)
        {
            for (int x = -(gridWidth / 2); x < (gridWidth / 2); x++)
            {
                GameObject newTile;
                var gridSpace = levelLayout[currentSpaceY, currentSpaceX];

                if (gridSpace == 2)
                {
                    newTile = (GameObject)GameObject.Instantiate(exit, new Vector3(spriteWidth * x, spriteHeight * y, 0), Quaternion.identity);
                    grid[currentSpaceX, currentSpaceY] = new GridSpace(true, true, newTile.transform.position);
                }

                else if (gridSpace == -1)
                {
                    newTile = (GameObject)GameObject.Instantiate(edgeTile, new Vector3(spriteWidth * x, spriteHeight * y, 0), Quaternion.identity);
                    grid[currentSpaceX, currentSpaceY] = new GridSpace(false, false, newTile.transform.position);
                }

                else
                {
                    newTile = (GameObject)GameObject.Instantiate(groundTile, new Vector3(spriteWidth * x, spriteHeight * y, 0), Quaternion.identity);
                    grid[currentSpaceX, currentSpaceY] = new GridSpace(true, false, newTile.transform.position);
                }

                if (gridSpace == 0)
                {
                    player.SetPosition(currentSpaceX, currentSpaceY);
                }

                if (gridSpace == 3)
                {
                    var newEnemy = (GameObject)GameObject.Instantiate(enemy, new Vector3(spriteWidth * x, spriteHeight * y, 0), Quaternion.identity);
                    newEnemy.GetComponent<Enemy>().enabled = true;
                    newEnemy.GetComponent<Enemy>().SetPosition(currentSpaceX, currentSpaceY);
                    newEnemy.GetComponent<SpriteRenderer>().enabled = true;
                    enemies.Add(newEnemy);
                    numOfEnemies++;
                }

                newTile.transform.parent = environmentContainer.transform;
                currentSpaceX++;
            }
            currentSpaceX = 0;
            currentSpaceY++;
        }
    }
}