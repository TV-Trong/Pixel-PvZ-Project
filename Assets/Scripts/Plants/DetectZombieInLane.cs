using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZombieInLane : MonoBehaviour
{
    List<GameObject> zombiesInLane = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            zombiesInLane.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            zombiesInLane.Remove(collision.gameObject);
        }
    }

    public bool IsZombieDectected()
    {
        return zombiesInLane.Count > 0;
    }
}
