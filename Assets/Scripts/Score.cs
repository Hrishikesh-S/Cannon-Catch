using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score;
    public int highScore = 0;
    public Text text;
    public Text highScoreText;
    public bool runningGame = true;

    private void Start()
    {
        highScore = 0;
        highScoreText.text = "Best Score: 0";
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        highScore = data.highScore;
    }

    void Update()
    {
        if(runningGame)
        {
            text.text = "Score: " + score.ToString();
            if (highScore < score)
            {
                highScore = score;
                SavePlayer();
            }
            LoadPlayer();
            highScoreText.text = "Best Score: " + highScore.ToString();
        }
    }
    public void ResetScore()
    {
        highScore = 0;
        SavePlayer();
        SceneManager.LoadScene("MainMenu");
    }
}