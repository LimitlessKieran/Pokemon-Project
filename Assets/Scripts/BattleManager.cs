using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public GameObject go;
    public GameObject myPokemon , opponentPokemon;
   

    Vector3 yourTeam = new Vector3(42.59f, .009f, 44.98f); //6868628
    Vector3 oppTeam = new Vector3(25.4567f, 0.15f, 33.15f);
    Vector3 away = new Vector3(25.4567f, 0.15f, 33.15f);
    Vector3 pivot = new Vector3(34f, 0f, 38f);


    public static List<string> battleTeam = new List<string>();
    public static List<string> opponentTeam = new List<string>();
    public List<string> allPokemon = new List<string>();

   

    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        go = GameObject.Find("TeamCreater");

        allPokemon.Add("Charizard");
        allPokemon.Add("Sceptile");
        allPokemon.Add("Pikachu");
        allPokemon.Add("Feraligatr");
        allPokemon.Add("Aerodactyl");
        allPokemon.Add("Gallade");

        battleTeam = go.GetComponent<SelectPokemon>().PokemonTeam;
        for (int i = 0; i < allPokemon.Count - 1; i++)
        {

            if (battleTeam.Contains(allPokemon[i]))
            {

            }
            else
            {
                opponentTeam.Add(allPokemon[i]);
            }
        }

        myPokemon = GameObject.Find(battleTeam[0]);
        myPokemon.transform.position = yourTeam;
        myPokemon.transform.LookAt(pivot);

        opponentPokemon = GameObject.Find(opponentTeam[0]);
        opponentPokemon.transform.position = oppTeam;
        opponentPokemon.transform.LookAt(pivot);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
