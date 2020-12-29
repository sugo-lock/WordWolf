using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ConfirmTheme : MonoBehaviour
{
    public Text text;
    public Text button_text;


    private static string[] PlayerName;
    private static int[] WolfFlag;
    private static string[] Theme;
    private static int player_num;
    private static int player_id;
    private static int toggle_flag;

    private List<string[]> ThemeList = new List<string[]>();   /* テーマリスト */


    // Start is called before the first frame update
    void Start()
    {
        /* プレイヤー人数を取得 */
        player_num = PlayerPrefs.GetInt("PlayerNum");

        /* プレイヤー名を取得 */
        PlayerName = new string[player_num];

        for (int i = 0; i < player_num; i++)
        {
            PlayerName[i] = PlayerPrefs.GetString("PlayerName" + i.ToString());
        }

        /* 人狼と市民の人数を取得 */
        int wolf_num    = PlayerPrefs.GetInt("WolfNum");
        int citizen_num = PlayerPrefs.GetInt("CitizenNum");


        /* 人狼と市民のお題を決定 */
        ReadTheme();
        int index = Random.Range(0, ThemeList.Count);
        string wolf_theme = ThemeList[index][0];
        string citizen_theme = ThemeList[index][1];

        PlayerPrefs.SetString("WolfTheme", wolf_theme);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("CitizenTheme", citizen_theme);
        PlayerPrefs.Save();


        /* プレイヤーの中からランダムに人狼を決定 */
        WolfFlag = new int[player_num];
        for(int i =0;i< player_num; i++)
        {
            if (i < wolf_num)
            {
                WolfFlag[i] = 1;
            }
            else
            {
                WolfFlag[i] = 0;
            }
        }
        //Fisher-Yatesアルゴリズムでシャッフルする
        System.Random rng = new System.Random();
        int n = WolfFlag.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int tmp = WolfFlag[k];
            WolfFlag[k] = WolfFlag[n];
            WolfFlag[n] = tmp;
        }
        for (int i = 0; i < player_num; i++)
        {
            PlayerPrefs.SetInt("PlayerWolfFlag" + i.ToString(), WolfFlag[i]);
            PlayerPrefs.Save();
        }

        /* プレイヤーのお題を設定 */
        Theme = new string[player_num];

        for (int i = 0; i < player_num; i++)
        {
            if (WolfFlag[i] == 1)
            {
                Theme[i] = wolf_theme;
            }
            else
            {
                Theme[i] = citizen_theme;
            }
            PlayerPrefs.SetString("PlayerTheme" + i.ToString(), Theme[i]);
            PlayerPrefs.Save();

        }

        /* プレイヤー名とお題を表示 */
        //for (int i = 0; i < player_num; i++)
        //{
        //    print(PlayerName[i]);
        //    print(Theme[i]);
        //    print(WolfFlag[i]);
        //}

        player_id = 0;
        toggle_flag = 0;
        text.text = PlayerName[player_id] + "さんが\nこの画面を見てください。\nお題を表示します。\n他のプレイヤーに\n見られないようにして\n表示ボタンを押してください。";
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPushDisplayThemeButton()
    {
        if (player_id < player_num )
        {

            if ( toggle_flag == 0 )
            {
                text.text = PlayerName[player_id] + "さんが\nこの画面を見てください。\n\nお題を表示します。\nよろしいですか？";
                button_text.text = "OK！";
                toggle_flag = 1;
            }
            else if(toggle_flag == 1)
            {
                text.text = PlayerName[player_id] + "さんが\nこの画面を見てください。\n\nお題\n" + Theme[player_id];
                button_text.text = "覚えた！";
                toggle_flag = 2;
                player_id += 1;
            }
            else
            {
                text.text = PlayerName[player_id] + "さんが\nこの画面を見てください。\nお題を表示します。\n他のプレイヤーに\n見られないようにして\n表示ボタンを押してください。";
                button_text.text = "表示";
                toggle_flag = 0;
            }
        }
        else
        {
            SceneManager.LoadScene("PlayingGame"); ;
        }
    }

    /* テーマリストをcsvから読み出す */
    private void ReadTheme()
    {
        // csvファイル名
        var fileName = "ThemeList";
        // Resourcesのcsvフォルダ内のcsvファイルをTextAssetとして取得
        var csvFile = Resources.Load("csv/" + fileName) as TextAsset;
        // csvファイルの内容をStringReaderに変換
        var reader = new StringReader(csvFile.text);

        // csvファイルの内容を一行ずつ末尾まで取得しリストを作成
        while (reader.Peek() > -1)
        {
            // 一行読み込む
            var lineData = reader.ReadLine();
            // カンマ(,)区切りのデータを文字列の配列に変換
            var theme = lineData.Split(',');
            // リストに追加
            ThemeList.Add(theme);
            // 末尾まで繰り返し...
        }

        // ログに読み込んだデータを表示する
        foreach (var theme in ThemeList)
        {
            Debug.Log("DATA:" + theme[0] + " / " + theme[1] );
        }

    }


}






