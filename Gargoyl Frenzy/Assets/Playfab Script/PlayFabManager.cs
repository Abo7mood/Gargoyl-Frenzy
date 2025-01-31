using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager Instance;
    public int HighScore;
    public string Name;

    private void Awake()
    {
        Name = null;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        login();
    }


    public List<Text> ScoresList = new List<Text>();
    public List<Text> NamesList = new List<Text>();

    public bool loggedin = false;

    /// <summary>
    /// Login
    /// </summary>
    public void login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams { GetPlayerProfile = true }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnErrorLogin);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Loggedin");
        loggedin = true;
        if (result.InfoResultPayload.PlayerProfile != null) Name = result.InfoResultPayload.PlayerProfile.DisplayName;
        GetHighscore();
    }
    void OnErrorLogin(PlayFabError error)
    {
        Debug.Log("error");
    }


    /// <summary>
    ///             Highscore update
    /// </summary>
    /// <param name="highscore"></param>
    public void UploadHighScore(int highscore)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Platform leaderboard", Value = highscore
                }
            }
        };
        var request2 = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string> { { "HighScore",  highscore.ToString() } }
        };
        PlayFabClientAPI.UpdateUserData(request2, OnUpdateUserData, OnErrorLogin);
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnErrorLogin);
        HighScore = highscore;

    }
    void OnUpdateUserData(UpdateUserDataResult result)
    {
        Debug.Log("Score saved In profile");
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("score updated");
    }

    /// <summary>
    ///             Leaderboard Get
    /// </summary>
    public void GetLeaderboard()
    {

        var request = new GetLeaderboardRequest
        {
            StatisticName = "Platform leaderboard",
            StartPosition = 0,
            MaxResultsCount = 10,
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeadeboardGet, OnErrorLogin);
    }
    void OnLeadeboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            ScoresList[item.Position].text = item.StatValue.ToString();
            NamesList[item.Position].text = item.DisplayName;
        }
    }
    public void LinkLeaderboardtoUI()
    {
        for (int i = 0; i < 10; i++)
        {
            ScoresList[i] = GameObject.Find("Score" + i).GetComponent<Text>();
            NamesList[i] = GameObject.Find("Name" + i).GetComponent<Text>();
        }
    }

    /// <summary>
    ///             Name Set
    /// </summary>
    /// <param name="Name"></param>
    public void SetName(string name)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = name
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnNameSave, OnErrorLogin);
    }
    void OnNameSave(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("name saved");
        Name = result.DisplayName;
    }
    /// <summary>
    ///             Get HighScore
    /// </summary>
    public void GetHighscore()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnHighscoreGet, OnErrorLogin);
    }
    void OnHighscoreGet(GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("HighScore")) { HighScore = int.Parse(result.Data["HighScore"].Value); }
        else HighScore = 0;
    }
    
}