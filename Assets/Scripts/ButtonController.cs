using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Text ninzu;
    public GameObject PlayerName;

    private static GameObject[] PlayerNameObj;
    private int MAX_NINZU = 10;
    private int MIN_NINZU = 3;
    private float SHIFT_POS_Y = 80.0f;
    private float INIT_POS = 300.0f;
    private Vector3 size = new Vector3(2.5f, 2.5f, 2.5f);


    // Start is called before the first frame update
    void Start()
    {
        /* プレイヤー人数の初期化 */
        PlayerNameObj = new GameObject[MAX_NINZU];

        int temp = PlayerPrefs.GetInt("PlayerNum");
        if(temp ==0)
        {
            temp = int.Parse(ninzu.text);
        }
        ninzu.text = temp.ToString();
        PlayerPrefs.SetInt("PlayerNum", temp);
        PlayerPrefs.Save();

        for ( int i=0; i< temp; i++)
        {
            PlayerNameObj[i] = Instantiate(PlayerName, new Vector3(0, 0, 0), PlayerName.transform.rotation);
            PlayerNameObj[i].transform.parent = this.transform;
            PlayerNameObj[i].transform.localPosition = new Vector3(0.0f, INIT_POS - i * SHIFT_POS_Y, 0.0f);
            PlayerNameObj[i].transform.localScale    = size;
            PlayerNameObj[i].name = "PlayerName"+i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPushIncrementPlayer()
    {
        if( int.Parse(ninzu.text) < MAX_NINZU )
        {
            int temp = int.Parse(ninzu.text) + 1;
            ninzu.text = temp.ToString();

            PlayerNameObj[temp - 1] = Instantiate(PlayerName, new Vector3(0, 0, 0), PlayerName.transform.rotation);
            PlayerNameObj[temp - 1].transform.parent = this.transform;
            PlayerNameObj[temp - 1].transform.localPosition = new Vector3(0.0f, (INIT_POS - (temp-1) * SHIFT_POS_Y), 0.0f);
            PlayerNameObj[temp - 1].transform.localScale = size;
            PlayerNameObj[temp - 1].name = "PlayerName" + (temp-1).ToString();

            PlayerPrefs.SetInt("PlayerNum", temp);
            PlayerPrefs.Save();
        }
    }

    public void OnPushDecrementPlayer()
    {
        if (int.Parse(ninzu.text) > MIN_NINZU)
        {
            int temp = int.Parse(ninzu.text) - 1;
            Destroy(PlayerNameObj[temp], 0.01f);
            ninzu.text = temp.ToString();

            PlayerPrefs.SetInt("PlayerNum", temp);
            PlayerPrefs.Save();
        }
    }

}
