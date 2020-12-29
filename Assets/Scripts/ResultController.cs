using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    public Text ResultText;
    public Text WolfInfoText;
    public Text CitizenInfoText;

    private static string[] PlayerName;
    private static string[] Theme;
    private static int[] WolfFlag;

    private string VotedPlayerName;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;

        /* プレイヤー人数を取得 */
        int player_num = PlayerPrefs.GetInt("PlayerNum");

        PlayerName = new string[player_num];
        Theme = new string[player_num];
        WolfFlag = new int[player_num];

        /* ウルフの情報を開示 */
        string w_s = "ウルフ：";
        w_s += PlayerPrefs.GetString("WolfTheme");
        w_s += "\n";

        /* 市民の情報を開示 */
        string c_s = "市民：";
        c_s += PlayerPrefs.GetString("CitizenTheme");
        c_s += "\n";


        /* プレイヤー情報を取得 */
        for ( i= 0; i< player_num; i++)
        {
            PlayerName[i] = PlayerPrefs.GetString("PlayerName" + i.ToString());     /* プレイヤー名を取得 */
            Theme[i]      = PlayerPrefs.GetString("PlayerTheme" + i.ToString());    /* テーマを取得       */
            WolfFlag[i]   = PlayerPrefs.GetInt("PlayerWolfFlag" + i.ToString());    /* ウルフフラグを取得 */

            if(WolfFlag[i] == 1)
            {
                w_s += (PlayerName[i] + "\n");
            }
            else
            {
                c_s += (PlayerName[i] + "\n");
            }
        }


        /* 結果表示 */
        i = PlayerPrefs.GetInt("VotedPlayerId");                                 /* 投票されたプレイヤーのIDを取得 */
        if( WolfFlag[i] != 1 )
        {
            ResultText.text = "ウルフ(少数派)の勝ち";
        }
        else
        {
            ResultText.text = "市民(多数派)の勝ち";
        }


        WolfInfoText.text = w_s;
        CitizenInfoText.text = c_s;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
