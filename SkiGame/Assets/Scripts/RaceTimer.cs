using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private float penaltyTime = 1;
    private float raceTime = 0;
    private bool timerRunning = false;

    private void Update()
    {
        if (timerRunning)
            raceTime += Time.deltaTime;
    }

    private void OnEnable()
    {
        FlagEvents.raceStart += StartRace;
        FlagEvents.raceEnd += FinishRace;
        FlagEvents.racePenalty += Penalty;
    }

    private void OnDisable()
    {
        FlagEvents.raceStart -= StartRace;
        FlagEvents.raceEnd -= FinishRace;
        FlagEvents.racePenalty += Penalty;
    }

    private void StartRace()
    {
        timerRunning = true;
        Debug.Log("race started");
    }

    private void FinishRace()
    {
        timerRunning = false;
        Debug.Log("race finished");
        Debug.Log("race time "+ raceTime);
    }

    private void Penalty()
    {
        raceTime += penaltyTime;
        Debug.Log("Penalty recieved");
    }
}
