using UnityEngine;

public class OffensivePlantTypeA : MonoBehaviour
{
    #region Setup

    [Header("Straight line attacking plants")]
    [SerializeField] protected PlantBase_SO plant;
    [SerializeField] protected AnimatorOverrideController animatorOverrideController;
    [SerializeField] protected PlantProjectileType projectileType;

    protected float fireRate;

    protected Vector3 projectilePosition;

    protected Animator animator;

    protected Collider2D hitboxCollider;

    protected DetectZombieInLane detectZombie;

    #endregion

    protected void Awake()
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
        InvokeRepeating(nameof(ShootTrigger), 0, fireRate);
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
