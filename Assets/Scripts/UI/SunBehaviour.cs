using UnityEngine;

public class SunBehaviour : MonoBehaviour
{
    [SerializeField] int sunAmount = 25;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] float minFallingTime;
    [SerializeField] float maxFallingTime;

    float fallingTime => Random.Range(minFallingTime, maxFallingTime);
    float timer;
    bool isStopFalling;

    private void OnMouseDown()
    {
        if (GameManager.instance.gameState == GameState.InGame)
        {
            GameManager.instance.GainSun(sunAmount);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        rb.gravityScale = 1;
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
        }
    }

    private void OnDisable()
    {
        isStopFalling = false;
        timer = 0;
    }
}
