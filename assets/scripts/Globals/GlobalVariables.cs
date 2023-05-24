using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : ScriptableObject
{
	//Player Physics
	public float termVelocity = 15f;
	public float g = 40f;

	//Player Movement
	public float moveSpeed = 4.5f;
	public float moveAccelTime = 0.1f;
	public float maxCoyoteTime = 0.025f;

	public float jumpForce = 10.5f;
	public float doubleJumpForce = 13f;
	public int maxJumps = 2;
	public float wallJumpForce = 15f;
	public float wallJumpAngle = 20;
	public float maxWallClingTime = 0.15f;
	public float wallFriction = 0.4f;
	public float wallJumpDelay = 0.125f;

	public float dashForce = 20f;

	//Stamina costs
	public static int dashCost = 70;
	public static int primaryItemUseCost = 20;
	public static int secondaryItemUseCost = 30;

	//Camera Movement
	public float smoothSpeedX = 5f;
	public float smoothSpeedY = 5f;
	public Vector3 offset = new Vector3(0f, 1.69f, 7f);
	public float upperCameraBound = 7f;

	//Map Generation and Tiles
	public static float tileWidth = 1;
	public static float tileHeight = 1;
}
