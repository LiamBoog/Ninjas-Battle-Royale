using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    GlobalVariables global;
	
	Rigidbody2D body;
    PlayerMovement playerMovement;

	void Awake()
    {
        global = GlobalVariables.CreateInstance<GlobalVariables>();
    	body = GetComponent<Rigidbody2D>();
    }

	void Update()
	{
        //gravity accelerates until termVelocity is reached
        if (body.velocity.y > -global.termVelocity)
        {
            //body.velocity += new Vector2(0f, -0.25f);
            body.velocity += new Vector2(0f, -global.g * Time.deltaTime);
        } else
        {
            body.velocity = new Vector2(body.velocity.x, -global.termVelocity);
        }
	}
}