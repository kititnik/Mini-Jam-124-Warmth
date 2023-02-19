using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Leaderboard : MonoBehaviour
{
    private const string LeaderBoard = "CgkIi_zZo7wSEAIQAQ";

    private void Start()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(_ => {});
    }

    public void UpdateLeaderBoard(long timeInMillisecond)
    {
        Social.ReportScore(timeInMillisecond, LeaderBoard, _ => {});
    }

    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }
}
