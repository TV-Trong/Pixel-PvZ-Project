using UnityEngine;

public class PlantProjectileBase : MonoBehaviour
{
    #region Setup

    public const int baseDamge = 10;

    [HideInInspector] public PlantProjectileType projectileType;
    [HideInInspector] public float damageAmp = 1;

    #endregion

    protected virtual void Awake()
    {
        projectileType = PlantProjectileType.Pea;
    }

    protected void Update()
    {
        transform.Translate(Vector2.right * 5 * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            collision.GetComponent<ZombieBase>().TakeDamage((int)(baseDamge * damageAmp));
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}

public enum PlantProjectileType
{
    Pea,
    PeaSnow,
    PeaFire,
}
