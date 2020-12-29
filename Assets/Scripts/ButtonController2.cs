using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  */
public class ButtonController2 : MonoBehaviour
{
    public Text WolfNum;
    public Text CitizenNum;
    public Text TalkTime;
    private int player_num;

    // Start is called before the first frame update
    void Start()
    {
        /* プレイヤー人数の初期化 */
        player_num      = PlayerPrefs.GetInt("PlayerNum");
        if(player_num == 0)
        {
            player_num = 3;
        }


        /* 人狼人数の初期化 */
        int wolf_num = 1;
        WolfNum.text    = wolf_num.ToString();
        PlayerPrefs.SetInt("WolfNum", wolf_num);
        PlayerPrefs.Save();


        /* 市民人数の初期化 */
        int citizen_num = player_num - wolf_num;
        CitizenNum.text = citizen_num.ToString();
        PlayerPrefs.SetInt("CitizenNum", citizen_num);
        PlayerPrefs.Save();

        /* トークタイムの初期化 */
        int talk_time = PlayerPrefs.GetInt("TalkTime",1);
        TalkTime.text   = talk_time.ToString();
        PlayerPrefs.SetInt("CitizenNum", talk_time);
        PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*  */
    public void OnPushIncrementWolf()
    {
        int temp0 = int.Parse(WolfNum.text);
        int temp1 = int.Parse(CitizenNum.text);

        if( player_num > ((temp0+1)*2) )
        {
            /* 人狼を一人増やして */
            temp0 += 1;
            WolfNum.text = temp0.ToString();
            PlayerPrefs.SetInt("WolfNum", temp0);
            PlayerPrefs.Save();

            /* 市民を一人減らす */
            temp1 -= 1;
            CitizenNum.text = temp1.ToString();
            PlayerPrefs.SetInt("CitizenNum", temp1);
            PlayerPrefs.Save();
        }
    }

    public void OnPushIncrementCitizen()
    {
        int temp0 = int.Parse(WolfNum.text);
        int temp1 = int.Parse(CitizenNum.text);


        if (temp0 > 1)
        {
            /* 人狼を一人減らして */
            temp0 -= 1;
            WolfNum.text = temp0.ToString();
            PlayerPrefs.SetInt("WolfNum", temp0);
            PlayerPrefs.Save();

            /* 市民を一人増やす */
            temp1 += 1;
            CitizenNum.text = temp1.ToString();
            PlayerPrefs.SetInt("CitizenNum", temp1);
            PlayerPrefs.Save();
        }
    }

    public void OnPushIncrementTalkTime()
    {
        int time = int.Parse(TalkTime.text);
        if (time < 10)
        {
            /* トーク時間を増やす */
            time += 1;
            TalkTime.text = time.ToString();
            PlayerPrefs.SetInt("TalkTime", time);
            PlayerPrefs.Save();
        }
    }

    public void OnPushDecrementTalkTime()
    {
        int time = int.Parse(TalkTime.text);
        if (time > 1)
        {
            /* トーク時間を減らす */
            time -= 1;
            TalkTime.text = time.ToString();
            PlayerPrefs.SetInt("TalkTime", time);
            PlayerPrefs.Save();
        }
    }

}
