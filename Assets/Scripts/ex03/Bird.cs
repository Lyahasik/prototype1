using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public Pipe Pipe1;
	public Pipe Pipe2;

	public float SpeedDrop = 0.1f;
	public float PowerJump = 20.0f;

    private bool _move = true;
    private float _timeGame;
    private int _score = 0;

	private Vector3 _vectorMove;
    private float _floor = -4.62f;

    private void Start()
    {
        _timeGame = Time.time;
		_vectorMove = Vector3.zero;
    }

	public bool IsMove()
	{
		return _move;
	}

    void Update()
    {
        if (_move)
        {
			if (Pipe1.Collision(gameObject)
				|| Pipe2.Collision(gameObject))
            {
                Die();
                return ;
            }

            if (transform.position.y <= _floor)
            {
                transform.position = new Vector3(0, _floor, 0);
                Die();
                return ;
            }

			if (Input.GetKeyDown("space")
				&& _vectorMove.y < 5.0f)
			{
				_vectorMove += new Vector3(0, PowerJump, 0);
			}

			if (_vectorMove.y > -10.0f)
			{
				_vectorMove -= new Vector3(0, SpeedDrop, 0);
			}

			transform.Translate(_vectorMove * Time.deltaTime, Space.World);

			if (transform.rotation.z < 0.35f
				&& transform.rotation.z > -0.35f)
			{
				transform.Rotate(new Vector3(0, 0, _vectorMove.y));

				if (transform.rotation.z >= 0.35f
				|| transform.rotation.z <= -0.35f)
				{
					transform.Rotate(new Vector3(0, 0, -_vectorMove.y));
				}
			}

			if (transform.position.y > 7.5f)
			{
				transform.position = new Vector3(transform.position.x, 7.5f, transform.position.z);
			}

			if (Pipe1.Success()
				|| Pipe2.Success())
			{
				_score += 5;
			}
        }
    }

    public void Die()
    {
        Debug.Log("Score: " + _score);
        Debug.Log("Time: " + Mathf.RoundToInt(Time.time - _timeGame) + "s");
        _move = false;
    }
}
