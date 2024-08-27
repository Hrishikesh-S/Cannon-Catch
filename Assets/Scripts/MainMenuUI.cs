using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Text highscoreText;
    private void Start()
    {
        if (SaveSystem.LoadPlayer()==null)
            highscoreText.text = "Best Score:\n0";
        highscoreText.text = "Best Score:\n"+SaveSystem.LoadPlayer().highScore.ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ResetScore()
    {
        SceneManager.LoadScene("ResetSave");
    }

    public void Quit()
    {
        Application.Quit();
    }
}