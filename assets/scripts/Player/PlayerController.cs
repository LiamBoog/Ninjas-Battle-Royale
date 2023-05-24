using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 previousPosition = Vector3.zero;

    private void FixedUpdate()
    {
        float positionDifference = (transform.position - previousPosition).magnitude;

        if (positionDifference > 0.001f)
        {
  
            ClientSend.PlayerMovement(transform.position, transform.rotation);
            previousPosition = transform.position;
        }
    }
}
