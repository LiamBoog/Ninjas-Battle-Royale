using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	GlobalVariables global;
	GameObject camera;
	public float compensation = 5;
	float longFall;
    Rigidbody2D body;
    Vector3 targetPosition;
    Vector3 direction;

	void FixedUpdate()
	{
		longFall = Mathf.Abs((camera.transform.position.y - transform.position.y)/global.upperCameraBound);
	}

	void LateUpdate()
	{
		targetPosition = transform.position + global.offset;
		direction = targetPosition - camera.transform.position;
		
		camera.transform.Translate(new Vector3(direction.x * global.smoothSpeedX, direction.y * (longFall * global.smoothSpeedY)) * Time.deltaTime, Space.World);
	}

    void Awake()
    {
		camera = GameObject.Find("Main Camera");
    	global = GlobalVariables.CreateInstance<GlobalVariables>();
		body = GetComponent<Rigidbody2D>();
    }

}
