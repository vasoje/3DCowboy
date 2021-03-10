using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public Text _timerText;
    private float _startTime;

    // Start is called before the first frame update
    void Start() 
    {
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - _startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        _timerText.text = minutes + ":" + seconds;
    }
}
