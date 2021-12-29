using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;

    public Text highScoreText; //�n�C�X�R�A��\������Text
    private int highScore; //�n�C�X�R�A�p�ϐ�
    private string key = "HIGH SCORE"; //�n�C�X�R�A�̕ۑ���L�[

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameManager.OnCubeSpawned += GameManger_OnCubeSpawned;

        //�ۑ����Ă������n�C�X�R�A���L�[�ŌĂяo���擾���ۑ�����Ă��Ȃ����0�ɂȂ�
        highScore = PlayerPrefs.GetInt(key, 0);
        //�n�C�X�R�A��\��
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

        //�n�C�X�R�A��茻�݃X�R�A��������
        if (score > highScore)
        {

            highScore = score;
            //�n�C�X�R�A�X�V

            PlayerPrefs.SetInt(key, highScore);
            //�n�C�X�R�A��ۑ�

            highScoreText.text = "HighScore: " + highScore.ToString();
            //�n�C�X�R�A��\��
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
