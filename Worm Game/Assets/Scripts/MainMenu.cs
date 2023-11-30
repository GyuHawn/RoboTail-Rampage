using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject uiMenu;
    public GameObject scoreMenu;

    public List<int> scores = new List<int>();

    public TMP_Text scoreText;

    void Start()
    {
        // ����� ��� ���� ���� �ҷ�����
        string existingKeys = PlayerPrefs.GetString("ScoreKeys", "");
        if (!string.IsNullOrEmpty(existingKeys))
        {
            string[] keys = existingKeys.Split(',');
            foreach (var key in keys)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    int score = PlayerPrefs.GetInt(key);
                    scores.Add(score);
                }
            }
        }

        // ���� ���� (��������)
        scores.Sort((a, b) => b.CompareTo(a));

        // ���� 5�� ������ ����
        if (scores.Count > 5)
        {
            scores.RemoveRange(5, scores.Count - 5);
        }

        // ���� ǥ��
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "";
        for (int i = 0; i < scores.Count; i++)
        {
            scoreText.text += scores[i].ToString() + "\n";
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnScoreMenu()
    {
        uiMenu.SetActive(false);
        scoreMenu.SetActive(true);
    }

    public void OffScoreMenu()
    {
        uiMenu.SetActive(true);
        scoreMenu.SetActive(false);
    }
}