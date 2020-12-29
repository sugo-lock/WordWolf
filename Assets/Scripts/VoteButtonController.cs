using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VoteButtonController : MonoBehaviour
{
    private static string PlayerName;

    // Start is called before the first frame update
    void Start()
    {
        OnGetPlayerInfo();
        this.GetComponentInChildren<Text>().text = PlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPushVoteButton()
    {
        SceneManager.LoadScene("Result");

        int i = int.Parse(this.name.Replace("PlayerVoteButton", ""));

        PlayerPrefs.SetInt("VotedPlayerId", i);
        PlayerPrefs.Save();
    }

    void OnGetPlayerInfo()
    {
        int i = int.Parse(this.name.Replace("PlayerVoteButton", ""));
        PlayerName = PlayerPrefs.GetString("PlayerName" + i.ToString());    /* プレイヤー名を取得 */
    }

}
