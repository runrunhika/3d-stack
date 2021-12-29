using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;

    public Text highScoreText; //ハイスコアを表示するText
    private int highScore; //ハイスコア用変数
    private string key = "HIGH SCORE"; //ハイスコアの保存先キー

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameManager.OnCubeSpawned += GameManger_OnCubeSpawned;

        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScore = PlayerPrefs.GetInt(key, 0);
        //ハイスコアを表示
        highScoreText.text = "HighScore: " + highScore.ToString();
        
    }
    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= GameManger_OnCubeSpawned;
    }

    private void GameManger_OnCubeSpawned()
    {
        score++;
        text.text = "Score" + score;

        //ハイスコアより現在スコアが高い時
        if (score > highScore)
        {

            highScore = score;
            //ハイスコア更新

            PlayerPrefs.SetInt(key, highScore);
            //ハイスコアを保存

            highScoreText.text = "HighScore: " + highScore.ToString();
            //ハイスコアを表示
        }
    }

    private void FixedUpdate()
    {
        if (score > 15)
        {
            GameManager.instance.ChangeSkybox(0);

            if (score > 35)
            {
                GameManager.instance.ChangeSkybox(1);

                if (score > 80)
                {
                    GameManager.instance.ChangeSkybox(2);
                }
            }
        }
    }
}
