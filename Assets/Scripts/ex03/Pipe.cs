using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Bird Bird;
    public float MaxY = 1.24f;
    public float MinY = -1.62f;

    private float MaxX = 1.34f;
    private float MinX = -1.28f;

    public float Speed = 2.0f;

    private bool _success = false;

    private void Update()
    {
        if (!Bird.IsMove())
            return ;

        transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));

        if (transform.position.x < -5.5f)
        {
            transform.position = new Vector3(5.5f, transform.position.y, transform.position.z);
            _success = false;
        }
    }

    public bool Collision(GameObject bird)
    {
        if (gameObject.transform.position.x > MinX && gameObject.transform.position.x < MaxX)
        {
            if (bird.transform.position.y < MinY || bird.transform.position.y > MaxY)
            {
                return true;
            }
        }

        return false;
    }

    public bool Success()
    {
        if (_success)
            return false;

        if (gameObject.transform.position.x + MaxX < 0.0f)
        {
            Speed += 0.05f;
            _success = true;
            return true;
        }

        return false;
    }
}
