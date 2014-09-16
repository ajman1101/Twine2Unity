using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum Direction { Left, Right };

    Direction direction = Direction.Right;
    Grid grid;

    int pX = 1;
    int pY = 1;

    void Start()
    {
        grid = FindObjectOfType<Grid>();
    }

    public void SetPosition(int x, int y)
    {
        pX = x;
        pY = y;
        grid.OccupySpace(x, y);
        transform.position = grid.PositionAtSpace(x, y);
        transform.localScale = direction == Direction.Right ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (direction == Direction.Right)
            {
                if (grid.IsSpaceFree(pX + 1, pY))
                {
                    grid.FreeSpace(pX, pY);
                    pX++;
                    grid.OccupySpace(pX, pY);
                    transform.position = grid.PositionAtSpace(pX, pY);
                }
            }
            else
            {
                direction = Direction.Right;
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (direction == Direction.Left)
            {
                if (grid.IsSpaceFree(pX - 1, pY))
                {
                    grid.FreeSpace(pX, pY);
                    pX--;
                    grid.OccupySpace(pX, pY);
                    transform.position = grid.PositionAtSpace(pX, pY);
                }
            }
            else
            {
                direction = Direction.Left;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (grid.IsSpaceFree(pX, pY - 1))
            {
                grid.FreeSpace(pX, pY);
                pY--;
                grid.OccupySpace(pX, pY);
                transform.position = grid.PositionAtSpace(pX, pY);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (grid.IsSpaceFree(pX, pY + 1))
            {
                grid.FreeSpace(pX, pY);
                pY++;
                grid.OccupySpace(pX, pY);
                transform.position = grid.PositionAtSpace(pX, pY);
            }
        }

        if (grid.IsExit(pX, pY))
            grid.loadNextLevel();
    }
}