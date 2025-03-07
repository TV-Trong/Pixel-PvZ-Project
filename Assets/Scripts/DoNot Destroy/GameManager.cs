using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState; //Change later

    [HideInInspector] public Plant chosenPlant;

    [SerializeField] PlantDatabase plantDatabase;

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
            
        }
        else if (gameState == GameState.GameOver)
        {
            
        }
    }

    public void GetChosenPlant(Plant plant)
    {
        chosenPlant = plant;
    }

    public GameObject GetPlantPrefab()
    {
        if (chosenPlant != null)
            return plantDatabase.GetPlantPrefab(chosenPlant.PlantName);

        return null;
    }

    public void RemoveChosenPlant()
    {
        chosenPlant = null;
    }
}

public enum GameState
{
    MainMenu,
    InGame,
    GameOver
}
