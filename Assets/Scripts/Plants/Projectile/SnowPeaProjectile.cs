using UnityEngine;

public class SnowPeaProjectile : PlantProjectileBase
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            collision.GetComponent<ZombieBase>().TakeDamage((int)(baseDamge * damageAmp));
            collision.GetComponent<ZombieBase>().GetChilled();
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
