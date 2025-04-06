using System.Collections;
using UnityEngine;

public class SunBehaviour : MonoBehaviour
{
    #region Setup

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private int sunAmount = 25;
    [SerializeField] private float force = 3.5f;
    [SerializeField] private float lifeTimeAfterStopFalling = 10f;
    [SerializeField] private float fadingTime = 3f;

    [Header("Plant Generated Sun")]
    [SerializeField] private float plantGenerated_minFallingTime = 0.8f;
    [SerializeField] private float plantGenerated_maxFallingTime = 1.1f;
    [SerializeField] private float plantGenerated_sunGravity = 1f;
    [SerializeField] private float sunOffset = 0.5f;

    [Header("Natural Generated Sun")]
    [SerializeField] private float naturalGenerated_minFallingTime = 2f;
    [SerializeField] private float naturalGenerated_maxFallingTime = 5f;
    [SerializeField] private float naturalGenerated_sunGravity = 0.5f;

    private float fallingTime = 100f;
    private float timer;
    private bool isStopFalling;
    private int frameSkip;
    private float randomBetweenOffset;
    private Vector2 offsetPosition;
    private SunType sunType;

    public enum SunType
    {
        Natural,
        PlantGenerated
    }

    #endregion

    private void Start()
    {
        frameSkip = GameManager.instance.GetFrameSkip();
    }

    private void OnEnable()
    {
        isStopFalling = false;
        timer = 0;
        rb.gravityScale = 1;
        sr.color = new Color(1f, 1f, 1f, 1f);

        if (sunType == SunType.PlantGenerated)
        {
            randomBetweenOffset = Random.Range(-sunOffset, sunOffset);
            offsetPosition = new Vector2(randomBetweenOffset, 1f).normalized;

            rb.AddForce(offsetPosition * force, ForceMode2D.Impulse); 
            rb.gravityScale = plantGenerated_sunGravity;
            fallingTime = Random.Range(plantGenerated_minFallingTime, plantGenerated_maxFallingTime);
        }
        else
        {
            rb.gravityScale = naturalGenerated_sunGravity;
            fallingTime = Random.Range(naturalGenerated_minFallingTime, naturalGenerated_maxFallingTime);
        }
    }

    private void Update()
    {
        if (isStopFalling)
            return;

        timer += Time.deltaTime;

        if (timer >= fallingTime)
        {
            isStopFalling = true;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;

            StartCoroutine(SlowlyFading());
        }
    }

    public int GetSun()
    {
        return sunAmount;
    }

    public void SetSunType(SunType _sunType)
    {
        sunType = _sunType;
    }

    IEnumerator SlowlyFading()
    {
        yield return new WaitForSeconds(lifeTimeAfterStopFalling - fadingTime);

        int frameCounter = 1;

        for (float i = 0; i < fadingTime; i += Time.deltaTime)
        {
            var alphaColor = i / fadingTime;

            Color newColor = new Color(1f,1f, 1f, Mathf.Lerp(1f, 0f, alphaColor));

            if (frameCounter % frameSkip == 0)
            {
                frameCounter = 1;
                sr.color = newColor;
            }
            else
                frameCounter++;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
