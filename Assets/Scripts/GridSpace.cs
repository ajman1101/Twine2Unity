using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridSpace
{
    bool walkable;
    bool occupied;
    bool exit;
    Vector3 position;

    public bool IsWalkable { get { return walkable; } }
    public Vector3 Position { get { return new Vector3(position.x, position.y, -.001f); } }
    public bool IsOccupied { get { return occupied; } set { occupied = value; } }
    public bool IsExit { get { return exit; } }

    public GridSpace(bool walkable, bool exit, Vector3 position)
    {
        this.walkable = walkable;
        this.position = position;
        this.exit = exit;
        occupied = false;
    }
}