using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardFill : MonoBehaviour
{
    public void LeaderboardUICall() => PlayFabManager.Instance.LinkLeaderboardtoUI();
    public void LeaderboardGetCall() => PlayFabManager.Instance.GetLeaderboard();
}
