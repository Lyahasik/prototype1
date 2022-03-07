using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float ForceInflation = 10.0f;
    public float MaxVolumeLung = 50.0f;
    public float LungRecovery = 20.0f;
    [Space]
    
    public float AccelerationFactorDeflation = 0.1f;
    public float MaxSize = 3.0f;
    public float MinSize = 0.3f;

    private float _timeLife;
    public float _volumeLung;

    private void Start()
    {
        _timeLife = Time.time;
        _volumeLung = MaxVolumeLung;
    }

    void Update()
    {
        if (transform.localScale.x > MinSize)
        {
            Flation();
            CheckSize();
            Lung();
        }
    }

    void Lung()
    {
        _volumeLung += LungRecovery * Time.deltaTime;

        if (_volumeLung > MaxVolumeLung)
        {
            _volumeLung = 50.0f;
        }
    }

    void Lung(float value)
    {
        _volumeLung -= value;
    }

    void Flation()
    {
        if (Input.GetKeyDown(KeyCode.Space)
            && _volumeLung >= ForceInflation)
        {
            Inflation();
            Lung(ForceInflation);
        }
        else
        {
            Deflation();
        }
    }

    void Inflation()
    {
        Vector3 valueChange = Vector3.one * ForceInflation * Time.deltaTime;

        transform.localScale += valueChange;
        transform.localPosition += new Vector3(0.0f, valueChange.y * 0.15f, 0.0f);
    }

    void Deflation()
    {
        Vector3 valueChange = (transform.localScale * AccelerationFactorDeflation) * Time.deltaTime;

        transform.localScale -= valueChange;
        transform.localPosition -= new Vector3(0.0f, valueChange.y * 0.15f, 0.0f);
    }

    void CheckSize()
    {
        if (transform.localScale.x > MaxSize)
        {
            Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time - _timeLife) + "s");
            GameObject.Destroy(gameObject);
        }
        else if (transform.localScale.x < MinSize)
        {
            Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time - _timeLife) + "s");
        }
    }
}
