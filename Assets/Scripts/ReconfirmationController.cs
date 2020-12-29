using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReconfirmationController : MonoBehaviour
{
    public GameObject ConfirmButtonObj;

    private static GameObject[] ConfirmButton;
    private static int player_num;

    private float SHIFT_POS_Y = 90.0f;
    private float INIT_POS = 210.0f;
    private Vector3 size = new Vector3(1.0f, 1.0f, 1.0f);


    // Start is called before the first frame update
    void Start()
    {
        /* プレイヤー人数を取得 */
        player_num = PlayerPrefs.GetInt("PlayerNum");

        ConfirmButton = new GameObject[player_num];

        for (int i = 0; i < player_num; i++)
        {
            ConfirmButton[i] = Instantiate(ConfirmButtonObj, new Vector3(0, 0, 0), ConfirmButtonObj.transform.rotation);
            ConfirmButton[i].transform.parent = this.transform;
            ConfirmButton[i].transform.localPosition = new Vector3(0.0f, INIT_POS - i * SHIFT_POS_Y, 0.0f);
            ConfirmButton[i].transform.localScale = size;
            ConfirmButton[i].name = "PlayerConfirmButton" + i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
