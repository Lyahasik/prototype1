using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject Club;
    public GameObject Luse;
    public float Speed = 1.0f;
    public float Slow = 1.0f;

    private float _borderVertical = 4.5f;

    private Vector3 _vectorMove;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (_vectorMove.magnitude > 0.05f)
        {
            transform.Translate(_vectorMove * Time.deltaTime);
            _vectorMove -= new Vector3(0, Slow * Time.deltaTime, 0);

            float y = Mathf.Clamp(transform.position.y, -_borderVertical, _borderVertical);

            if (y == _borderVertical || y == -_borderVertical)
            {
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
                _vectorMove = -_vectorMove;
                Slow = -Slow;
            }

            if (_vectorMove.magnitude < 0.25f
                && Luse.transform.position.y - transform.position.y < 0.25f
                && Luse.transform.position.y - transform.position.y > -0.25f)
            {
                GameObject.Destroy(gameObject);
            }

            if (_vectorMove.magnitude <= 0.05f)
            {
                Club.transform.position = new Vector3(Club.transform.position.x, transform.position.y - 0.04f, transform.position.z);
                if (Slow < 0.0f)
                {
                    Slow = -Slow;
                }
            }
        }
    }

    public void StartMove(float power)
    {
        _vectorMove = new Vector3(0, power * Speed, 0);
    }
    
}
