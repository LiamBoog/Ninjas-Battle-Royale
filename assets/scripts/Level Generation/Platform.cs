using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform
{
    public int platformType;
    public Vector2 bottomLeft;
    public Vector2 topRight;

    public Platform(Vector2 _bottomLeft, Vector2 _topRight, int _platformType)
    {
        bottomLeft = _bottomLeft;
        topRight = _topRight;
        platformType = _platformType;
    }
}
