[System.Serializable]
public class PlayerData
{
    public int highScore;
    
    public PlayerData(Score playerScore)
    {
        highScore = playerScore.highScore;
    }
}