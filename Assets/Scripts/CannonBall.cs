using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonBall : MonoBehaviour
{
    void Start()
    {
            Invoke("endGame", 5f);
    }
    void endGame()
    {
        if (transform.position.y < -8f)
        {
            Cannon[] cannons = FindObjectsOfType<Cannon>();
            foreach (Cannon cannon in cannons)
            {
                cannon.GetComponent<Cannon>().enabled = false;
            }
            FindObjectOfType<GameEnd>().ended = true;
            Destroy(gameObject);
        }
        
    }
}