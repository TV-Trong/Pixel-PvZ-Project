using UnityEngine;

public class OffensivePlantTypeA : MonoBehaviour
{
    [Header("Straight line attacking plants")]
    [SerializeField] Plant plant;
    [SerializeField] GameObject projectilePrefab;

    float fireRate;

    Vector3 projectilePosition;

    Animator animator;

    Collider2D hitboxCollider;

    DetectZombieInLane detectZombie;

    GameObject projectileHolder;//Remove when done
    private void Awake()
    {
        fireRate = (plant as PeashooterClass).FireRate;

        projectilePosition = transform.GetChild(0).position;

        animator = GetComponent<Animator>();

        gameObject.GetComponent<SpriteRenderer>().sprite = (plant as PeashooterClass).PlantDisplaySprite;

        projectileHolder = GameObject.FindWithTag("ProjectileHolder");

        hitboxCollider = transform.GetChild(1).GetComponent<Collider2D>();
        detectZombie = transform.GetChild(2).GetComponent<DetectZombieInLane>();
    }

    private void OnEnable()
    {
        InvokeRepeating("ShootTrigger", 0, fireRate);
    }

    private void OnDisable()
    {
        CancelInvoke("ShootTrigger");
    }

    void OnMove()
    {
        projectilePosition = transform.GetChild(0).position;
    }

    void ShootTrigger()
    {
        if (detectZombie.IsZombieDectected())
            animator.SetTrigger("Shoot");
    }

    public void Shoot()
    {
        OnMove();//Remove this later

        GameObject projectile = Instantiate(projectilePrefab, projectilePosition, Quaternion.identity);

        projectile.transform.SetParent(projectileHolder.transform); //Remove when done

        Destroy(projectile, 5f);
    }
}
