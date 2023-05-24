using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GlobalVariables global;
    Rigidbody2D body;
    BoxCollider2D boxCollider;
    PlayerAnimation animation;

    LayerMask ground;
    LayerMask transparentPlatform;

    int move;
    int facing = 1;
    bool dash = false;
    bool wallJump = false;
    bool jump = false;
    bool drop = false;

    float moveTimer;
    float dashTimer;
    float jumpTimer;
    float wallJumpTimer;
    float wallClingTimer;
    float coyoteTimer;
    float dropTimer;

    public int jumpCount;

    Collider2D lastJumpedWall;

    List<PlatformEffector2D> platformEffectors = new List<PlatformEffector2D>();  

    void Awake()
    {
        global = GlobalVariables.CreateInstance<GlobalVariables>();
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        ground = LayerMask.GetMask("ground");
        transparentPlatform = LayerMask.GetMask("transparentPlatform");
    }
    void Update()
    {
        //Apply movement velocity
        if (!wallJump)
        {
            if (body.velocity != new Vector2(move * global.moveSpeed, body.velocity.y))
            {
                moveTimer += Time.deltaTime;
                float accel = moveTimer / global.moveAccelTime;
                accel = accel >= 1 ? 1f : accel;

                body.velocity = new Vector2(accel * move * global.moveSpeed, body.velocity.y);

                if (move == 0)
                {
                    moveTimer = 0f;
                }
            }
        }

        //Apply Jump
        jumpTimer += Time.deltaTime;
        if (jump && (jumpTimer < 0.18f))
        {
            body.velocity = new Vector2(body.velocity.x, global.jumpForce);
        } else if (Grounded())
        {
            jump = false;
            jumpTimer = 0f;
        }

        //Apply dash
        if (dash)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer < 0.18f)
            {
                body.velocity = new Vector3(facing * global.dashForce, 0f);
            } else
            {
                body.velocity = new Vector3(0f, body.velocity.y);
                dash = false;
                dashTimer = 0f;
            }
        }

        //Allow wall clinging
        if (AgainstWall() && (!wallJump) && (!jump) && (wallClingTimer < global.maxWallClingTime))
        {
            wallClingTimer += Time.deltaTime;
            body.velocity = new Vector2(body.velocity.x, global.g * Time.deltaTime * global.wallFriction);
        } else if (wallJump || Grounded())
        {
            wallClingTimer = 0f;
        }

        //Restrict air control if just wall jumped
        if (wallJump)
        {
            wallJumpTimer += Time.deltaTime;
            if (wallJumpTimer >= global.wallJumpDelay)
            {
                wallJump = false;
                wallJumpTimer = 0f;
            }
        }

        //allow player to fall through transparent platforms
        if (dropTimer > 0f)
        {
            dropTimer += Time.deltaTime;
        }

        if (drop)
        {
            dropTimer += Time.deltaTime;
            if (OnTransparentPlatform() == true)
            {
                foreach (PlatformEffector2D effector in platformEffectors)
                {
                    effector.surfaceArc = 0f;
                }
            }
        } else if (dropTimer >= 0.2f)
        {
            dropTimer = 0f;
            foreach (PlatformEffector2D effector in platformEffectors)
            {
                effector.surfaceArc = 170f;
            }
            platformEffectors.Clear();
        }

        //allow coyote time and update jumpCount
        if (Grounded())
        {
            coyoteTimer = 0f;
            jumpCount = 0;
        } else if (AgainstWall())
        {
            jumpCount = 0;
        } else if (coyoteTimer < global.maxCoyoteTime)
        {
            coyoteTimer += Time.deltaTime;
        }
    }

    public void Move(int dir)
    {
        move += dir;
        facing = dir;

        if (((dir > 0) != (transform.localScale.x > 0)) && (move != 0))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Jump()
    {
        Collider2D currentWall;
        int againstWall = AgainstWall(out currentWall);

        if (Grounded() || coyoteTimer < global.maxCoyoteTime)
        {
            jump = true;
        } else if ((againstWall != 0) && (currentWall != lastJumpedWall))
        {
            wallJump = true;
            lastJumpedWall = currentWall;
            body.velocity = Quaternion.Euler(0f, 0f, againstWall * global.wallJumpAngle) * Vector2.up * global.wallJumpForce;
            jumpCount++;
        } else if (jumpCount < global.maxJumps - 1)
        {
            body.velocity = new Vector2(body.velocity.x, global.doubleJumpForce);
            jumpCount++;
        }
    }

    public void CancelJump() {  jump = false; }

    public void Drop() { drop = true; }

    public void CancelDrop() { drop = false; }

    public void Dash() { dash = true; }

    int AgainstWall(out Collider2D hitWall)
    {
        RaycastHit2D leftBoxCast = Physics2D.BoxCast(boxCollider.transform.position, boxCollider.size, 0f, Vector2.left, 0.05f, ground);
        RaycastHit2D rightBoxCast = Physics2D.BoxCast(boxCollider.transform.position, boxCollider.size, 0f, Vector2.right, 0.05f, ground);

        if (leftBoxCast.collider != null)
        {
            hitWall = leftBoxCast.collider;
            return -1;
        }
        if (rightBoxCast.collider != null)
        {
            hitWall = rightBoxCast.collider;
            return 1;
        }

        hitWall = null;
        return 0;
    }

    bool AgainstWall()
    {
        bool leftBoxCast = Physics2D.BoxCast(boxCollider.transform.position, boxCollider.size, 0f, Vector2.left, 0.05f, ground);
        bool rightBoxCast = Physics2D.BoxCast(boxCollider.transform.position, boxCollider.size, 0f, Vector2.right, 0.05f, ground);

        if (leftBoxCast || rightBoxCast)
        {
            return true;
        }

        return false;
    }

    bool OnTransparentPlatform()
    {
        for (int i = -1; i <= 1; i++)
        {
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(boxCollider.transform.position.x + i * boxCollider.size.x,
                boxCollider.transform.position.y - boxCollider.size.y / 2), 
                Vector2.down, 
                0.4f,
                transparentPlatform);

            if (ray.collider != null)
            {
                platformEffectors.Add(ray.collider.gameObject.GetComponent<PlatformEffector2D>());
            }
        }

        if (platformEffectors.Count != 0)
        {
            return true;
        }
        return false;
    }

    bool OnTransparentPlatform(int _n)
    {
        List<PlatformEffector2D> _effectors = new List<PlatformEffector2D>();

        for (int i = -1; i <= 1; i++)
        {
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(boxCollider.transform.position.x + i * boxCollider.size.x,
                boxCollider.transform.position.y - boxCollider.size.y / 2),
                Vector2.down,
                0.4f,
                transparentPlatform);

            if (ray.collider != null)
            {
                _effectors.Add(ray.collider.gameObject.GetComponent<PlatformEffector2D>());
            }
        }

        if (_effectors.Count != 0)
        {
            return true;
        }
        return false;
    }

    bool Grounded()
    {
        if (OnTransparentPlatform(1))
        {
            return true;
        }

        bool boxCast = Physics2D.BoxCast(boxCollider.transform.position, boxCollider.size, 0f, Vector2.down, 0.4f, ground); 

        if (boxCast)
        {
            lastJumpedWall = null;
            return true;
        }

        return false;
    }
}