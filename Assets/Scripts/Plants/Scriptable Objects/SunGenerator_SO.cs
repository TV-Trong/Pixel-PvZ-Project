using UnityEngine;

[CreateAssetMenu(fileName = "New Sun Generator", menuName = "Create New Plant/Support/Sun Generator")]
public class SunGenerator_SO : PlantBase_SO
{
    [SerializeField] protected float sunGenerationRate = 25f;

    private void Awake()
    {
        plantType = PlantType.Support;
        plantClass = PlantClass.Sunflower;
        plantCooldown = 5f;
        plantHealth = 100;
        plantName = "Sunflower";
        sunCost = 50;
    }

    public float SunGenerationRate { get { return sunGenerationRate; } protected set { sunGenerationRate = value; } }
}
