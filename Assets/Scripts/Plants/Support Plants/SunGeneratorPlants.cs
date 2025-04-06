using UnityEngine;

public class SunGeneratorPlants : MonoBehaviour
{
    #region Setup

    [Header("Straight line attacking plants")]
    [SerializeField] protected PlantBase_SO plant;
    [SerializeField] protected AnimatorOverrideController animatorOverrideController;
    [SerializeField] protected GameObject sunPrefab;
    [SerializeField] protected Transform sunDropPoint;
    [SerializeField] protected float initialSunSpawnInterval = 5f;

    protected Animator animator;

    protected Collider2D hitboxCollider;

    protected float sunGenerationRate;

    #endregion

    protected void SetupPlant()
    {
        sunGenerationRate = (plant as SunGenerator_SO).SunGenerationRate;

        animator = GetComponent<Animator>();

        gameObject.GetComponent<SpriteRenderer>().sprite = (plant as SunGenerator_SO).PlantDisplaySprite;

        hitboxCollider = transform.GetChild(0).GetComponent<Collider2D>();

        if (animatorOverrideController != null)
            animator.runtimeAnimatorController = animatorOverrideController;
    }

    protected void OnEnable()
    {
        SetupPlant();

        var initialSunSpawn = Random.Range(initialSunSpawnInterval, sunGenerationRate / 2);

        InvokeRepeating(nameof(TriggerSunGenerating), initialSunSpawn, sunGenerationRate);
    }

    protected void OnDisable()
    {
        CancelInvoke(nameof(TriggerSunGenerating));
    }

    protected void TriggerSunGenerating()
    {
        animator.SetTrigger("Activate");
    }

    protected virtual void GenerateSun()
    {
        GameObject sun = PoolingSystem.instance.GetPooledObjects("Sun");
        if (sun == null)
            return;

        sun.transform.position = sunDropPoint.position;
        sun.GetComponent<SunBehaviour>().SetSunType(SunBehaviour.SunType.PlantGenerated);
        sun.SetActive(true);
    }
}
