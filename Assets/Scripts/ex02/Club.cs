using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    public GameObject Ball;
    public float MaxPower = 1.0f;
    public float SpeedPower = 1.0f;
    public float Slow = 1.0f;

    private bool _move = false;
    private Vector3 _vectorMove;
    private float _power;
    private int _score;

    void Start()
    {
        _vectorMove = Vector3.zero;
        _power = 0.0f;
        _score = -15;
    }

    void Update()
    {
        if (Ball != null)
        {
            if (!_move
                && Input.GetKey("space"))
            {
                if (_power < MaxPower)
                {
                    _power += SpeedPower * Time.deltaTime;
                    transform.Translate(0, -SpeedPower * Time.deltaTime, 0);
                    _vectorMove += new Vector3(0, SpeedPower * Time.deltaTime, 0);
                }
            }
            else if (_power > 0.0f)
            {
                _move = true;
            }        
            
            Move();
            CheckCollision();
        }
    }

    void Move()
    {
        if (_move)
        {
            transform.Translate(0, _vectorMove.y * Slow * Time.deltaTime, 0);
        }
    }

    void CheckCollision()
    {
        if (_move
            && transform.position.y >= Ball.transform.position.y + 0.1f)
        {
            Debug.Log("Score: " + _score);
            _score += 5;
            Ball.GetComponent<Ball>().StartMove(_power);
            _power = 0.0f;
            _vectorMove = Vector3.zero;
            _move = false;
        }
    }
}
