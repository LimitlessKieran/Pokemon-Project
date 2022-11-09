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

    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {

    }
 /* private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }*/
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
}
