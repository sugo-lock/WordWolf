using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReConfirmButtonController : MonoBehaviour
{
    private static string PlayerName;
    private static int WolfFlag;
    private static string Theme;
    private static int[] ToggleFlag;

    private static int player_num;

    // Start is called before the first frame update
    void Start()
    {
        /* プレイヤー人数を取得 */
        player_num = PlayerPrefs.GetInt("PlayerNum");

        ToggleFlag = new int[player_num];

        OnGetPlayerInfo();
        this.GetComponentInChildren<Text>().text = PlayerName + "のお題を再確認する";

        for( int i = 0; i < player_num; i++ )
        {
            ToggleFlag[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPushReConfirmButton()
    {
        int i = int.Parse(this.name.Replace("PlayerConfirmButton", ""));

        if (ToggleFlag[i] == 1)
        {
            OnGetPlayerInfo();
            this.GetComponentInChildren<Text>().text = PlayerName + "のお題を再確認する";
            ToggleFlag[i] = 0;
        }
        else
        {
            OnGetPlayerInfo();
            this.GetComponentInChildren<Text>().text = PlayerName + "のお題は" + Theme;
            ToggleFlag[i] = 1;
        }
    }


    void OnGetPlayerInfo()
    {
        int i = int.Parse(this.name.Replace("PlayerConfirmButton", ""));
        PlayerName = PlayerPrefs.GetString("PlayerName" + i.ToString());    /* プレイヤー名を取得 */
        Theme = PlayerPrefs.GetString("PlayerTheme" + i.ToString());   /* プレイヤーのお題を取得 */
    }
}
