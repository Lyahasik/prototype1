using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool Player1 = true;
    [Space]

    public float Speed = 2.0f;

    private Vector3 _vectorMove;
    
    private float _borderY = 5.0f;

    private void Start()
    {
        _vectorMove = new Vector3(0, Speed * Time.deltaTime, 0);
    }

    private void Update()
    {
        if (Player1)
        {
            if (Input.GetKey("w"))
            {
                transform.Translate(_vectorMove);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(-_vectorMove);
            }
        }
        else
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(_vectorMove);
            }
            if (Input.GetKey("down"))
            {
                transform.Translate(-_vectorMove);
            }
        }

        if (transform.position.y + (transform.localScale.y * 0.5f) > _borderY)
        {
            transform.position = new Vector3(transform.position.x, _borderY - transform.localScale.y * 0.5f, transform.position.z);
        }
        if (transform.position.y - (transform.localScale.y * 0.5f) < -_borderY)
        {
            transform.position = new Vector3(transform.position.x, -_borderY + transform.localScale.y * 0.5f, transform.position.z);
        }
    }

    public float GetRightBorder()
    {
        return transform.position.x + (transform.localScale.x * 0.5f);
    }

    public float GetLeftBorder()
    {
        return transform.position.x - (transform.localScale.x * 0.5f);
    }

    public float GetUpBorder()
    {
        return transform.position.y + (transform.localScale.y * 0.5f);
    }

    public float GetDownBorder()
    {
        return transform.position.y - (transform.localScale.y * 0.5f);
    }
}
