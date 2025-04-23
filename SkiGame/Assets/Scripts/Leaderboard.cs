using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();
    [SerializeField] private List<TextMeshPro> timeTexts= new (); //text reference

    private void Awake()
    {
        bestTimes.Clear();
        for (int i = 0; i < 5; i++)
        {
           bestTimes.Add(PlayerPrefs.GetFloat("time"+ i, 9999999)) ;
        }

        UpdateLeaderboardUI();
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveData();
        UpdateLeaderboardUI();  //added for leaderboard
    }

    private void SaveData()
    {
        for(int i = 0; i < 5; i++)
        {
            if(i<bestTimes.Count)
             PlayerPrefs.SetFloat("time"+ i, bestTimes[i]);
        }
        
        PlayerPrefs.Save();
    }

    private void UpdateLeaderboardUI() //added for leaderboard
    {
        for (int i = 0; i < timeTexts.Count; i++)
        if (i < bestTimes.Count)
        {
            timeTexts[i].text = FormatTime(bestTimes[i]);
        }
        else
        {
            timeTexts[i].text = "---";
        }
    }

    private string FormatTime(float time) //added for leaderboard
    {
        if (time >= 9999999) return "---";
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return $"{minutes: 00}:{seconds:00}.{milliseconds:000}";
    }
}
