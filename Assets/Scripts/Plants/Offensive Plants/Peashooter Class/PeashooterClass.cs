using UnityEngine;


[CreateAssetMenu(fileName = "New Peashooter", menuName = "Create New Plant/Offensive/Peashooter Class")]
public class PeashooterClass : Plant
{
    [SerializeField] protected float fireRate;
    private void Awake()
    {
        plantType = PlantType.Offensive;
        plantClass = PlantClass.Peashooter;
        plantCooldown = 5f;
        plantHealth = 100;
        sunCost = 100;
        plantName = "Peashooter";
    }

    public float FireRate { get { return fireRate; } protected set { fireRate = value; } }
}