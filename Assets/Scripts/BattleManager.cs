using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public GameObject go;
    public GameObject myPokemon , opponentPokemon;
   

    Vector3 yourTeamForest = new Vector3(42.59f, .009f, 44.98f); //6868628
    Vector3 oppTeamForest = new Vector3(25.4567f, 0.15f, 33.15f);
    Vector3 away = new Vector3(25.4567f, 0.15f, 33.15f);

    Vector3 pivot = new Vector3(34f, 0f, 38f);
    Vector3 pivotNight = new Vector3(-5.22f, 0f, -28.03f);

    Vector3 yourTeamNight = new Vector3(-38.8f, 0f, -142.6f); //6868628
    Vector3 oppTeamNight = new Vector3(-36f, 0f, 9.8f);


    public static List<string> battleTeam = new List<string>();

    public static List<int> Bag = new List<int>();



    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        go = GameObject.Find("TeamCreater");

   
        battleTeam = go.GetComponent<SelectPokemon>().PokemonTeam;
        Bag = go.GetComponent<SelectPokemon>().Bag;
        GameObject stageSetting = GameObject.Find("GameManager");
       

        if (stageSetting)
        {
            if (stageSetting.GetComponent<GameManager>().isStageForest)
            {
                myPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[0]);
                myPokemon.transform.position = yourTeamForest;
                myPokemon.transform.LookAt(pivot);

                opponentPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[0]);
                opponentPokemon.transform.position = oppTeamForest;
                opponentPokemon.transform.LookAt(pivot);
            }
            else
            {

                myPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[0]);
                myPokemon.transform.position = yourTeamNight;
                myPokemon.transform.LookAt(pivotNight);

                opponentPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[0]);
                opponentPokemon.transform.position = oppTeamNight;
                opponentPokemon.transform.LookAt(pivotNight);
            }

        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
