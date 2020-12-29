using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneContoroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // プレイヤー設定への遷移
    public void OnPushStartButton()
    {
        SceneManager.LoadScene("PlayerSetting");
    }

    // ゲーム設定への遷移
    public void OnGemeSettingScene()
    {
        SceneManager.LoadScene("GameSetting");
    }

    // お題確認画面への遷移
    public void OnPreparationScene()
    {
        SceneManager.LoadScene("Preparation");
    }

    // ゲームメイン画面への遷移
    public void OnPlayingGamenScene()
    {
        SceneManager.LoadScene("PlayingGame");
    }
    // タイトル画面への遷移
    public void OnTitleScene()
    {
        SceneManager.LoadScene("Title");

    }
    // 遊び方への遷移
    public void OnHowToScene()
    {
        SceneManager.LoadScene("How_to_Play");

    }
}
