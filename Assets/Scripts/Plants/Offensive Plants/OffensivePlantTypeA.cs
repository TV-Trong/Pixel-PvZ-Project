using UnityEngine;

public class OffensivePlantTypeA : MonoBehaviour
{
    [Header("Straight line attacking plants")]
    [SerializeField] protected Plant plant;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected AnimatorOverrideController animatorOverrideController;

    protected float fireRate;

    protected Vector3 projectilePosition;

    protected Animator animator;
    
    protected Collider2D hitboxCollider;
    
    protected DetectZombieInLane detectZombie;
    protected void Awake()
    {
        fireRate = (plant as PeashooterClass).FireRate;

        projectilePosition = transform.GetChild(0).position;

        animator = GetComponent<Animator>();

        gameObject.GetComponent<SpriteRenderer>().sprite = (plant as PeashooterClass).PlantDisplaySprite;

        hitboxCollider = transform.GetChild(1).GetComponent<Collider2D>();
        detectZombie = transform.GetChild(2).GetComponent<DetectZombieInLane>();

        if (animatorOverrideController != null)
            animator.runtimeAnimatorController = animatorOverrideController;
    }

    protected void OnEnable()
    {
        InvokeRepeating("ShootTrigger", 0, fireRate);
    }

    protected void OnDisable()
    {
        CancelInvoke("ShootTrigger");
    }

    protected void ShootTrigger()
    {
        if (detectZombie.IsZombieDectected())
            animator.SetTrigger("Shoot");
    }

    protected virtual void Shoot()
    {
        GameObject projectile = GameManager.instance.GetPooledObject(0); //Change later

        projectile.SetActive(true);
        projectile.transform.position = projectilePosition;
    }
}
