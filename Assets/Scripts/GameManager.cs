using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum Type { GRASS, WATER, FIRE, ELECTRIC, FLYING, FIGHTING, NORMAL };
    public List<string> PokemonTeam = new List<string>(){ "1", "2", "3" };
    public static GameManager gameManagerInstance;
    public GameObject go;
    public bool isStageForest, isStageNight;
    void Start()
    {
        isStageForest = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (gameManagerInstance != this)
        {
            Destroy(gameObject);
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public List<string> GetPokemonTeam()
    {
        return PokemonTeam;
    }

    public void selectStageForest()
    {
        isStageForest = true;
        isStageNight = false;
       
    }

    public void selectStageNight()
    {
        isStageForest = false;
        isStageNight = true;
        print("im here");
    }
}
