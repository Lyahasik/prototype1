using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    public float StartSpeed = 1.0f;
	public Player Player1;
	public Player Player2;

    private float _moveX;
    private float _moveY;
    private Vector3 _vectorMove;

    private float _width = 0.5f;
    private float _height = 0.5f;

    private float _borderX = 8.89f;
    private float _borderY = 5.0f;

	private int _scorePlayer1 = 0;
	private int _scorePlayer2 = 0;

	private float _currentSpeed;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        transform.Translate(_vectorMove * Time.deltaTime);
        
        if (transform.position.y + _height * 0.5f > _borderY)
        {
			transform.position = new Vector3(transform.position.x, _borderY - _height * 0.5f, transform.position.z);
			_moveY = -_moveY;
            _vectorMove = new Vector3(_moveX * _currentSpeed, _moveY * _currentSpeed, 0);
        }

        if (transform.position.y + -_height * 0.5f < -_borderY)
        {
			transform.position = new Vector3(transform.position.x, -_borderY + _height * 0.5f, transform.position.z);
			_moveY = -_moveY;
            _vectorMove = new Vector3(_moveX * _currentSpeed, _moveY * _currentSpeed, 0);
        }

		if (transform.position.x + _width * 0.5f > _borderX)
		{
			_scorePlayer1++;
			PrintScore();
			Spawn();
		}

		if (transform.position.x + -_width * 0.5f < -_borderX)
		{
			_scorePlayer2++;
			PrintScore();
			Spawn();
		}

		if (transform.position.y + _height * 0.5f < Player1.GetUpBorder()
			&& transform.position.y - _height * 0.5f > Player1.GetDownBorder()
			&& transform.position.x - _width * 0.5f < Player1.GetRightBorder())
		{
			transform.position = new Vector3(Player1.GetRightBorder() + _width * 0.5f, transform.position.y, transform.position.z);
			_moveX = -_moveX;
			_currentSpeed += 0.3f;
        	_vectorMove = new Vector3(_moveX * _currentSpeed, _moveY * _currentSpeed, 0);
		}

		if (transform.position.y + _height * 0.5f < Player2.GetUpBorder()
			&& transform.position.y - _height * 0.5f > Player2.GetDownBorder()
			&& transform.position.x + _width * 0.5f > Player2.GetLeftBorder())
		{

			transform.position = new Vector3(Player2.GetLeftBorder() - _width * 0.5f, transform.position.y, transform.position.z);
			_moveX = -_moveX;
			_currentSpeed += 0.3f;
        	_vectorMove = new Vector3(_moveX * _currentSpeed, _moveY * _currentSpeed, 0);
		}
    }

	void PrintScore()
	{
		Debug.Log("Player 1: " + _scorePlayer1 + " | Player 2: " + _scorePlayer2);
	}

	void Spawn()
	{
		_moveX = Random.Range(0, 2) == 0 ? -1.0f : 1.0f;
        _moveY = Random.Range(-1.0f, 1.0f);
        _vectorMove = new Vector3(_moveX * StartSpeed, _moveY * StartSpeed, 0);
		_currentSpeed = StartSpeed;
		transform.position = Vector3.zero;
	}
}
