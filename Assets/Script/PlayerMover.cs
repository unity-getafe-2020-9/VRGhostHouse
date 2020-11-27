using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    public GameObject camera;
    public float speed = 5;
    public float angularSpeed = 5;
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            camera.transform.Rotate(Vector3.up * Time.deltaTime * angularSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            camera.transform.Rotate(Vector3.up * Time.deltaTime * angularSpeed * -1);
        }
        if (Input.touches.Length > 0)
        {
            MoveForward();
        }
    }

    private void MoveForward()
    {
        float y = transform.position.y;
        transform.Translate(camera.transform.forward * Time.deltaTime * speed, Space.World);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
