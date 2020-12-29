using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public Text TalkTimeText;
    public Text StopStartButtonText;

    private static int talk_time;
    float time = 0.0f;
    bool stop_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        /* トークタイムの初期化 */
        talk_time = PlayerPrefs.GetInt("TalkTime");
        talk_time *= 60;

        disp_time(talk_time);

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if( time > 1.0f )
        {
            if( ( talk_time > 0 ) && (stop_flag == false) )
            {
                talk_time -= 1;
                disp_time(talk_time);
            }

            time -= 1.0f;
        }

        if( talk_time == 0 )
        {
            SceneManager.LoadScene("Vote");
        }

    }


    private void disp_time( int talktime )
    {
        int min = talktime / 60;
        int sec = talktime % 60;

        TalkTimeText.text = min.ToString() + ":" + sec.ToString("d2");
    }


    public void OnPushPlus()
    {
        if( (talk_time/60) < 9 )
        {
            talk_time += 60;
        }
        disp_time(talk_time);
    }


    public void OnPushMinus()
    {
        if ((talk_time / 60) > 0)
        {
            talk_time -= 60;
        }
        disp_time(talk_time);

    }

    public void OnPushStop()
    {
        if (stop_flag == true)
        {
            stop_flag = false;
            StopStartButtonText.text = "ストップ";
        }
        else
        {
            stop_flag = true;
            StopStartButtonText.text = "スタート";
        }
    }

    public void OnPushEnd()
    {
        SceneManager.LoadScene("Vote");
    }

}
