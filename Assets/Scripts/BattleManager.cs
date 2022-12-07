using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public GameObject go;
    public GameObject myPokemon , opponentPokemon, shield, xAttackBuff;   

    // -73.81 1.479887 -161.6
    Vector3 yourTeamForest = new Vector3(42.59f, .009f, 44.98f); //6868628
    Vector3 oppTeamForest = new Vector3(25.4567f, 0.15f, 33.15f);
    Vector3 away = new Vector3(25.4567f, -20.0f, 33.15f);
    Vector3 awayNight = new Vector3(70.4567f, -20.0f, 33.15f);

    Vector3 pivot = new Vector3(34f, 0f, 38f);
    Vector3 pivotNight = new Vector3(-5.22f, 0f, -28.03f);

    Vector3 yourTeamNight = new Vector3(-3f, 0f, -80f);
    Vector3 yourTeamHealth = new Vector3(-3f, 4.4f, -80f);
    Vector3 oppTeamNight = new Vector3(-3f, 0f, 19);

    Vector3 posShieldForest = new Vector3(37.69f, 2.32f, 43.16f);

    Vector3 posShieldNight = new Vector3(-3f, 8f, -55f);

    public static List<string> battleTeam = new List<string>();

    public static List<int> Bag = new List<int>();

    GameObject stageSetting, healthParticle, elixirParticle;

    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        go = GameObject.Find("TeamCreater");
        
        battleTeam = go.GetComponent<SelectPokemon>().PokemonTeam;
        
        stageSetting = GameObject.Find("GameManager");
        healthParticle = GameObject.Find("Health Particle");

        xAttackBuff = GameObject.Find("xAttackBuff");
        elixirParticle = GameObject.Find("Elixir Particle");

        xAttackBuff.SetActive(false);
        healthParticle.SetActive(false);
        elixirParticle.SetActive(false);
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
                print("im at Night");
            }
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (stageSetting)
        {
            if (stageSetting.GetComponent<GameManager>().isStageForest)
            {
                myPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[0]);
                myPokemon.transform.position = yourTeamForest;
                myPokemon.transform.LookAt(pivot);
                GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[1]).transform.position = away;
                GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[2]).transform.position = away;

                opponentPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[0]);
                opponentPokemon.transform.position = oppTeamForest;
                opponentPokemon.transform.LookAt(pivot);
                GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[1]).transform.position = away;
                GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[2]).transform.position = away;
            }
            else
            {
                myPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[0]);
                myPokemon.transform.position = yourTeamNight;
                myPokemon.transform.LookAt(pivotNight);
                GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[1]).transform.position = awayNight;
                GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[2]).transform.position = awayNight;

                opponentPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[0]);
                opponentPokemon.transform.position = oppTeamNight;
                opponentPokemon.transform.LookAt(pivotNight);
                GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[1]).transform.position = awayNight;
                GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[2]).transform.position = awayNight;
            }
        }
        shield.transform.RotateAround(myPokemon.transform.position, myPokemon.transform.up, .2f + Time.deltaTime);
        xAttackBuff.transform.RotateAround(myPokemon.transform.position, myPokemon.transform.up, .4f + Time.deltaTime);
    }

    // function for placing the shield infront of your pokemon 
    public void shieldActivated()
    {
        if (stageSetting.GetComponent<GameManager>().isStageForest)
        {
            shield.transform.position = posShieldForest;
        }
        else
        {
            shield.transform.position = posShieldNight;
        }
    }

    public void shieldDeactivated()
    {
        shield.transform.position = away;

    }
    public void healthActivated()
    {

        if (stageSetting.GetComponent<GameManager>().isStageForest)
        {
            healthParticle.transform.position = yourTeamForest;
        }
        else
        {
            healthParticle.transform.position = yourTeamHealth;
        }
        healthParticle.SetActive(true);
    }

    public void healthDeactivated()
    {

        healthParticle.SetActive(false);
    }

    public void xAttackActivated()
    {
        if (stageSetting.GetComponent<GameManager>().isStageForest)
        {
            xAttackBuff.transform.position = posShieldForest;
        }
        else
        {
            xAttackBuff.transform.position = posShieldNight;
        }
        xAttackBuff.SetActive(true);
    }

    public void xAttackDeactivated()
    {
        shield.transform.position = away;
        xAttackBuff.SetActive(false);

    }

    public void elixirActivated()
    {

        if (stageSetting.GetComponent<GameManager>().isStageForest)
        {
            elixirParticle.transform.position = yourTeamForest;
        }
        else
        {
            elixirParticle.transform.position = yourTeamNight;
        }
        elixirParticle.SetActive(true);
    }

    public void elixirDeactivated()
    {

        elixirParticle.SetActive(false);
    }
}
