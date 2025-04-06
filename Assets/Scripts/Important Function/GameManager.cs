using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Setup

    public static GameManager instance;

    public GameState gameState;

    [SerializeField] PlantDatabase plantDatabase;

    [SerializeField] int startingSun = 100;

    int currentSun;

    TextMeshProUGUI sunCounter;

    PlantBase_SO chosenPlant;

    int sunCost;

    GameObject seedCover;

    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        plantDatabase.Initialize();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SunCollecting();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameState == GameState.MainMenu)
        {

        }
        else if (gameState == GameState.PlantChoosing)
        {
            sunCounter = GameObject.FindWithTag("SunCounter").GetComponentInChildren<TextMeshProUGUI>();

            currentSun = startingSun;

            sunCounter.text = currentSun.ToString();

            if (sunCounter == null)
            {
                Debug.LogWarning("Sun Counter not found!");
                return;
            }
        }
        else if (gameState == GameState.GameOver)
        {

        }
    }

    private void SunCollecting()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var hit = Physics2D.OverlapPoint(mousePosition, LayerMask.GetMask("Sun"));

        if (hit != null)
        {
            var sun = hit.GetComponent<SunBehaviour>();
            GainSun(sun.GetSun());
            sun.gameObject.SetActive(false);
        }
    }

    public void GainSun(int amount)
    {
        currentSun += amount;
        sunCounter.text = currentSun.ToString();
    }

    public void GetHoldingPlant(PlantBase_SO plant, GameObject coverObject)
    {
        chosenPlant = plant;
        sunCost = plant.SunCost;
        seedCover = coverObject;
    }

    public GameObject GetPlantPrefab()
    {
        return plantDatabase.GetPlantPrefab(chosenPlant.PlantName);
    }

    public void RemoveHoldingPlant()
    {
        chosenPlant = null;
        sunCost = 0;

        seedCover.SetActive(false);
        seedCover = null;
    }

    public bool IsHoldingPlant()
    {
        return chosenPlant != null;
    }

    public bool HaveEnoughSun()
    {
        if (currentSun < sunCost)
        {
            Debug.LogWarning("Not enough sun!");
        }

        return currentSun >= sunCost;
    }

    public void PlantingSuccess()
    {
        currentSun -= sunCost;
        sunCounter.text = currentSun.ToString();

        RemoveHoldingPlant();
    }
}

public enum GameState
{
    MainMenu,
    PlantChoosing,
    InGame,
    GameOver
}
