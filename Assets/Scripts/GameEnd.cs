using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public bool ended;
    public GameObject ScoreUI, GameOverUI;
    public Text finalScore, best;
    public Animator animator;
    void Start()
    {
        Time.timeScale = 1;
        ScoreUI.SetActive(true);
        ended = false;
    }

    void Update()
    {
        if(ended)
        {
            FindObjectOfType<Paddle>().GetComponent<Paddle>().enabled = false;
            ScoreUI.SetActive(false);
            GameOverUI.SetActive(true);
            finalScore.text = "Score: " + FindObjectOfType<Score>().score.ToString();
            best.text = "Highscore: " + FindObjectOfType<Score>().highScore.ToString();
            Time.timeScale = 0;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}