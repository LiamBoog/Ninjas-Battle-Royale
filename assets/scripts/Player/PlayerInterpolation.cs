using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterpolation : MonoBehaviour
{
    public List<float> horizontalPositions = new List<float>();
    public List<float> verticalPositions = new List<float>();

    void Awake()
    {
        Vector3 initialPosition = GetComponent<Transform>().position;
        horizontalPositions.Add(initialPosition.x);
        verticalPositions.Add(initialPosition.y);
    }
}
