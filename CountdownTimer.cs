using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    bool timerActive;
    float currentTime;

    public int startMinutes;
    public TextMeshProUGUI currentTimeText;
    float yourTime;
    public TextMeshProUGUI yourTimeText;

    public GameObject YouFailed;

    public GameObject YouPassed;

    public GameObject CountDown;

    public TextMeshProUGUI keys;


    void Start ()
    {
        currentTime = startMinutes * 60;
        timerActive = true;
    }

    void Update()
    {

        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime < 0)
            {
                timerActive = false;
                if (!YouPassed.activeSelf)
                {
                    YouFailed.SetActive(true);
                    CountDown.SetActive(false);
                    keys.enabled = false;
                }
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Seconds.ToString();

    }
    public void StartTimer()
    {
        timerActive = true;
        CountDown.SetActive(true);
    }

    public void StopTimer()
    {
        timerActive = false;
    } 

    public void saveYourTime()
    {
        yourTime = 60 - currentTime;
        TimeSpan time = TimeSpan.FromSeconds(yourTime);
        yourTimeText.text = "Your time: " + time.Seconds.ToString() + " seconds";
    }   
}
