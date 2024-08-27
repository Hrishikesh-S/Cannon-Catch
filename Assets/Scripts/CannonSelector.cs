using System.Collections;
using UnityEngine;

public class CannonSelector : MonoBehaviour
{
    public float interval;
    public Cannon[] cannons;
    void Start()
    {
        StartCoroutine(ChooseCannonToShoot());
        StartCoroutine(AdjustSpeed());
    }

    IEnumerator ChooseCannonToShoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            int randomCannon = Random.Range(0, cannons.Length);
            cannons[randomCannon].Shoot();
        }
    }
    IEnumerator AdjustSpeed()
    {
        while (interval >= 0.45f)
        {
            yield return new WaitForSeconds(5);
            interval -= 0.05f;
        }
    }
}
