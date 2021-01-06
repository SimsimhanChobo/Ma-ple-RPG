using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelData
{
    public static readonly Vector3[] voxelVerts = new Vector3[8]
    {
        new Vector3(-0.5f, -0.5f, -0.5f), //Front Left Bottom
        new Vector3(0.5f, -0.5f, -0.5f), //Front Right Bottom
        new Vector3(0.5f, 0.5f, -0.5f), //Front Right Top
        new Vector3(-0.5f, 0.5f, -0.5f), //Front Left Top
        new Vector3(-0.5f, -0.5f, 0.5f), //Left Left Bottom
        new Vector3(0.5f, -0.5f, 0.5f), //Right Right Bottom
        new Vector3(0.5f, 0.5f, 0.5f), //Right Right Top
        new Vector3(-0.5f, 0.5f, 0.5f) //Left Left Top
    };

    public static readonly int[,] voxelTris = new int[6, 6]
    {
        {0, 3, 1, 1, 3, 2}, //Front
        {5, 6, 4, 4, 6, 7}, //Back
        {3, 7, 2, 2, 7, 6}, //Top
        {1, 5, 0, 0, 5, 4}, //Bottom
        {4, 7, 0, 0, 7, 3}, //Left
        {1, 2, 5, 5, 2, 6} //Right
    };

    public static readonly Vector2[] voxelUvs = new Vector2[6]
    {
        new Vector2(0.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 1.0f),
    };
}