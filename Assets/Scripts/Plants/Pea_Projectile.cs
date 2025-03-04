using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea_Projectile : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector2.right * 5 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            //collision.gameObject.GetComponent<Zombie>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
