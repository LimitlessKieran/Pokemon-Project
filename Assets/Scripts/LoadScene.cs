using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPokemon()
    {
        GameObject manager = GameObject.Find("GameManager");

        manager.GetComponent<GameManager>().LoadScene("PokemonList");
    }
    public void LoadBattle()
    {
        GameObject manager = GameObject.Find("GameManager");

        manager.GetComponent<GameManager>().LoadScene("SelectScene");
    }
    public void LoadSettings()
    {
        GameObject manager = GameObject.Find("GameManager");

        manager.GetComponent<GameManager>().LoadScene("Settings");
    }
    public void LoadMain()
    {
        GameObject manager = GameObject.Find("GameManager");

        manager.GetComponent<GameManager>().LoadScene("MainScene");
    }
}
