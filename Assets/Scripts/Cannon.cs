using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject[] balls;
    public Transform firePoint;
    Animator animator;
    public string animationName;
    public GameObject particles;
    AudioManager manager;
    Vector3 firepoint;
    private void Start()
    {
        animator = GetComponent<Animator>();
        firepoint = firePoint.position;
        animator.SetBool("Shooting", false);
        manager = FindObjectOfType<AudioManager>();
    }
    public void Shoot()
    {
        int random = Random.Range(0, 8);
        if (random <= 5)
            random = 1;
        else if (random > 5)
            random = 0;
        GameObject ball = Instantiate(balls[random], firepoint, Quaternion.identity);
        GameObject explosion = Instantiate(particles, firepoint + Vector3.forward * 10, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(firePoint.right * Random.Range(2.5f,8f), ForceMode2D.Impulse);

        manager.Play("Shoot Sound " + random.ToString());
        animator.Play(animationName);
        Destroy(explosion, 2f);
    }

}