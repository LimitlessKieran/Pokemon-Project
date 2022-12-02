using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleUI : MonoBehaviour
{
    GameObject attackPanel;
    GameObject itemPanel;
    GameObject partyPanel;

    HealthBar playerHealthBar;
    HealthBar opponentHealthBar;

    int currentPlayerHealth;
    int currentOpponentHealth;

    GameObject currentPlayerPokemon;
    GameObject currentOpponentPokemon;
    
    GameObject attackButton1;
    GameObject attackButton2;
    GameObject attackButton3;
    GameObject attackButton4;

    string move1;
    string move2;
    string move3;
    string move4;

    TMP_Text attackButtonText1;
    TMP_Text attackButtonText2;
    TMP_Text attackButtonText3;
    TMP_Text attackButtonText4;

    TMP_Text playerPokemonName;
    TMP_Text opponentPokemonName;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerPokemon = GameObject.Find("Charizard");
        currentOpponentPokemon = GameObject.Find("Aerodactyl");

        playerPokemonName = GameObject.Find("PokemonName").GetComponent<TMP_Text>();
        playerPokemonName.SetText("Charizard");

        opponentPokemonName = GameObject.Find("OpponentName").GetComponent<TMP_Text>();
        opponentPokemonName.SetText("Aerodactyl");

        playerHealthBar = GameObject.Find("PlayerHealthBar").GetComponent<HealthBar>();
        opponentHealthBar = GameObject.Find("OpponentHealthBar").GetComponent<HealthBar>();

        currentOpponentHealth = 100;
        currentPlayerHealth = 100;

        move1 = currentPlayerPokemon.GetComponent<Charizard>().getMove1();
        move2 = currentPlayerPokemon.GetComponent<Charizard>().getMove2();
        move3 = currentPlayerPokemon.GetComponent<Charizard>().getMove3();
        move4 = currentPlayerPokemon.GetComponent<Charizard>().getMove4();

        attackButton1 = GameObject.Find("Move1");
        attackButton2 = GameObject.Find("Move2");
        attackButton3 = GameObject.Find("Move3");
        attackButton4 = GameObject.Find("Move4");

        attackButtonText1 = GameObject.Find("MoveText1").GetComponent<TMP_Text>();
        attackButtonText2 = GameObject.Find("MoveText2").GetComponent<TMP_Text>();
        attackButtonText3 = GameObject.Find("MoveText3").GetComponent<TMP_Text>();
        attackButtonText4 = GameObject.Find("MoveText4").GetComponent<TMP_Text>();

        attackPanel = GameObject.FindGameObjectWithTag("AttackPanel");
        itemPanel = GameObject.FindGameObjectWithTag("ItemPanel");
        partyPanel = GameObject.FindGameObjectWithTag("PartyPanel");

        /*
        attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Flamethrower>().display());
        attackButtonText2.SetText(currentPlayerPokemon.GetComponent<WingAttack>().display());
        attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Bite>().display());
        attackButtonText4.SetText(currentPlayerPokemon.GetComponent<FireBlast>().display());
        */

        attackPanel.gameObject.SetActive(false);
        itemPanel.gameObject.SetActive(false);
        partyPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickAttack()
    {
        if (attackPanel.activeSelf == false)
        {
            attackPanel.gameObject.SetActive(true);
        }
        else
        {
            attackPanel.gameObject.SetActive(false);
        }

        if (itemPanel.activeSelf == true)
        {
            itemPanel.gameObject.SetActive(false);
        }

        if (partyPanel.activeSelf == true)
        {
            partyPanel.gameObject.SetActive(false);
        }
    }

    public void clickItems()
    {
        if (itemPanel.activeSelf == false)
        {
            itemPanel.gameObject.SetActive(true);
        }
        else
        {
            itemPanel.gameObject.SetActive(false);
        }

        if (attackPanel.activeSelf == true)
        {
            attackPanel.gameObject.SetActive(false);
        }

        if (partyPanel.activeSelf == true)
        {
            partyPanel.gameObject.SetActive(false);
        }
    }

    public void clickParty()
    {
        if (partyPanel.activeSelf == false)
        {
            partyPanel.gameObject.SetActive(true);
        }
        else
        {
            partyPanel.gameObject.SetActive(false);
        }

        if (itemPanel.activeSelf == true)
        {
            itemPanel.gameObject.SetActive(false);
        }

        if (attackPanel.activeSelf == true)
        {
            attackPanel.gameObject.SetActive(false);
        }
    }

    public void useMove()
    {
        int movePower = 5;
        int pokemonDamage = currentPlayerPokemon.GetComponent<Charizard>().getAttack();
        int opposingDefense = currentOpponentPokemon.GetComponent<Aerodactyl>().getDefense();        

        int damage = movePower + pokemonDamage - opposingDefense;

        currentOpponentPokemon.GetComponent<Aerodactyl>().setHealth(currentOpponentPokemon.GetComponent<Aerodactyl>().getHealth() - damage);
        opponentHealthBar.setHealth(currentOpponentHealth - damage);
        currentOpponentHealth -= damage;

        attackPanel.gameObject.SetActive(false);
    }

    public void useItem()
    {


        itemPanel.gameObject.SetActive(false);
    }

    public void swapPokemon()
    {


        partyPanel.gameObject.SetActive(false);
    }
}
