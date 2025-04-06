using UnityEngine;

public class LinearShooterPlants : MonoBehaviour
{
    #region Setup

    [SerializeField] protected PlantBase_SO plant;
    [SerializeField] protected AnimatorOverrideController animatorOverrideController;
    [SerializeField] protected PlantProjectileType projectileType;
    [SerializeField] protected float minFireRateInterval;

    protected float fireRate;

    protected Vector3 projectilePosition;

    protected Animator animator;

    protected Collider2D hitboxCollider;

    protected DetectZombieInLane detectZombie;

    #endregion

    protected void SetupPlant()
    {
        fireRate = (plant as PeashooterPlants_SO).FireRate;

        projectilePosition = transform.GetChild(0).position;

        animator = GetComponent<Animator>();

        gameObject.GetComponent<SpriteRenderer>().sprite = (plant as PeashooterPlants_SO).PlantDisplaySprite;

        hitboxCollider = transform.GetChild(1).GetComponent<Collider2D>();
        detectZombie = transform.GetChild(2).GetComponent<DetectZombieInLane>();

        if (animatorOverrideController != null)
            animator.runtimeAnimatorController = animatorOverrideController;
    }

    protected void OnEnable()
    {
        SetupPlant();

        float initialShot = Random.Range(minFireRateInterval, fireRate);
        InvokeRepeating(nameof(ShootTrigger), initialShot, fireRate);
    }

    protected void OnDisable()
    {
        CancelInvoke(nameof(ShootTrigger));
    }

    protected void ShootTrigger()
    {
        if (detectZombie.IsZombieDectected())
            animator.SetTrigger("Shoot");
    }

    protected virtual void Shoot()
    {
        GameObject projectile = PoolingSystem.instance.GetPooledObjects(projectileType.ToString()); //Change later
        if (projectile == null)
            return;

        projectile.SetActive(true);
        projectile.transform.position = projectilePosition;
    }
}
