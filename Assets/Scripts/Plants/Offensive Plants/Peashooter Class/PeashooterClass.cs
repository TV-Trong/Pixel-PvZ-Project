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
    public PlantType PlantType { get { return plantType; } protected set { plantType = value; } }
    public float PlantCooldown { get { return plantCooldown; } protected set { plantCooldown = value; } }
    public int PlantHealth { get { return plantHealth; } protected set { plantHealth = value; } }
    public int SunCost { get { return sunCost; } protected set { sunCost = value; } }
    public string PlantName { get { return plantName; } protected set { plantName = value; } }
    public PlantClass PlantClass { get { return plantClass; } protected set { plantClass = value; } }
    public Sprite PlantDisplaySprite { get { return plantDisplaySprite; } protected set { plantDisplaySprite = value; } }
}