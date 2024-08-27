using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Camera main;
    Score score;
    bool click;
    Vector2 mousePos;
    public GameObject enemyParticles;
    public GameObject goodParticles;
    public AudioManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        main = Camera.main;
        score = FindObjectOfType<Score>();
    }
    private void Update()
    {
        click = false;

        if (Input.touchCount>0)
        {
            click = true;
            mousePos = main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
    }
    private void FixedUpdate()
    {
        if(click)
            rb.position = new Vector2(Mathf.Lerp(rb.position.x, mousePos.x, 40f * Time.fixedDeltaTime), -3.3f);
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, -3.5f, 3.5f), -3.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject particles = Instantiate(enemyParticles, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(particles, 2f);
            this.enabled = false;
            Invoke("EndTheGame", 1f);
        }
        else
        {
            GameObject particles = Instantiate(goodParticles, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(particles, 2f);
            score.score++;
            manager.Play("Collect " + Random.Range(0, 8).ToString());
        }
        Destroy(collision.gameObject);
    }
    void EndTheGame()
    {
        Cannon[] cannons = FindObjectsOfType<Cannon>();
        foreach (Cannon cannon in cannons)
        {
            cannon.GetComponent<Cannon>().enabled = false;
        }
        FindObjectOfType<GameEnd>().ended = true;
    }
}