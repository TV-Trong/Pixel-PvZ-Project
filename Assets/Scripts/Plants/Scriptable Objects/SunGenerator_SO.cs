using UnityEngine;

[CreateAssetMenu(fileName = "New Sun Generator", menuName = "Create New Plant/Support/Sun Generator")]
public class SunGenerator_SO : PlantBase_SO
{
    [SerializeField] protected float sunGenerationRate = 25f;

    public float SunGenerationRate { get { return sunGenerationRate; } protected set { sunGenerationRate = value; } }
}
