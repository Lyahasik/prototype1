using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float MinValueSpeed = 1.0f;
    public float MaxValueSpeed = 3.0f;

    private float _speed;
    void Start()
    {
        _speed = Random.Range(MinValueSpeed, MaxValueSpeed);
    }

    void Update()
    {
        Move();

        if (transform.position.y > -4.0f)
        {
            if (Input.GetKeyDown("a")
                && transform.position.x < 0.0f)
            {
                Debug.Log("Precision: " + (transform.position.y - -4.0f));
                Destroy(gameObject);
            }
            else if (Input.GetKeyDown("s")
                && transform.position.x == 0.0f)
            {
                Debug.Log("Precision: " + (transform.position.y - -4.0f));
                Destroy(gameObject);
            }
            else if (Input.GetKeyDown("d")
                && transform.position.x > 0.0f)
            {
                Debug.Log("Precision: " + (transform.position.y - -4.0f));
                Destroy(gameObject);
            }
        }
    }

    void Move()
    {
        transform.Translate(-(new Vector3(0, _speed * Time.deltaTime, 0)));

        if (transform.position.y < -7.0f)
        {
            Destroy(gameObject);
        }
    }
}
