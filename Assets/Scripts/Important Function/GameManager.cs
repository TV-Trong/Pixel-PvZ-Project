using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState; //Change later

    [SerializeField] PlantDatabase plantDatabase;

    [SerializeField] int currentSun;

    [SerializeField] PoolingSystem poolingSystem;

    TextMeshProUGUI sunCounter;
    PlantBase_SO chosenPlant;
    int sunCost;
    GameObject seedCover;

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
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameState == GameState.MainMenu)
        {
            
        }
        else if (gameState == GameState.InGame)
        {
            sunCounter = GameObject.FindWithTag("SunCounter").GetComponentInChildren<TextMeshProUGUI>();

            if (sunCounter == null)
            {
                Debug.LogWarning("Sun Counter not found!");
                return;
            }

            sunCounter.text = currentSun.ToString();

        }
        else if (gameState == GameState.GameOver)
        {
            
        }
    }

    void StartingSun(int amount) //Call later
    {
        currentSun = amount;
    }

    public void GainSun(int amount)
    {
        currentSun += amount;
        sunCounter.text = currentSun.ToString();
    }

    public void GetChosenPlant(PlantBase_SO plant, GameObject coverObject)
    {
        chosenPlant = plant;
        sunCost = plant.SunCost;
        seedCover = coverObject;
    }

    public GameObject GetPlantPrefab()
    {
        return plantDatabase.GetPlantPrefab(chosenPlant.PlantName);
    }

    public void RemoveChosenPlant()
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

        RemoveChosenPlant();
    }
}

public enum GameState
{
    MainMenu,
    InGame,
    GameOver
}
