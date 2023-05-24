using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCalculations : MonoBehaviour
{
    public float speed;
    public Vector2 originPosition;
    Rigidbody2D body;
    Camera camera;

    void Awake()
    {
        camera = GetComponent<Camera>();

        //body = GetComponent<Rigidbody2D>();
        //body.velocity = directionVector * speed;
    }

    public Vector2 ClickLocation()
    {
        return new Vector2(camera.ScreenToWorldPoint(Input.mousePosition).x, camera.ScreenToWorldPoint(Input.mousePosition).y);
        //Vector2 directionVector = (mousePosition - originPosition).normalized;
    }

    /*
    float projectileAngle(Vector2 directionVector)
    {
        float rotationAngle = Vector2.Angle(Vector2.up, directionVector);
        if (directionVector.x > 0)
        {
            rotationAngle *= -1;
        }
        return rotationAngle;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, projectileAngle(body.velocity));
        body.velocity += new Vector2(0f, -3 * Time.deltaTime);
    }
    */
}
