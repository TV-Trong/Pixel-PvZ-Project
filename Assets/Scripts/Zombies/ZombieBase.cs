using System.Collections;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{
    #region Setup Properties
    protected string zombieName;
    protected int zombieHealth;
    protected int zombieDamage;
    protected float attackSpeed;
    protected float zombieSpeed;
    #endregion

    [SerializeField] protected ZombieProperties_SO zombieProperties;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected SpriteRenderer sr;

    protected Coroutine chilledCoroutine;

    protected void Awake()
    {
        zombieName = zombieProperties.zombieName;
        zombieHealth = zombieProperties.health;
        zombieDamage = zombieProperties.damage;
        attackSpeed = zombieProperties.attackSpeed;
        zombieSpeed = zombieProperties.speed;

        rb.velocity = new Vector2(-zombieSpeed, 0);
    }

    protected void OnDisable()
    {
        if (chilledCoroutine != null)
        {
            StopCoroutine(chilledCoroutine);
            chilledCoroutine = null;
        }
    }

    public void TakeDamage(int damage)
    {
        zombieHealth -= damage;
        if (zombieHealth <= 0)
        {
            gameObject.SetActive(false); // Change to pool later
        }
    }

    public void GetChilled()
    {
        if (chilledCoroutine != null)
            StopCoroutine(chilledCoroutine);
        else if (gameObject.activeInHierarchy)
            chilledCoroutine = StartCoroutine(StartSlow());
    }

    IEnumerator StartSlow()
    {
        rb.velocity = new Vector2(-zombieSpeed / 2, 0);
        sr.color = Color.blue;

        yield return new WaitForSeconds(3f);

        rb.velocity = new Vector2(-zombieSpeed, 0);
        sr.color = Color.white;
        chilledCoroutine = null;
    }
}
