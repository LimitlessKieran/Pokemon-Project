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

    TMP_Text attackButtonText1;
    TMP_Text attackButtonText2;
    TMP_Text attackButtonText3;
    TMP_Text attackButtonText4;

    GameObject itemButton1;
    GameObject itemButton2;
    GameObject itemButton3;
    GameObject itemButton4;

    TMP_Text itemButtonText1;
    TMP_Text itemButtonText2;
    TMP_Text itemButtonText3;
    TMP_Text itemButtonText4;

    GameObject partyButton1;
    GameObject partyButton2;
    GameObject partyButton3;

    TMP_Text partyButtonText1;
    TMP_Text partyButtonText2;
    TMP_Text partyButtonText3;

    TMP_Text playerPokemonName;
    TMP_Text opponentPokemonName;

    public GameObject playerbag;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerPokemon = GameObject.Find(BattleManager.battleTeam[0]);
        currentOpponentPokemon = GameObject.Find(BattleManager.opponentTeam[0]);

        playerPokemonName = GameObject.Find("PokemonName").GetComponent<TMP_Text>();
        playerPokemonName.SetText(BattleManager.battleTeam[0]);

        opponentPokemonName = GameObject.Find("OpponentName").GetComponent<TMP_Text>();
        opponentPokemonName.SetText(BattleManager.opponentTeam[0]);

        playerbag = GameObject.Find("BattleManager");

        playerHealthBar = GameObject.Find("PlayerHealthBar").GetComponent<HealthBar>();
        opponentHealthBar = GameObject.Find("OpponentHealthBar").GetComponent<HealthBar>();

        currentOpponentHealth = 100;
        currentPlayerHealth = 100;

        attackButton1 = GameObject.Find("Move1");
        attackButton2 = GameObject.Find("Move2");
        attackButton3 = GameObject.Find("Move3");
        attackButton4 = GameObject.Find("Move4");

        attackButtonText1 = GameObject.Find("MoveText1").GetComponent<TMP_Text>();
        attackButtonText2 = GameObject.Find("MoveText2").GetComponent<TMP_Text>();
        attackButtonText3 = GameObject.Find("MoveText3").GetComponent<TMP_Text>();
        attackButtonText4 = GameObject.Find("MoveText4").GetComponent<TMP_Text>();

        itemButton1 = GameObject.Find("Item1");
        itemButton2 = GameObject.Find("Item2");
        itemButton3 = GameObject.Find("Item3");
        itemButton4 = GameObject.Find("Item4");

        itemButtonText1 = GameObject.Find("ItemText1").GetComponent<TMP_Text>();
        itemButtonText2 = GameObject.Find("ItemText2").GetComponent<TMP_Text>();
        itemButtonText3 = GameObject.Find("ItemText3").GetComponent<TMP_Text>();
        itemButtonText4 = GameObject.Find("ItemText4").GetComponent<TMP_Text>();

        partyButton1 = GameObject.Find("Pokemon1");
        partyButton2 = GameObject.Find("Pokemon2");
        partyButton3 = GameObject.Find("Pokemon3");

        partyButtonText1 = GameObject.Find("PokemonText1").GetComponent<TMP_Text>();
        partyButtonText2 = GameObject.Find("PokemonText2").GetComponent<TMP_Text>();
        partyButtonText3 = GameObject.Find("PokemonText3").GetComponent<TMP_Text>();

        attackPanel = GameObject.FindGameObjectWithTag("AttackPanel");
        itemPanel = GameObject.FindGameObjectWithTag("ItemPanel");
        partyPanel = GameObject.FindGameObjectWithTag("PartyPanel");
        
        moveDisplay();
        ItemDisplay();
        partyButtonText1.SetText(BattleManager.battleTeam[0]);
        partyButtonText2.SetText(BattleManager.battleTeam[1]);
        partyButtonText3.SetText(BattleManager.battleTeam[2]);        

        attackPanel.gameObject.SetActive(false);
        itemPanel.gameObject.SetActive(false);
        partyPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveDisplay()
    {
        if (BattleManager.battleTeam[0] == "Charizard")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Charizard>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Charizard>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Charizard>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Charizard>().displayMove4());
        }
        else if (BattleManager.battleTeam[0] == "Pikachu")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Pikachu>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Pikachu>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Pikachu>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Pikachu>().displayMove4());
        }
        else if (BattleManager.battleTeam[0] == "Aerodactyl")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Aerodactyl>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Aerodactyl>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Aerodactyl>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Aerodactyl>().displayMove4());
        }
        else if (BattleManager.battleTeam[0] == "Feraligatr")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Feraligatr>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Feraligatr>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Feraligatr>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Feraligatr>().displayMove4());
        }
        else if (BattleManager.battleTeam[0] == "Gallade")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Gallade>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Gallade>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Gallade>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Gallade>().displayMove4());
        }
        else if (BattleManager.battleTeam[0] == "Sceptile")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Sceptile>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Sceptile>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Sceptile>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Sceptile>().displayMove4());
        }

    }
    public void ItemDisplay()
    {
        itemButtonText1.SetText(playerbag.GetComponent<Bag>().displayItem1(BattleManager.Bag[0]));
        itemButtonText2.SetText(playerbag.GetComponent<Bag>().displayItem2(BattleManager.Bag[1]));
        itemButtonText3.SetText(playerbag.GetComponent<Bag>().displayItem3(BattleManager.Bag[2]));
        itemButtonText4.SetText(playerbag.GetComponent<Bag>().displayItem4(BattleManager.Bag[3]));
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
