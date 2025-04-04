using UnityEngine;


[CreateAssetMenu(fileName = "New Peashooter", menuName = "Create New Plant/Offensive/Peashooter Class")]
public class PeashooterPlants_SO : PlantBase_SO
{
    [SerializeField] protected float fireRate = 2f;
    private void Awake()
    {
        plantType = PlantType.Offensive;
        plantClass = PlantClass.Peashooter;
        plantCooldown = 5f;
        plantHealth = 100;
        plantName = "Peashooter";
        sunCost = 100;
    }

    public float FireRate { get { return fireRate; } protected set { fireRate = value; } }
}