using UnityEngine;

public class Horizontal_Projectile : MonoBehaviour
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
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
