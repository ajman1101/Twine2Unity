using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum Direction { Left, Right };

    Direction direction = Direction.Right;
    Grid grid;
    PlayerController player;

    int eX = 1;
    int eY = 1;

    public int X { get { return eX; } }
    public int Y { get { return eY; } }

    float movementDelay = 1.25f;
    float waitUntilNextMove = 0.0f;

    void Start()
    {
        grid = FindObjectOfType<Grid>();
        player = FindObjectOfType<PlayerController>();
    }

    public void SetPosition(int x, int y)
    {
        grid = grid ?? FindObjectOfType<Grid>();
        eX = x;
        eY = y;
        grid.OccupySpace(x, y);
        transform.position = grid.PositionAtSpace(x, y);
        transform.localScale = direction == Direction.Right ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
    }

    void Update()
    {
        waitUntilNextMove += Time.deltaTime;
        if (waitUntilNextMove >= movementDelay)
        {
            var playerY = player.Y;
            var playerX = player.X;

            var differenceInX = playerX - eX;
            var differenceInY = playerY - eY;

            if (Math.Abs(differenceInY) > Math.Abs(differenceInX))
            {
                int yMovement = differenceInY > 0 ? 1 : -1;

                if (grid.IsSpaceFree(eX, eY + yMovement))
                {
                    grid.FreeSpace(eX, eY);
                    eY += yMovement;
                    grid.OccupySpace(eX, eY);
                    transform.position = grid.PositionAtSpace(eX, eY);
                }
            }

            else
            {
                int xMovement = differenceInX > 0 ? 1 : -1;

                if (grid.IsSpaceFree(eX + xMovement, eY))
                {
                    grid.FreeSpace(eX, eY);
                    eX += xMovement;
                    grid.OccupySpace(eX, eY);
                    transform.position = grid.PositionAtSpace(eX, eY);
                }
                transform.localScale = xMovement == 1 ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
            }
            waitUntilNextMove = 0.0f;
        }
    }
}