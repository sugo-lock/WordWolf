using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VoteController : MonoBehaviour
{
    public GameObject VoteButtonObj;

    private static string PlayerName;
    private static GameObject[] VoteButton;
    private static int player_num;

    private float SHIFT_POS_Y = 90.0f;
    private float INIT_POS = 210.0f;
    private Vector3 size = new Vector3(1.0f, 1.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        /* プレイヤー人数を取得 */
        player_num = PlayerPrefs.GetInt("PlayerNum");

        VoteButton = new GameObject[player_num];

        for (int i = 0; i < player_num; i++)
        {
            VoteButton[i] = Instantiate(VoteButtonObj, new Vector3(0, 0, 0), VoteButtonObj.transform.rotation);
            VoteButton[i].transform.parent = this.transform;
            VoteButton[i].transform.localPosition = new Vector3(0.0f, INIT_POS - i * SHIFT_POS_Y, 0.0f);
            VoteButton[i].transform.localScale = size;
            VoteButton[i].name = "PlayerVoteButton" + i.ToString();

            PlayerName = PlayerPrefs.GetString("PlayerName" + i.ToString());    /* プレイヤー名を取得 */
            VoteButton[i].GetComponentInChildren<Text>().text = PlayerName + "に投票する";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
