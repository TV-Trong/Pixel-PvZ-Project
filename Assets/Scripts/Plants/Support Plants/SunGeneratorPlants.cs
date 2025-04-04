using UnityEngine;

public class SunGeneratorPlants : MonoBehaviour
{
    #region Setup

    [Header("Straight line attacking plants")]
    [SerializeField] protected PlantBase_SO plant;
    [SerializeField] protected AnimatorOverrideController animatorOverrideController;
    [SerializeField] protected GameObject sunPrefab;
    [SerializeField] protected Transform sunDropPoint;

    protected Animator animator;

    protected Collider2D hitboxCollider;

    protected float sunGenerationRate;

    #endregion

    protected void Awake()
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
        var initTime = Random.Range(5, sunGenerationRate);
        InvokeRepeating(nameof(TriggerSunGenerating), initTime, sunGenerationRate);
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

        sun.SetActive(true);
        sun.transform.position = sunDropPoint.position;
    }
}
