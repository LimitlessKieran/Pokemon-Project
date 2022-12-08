using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleUI : MonoBehaviour
{
    int AIcounter;

    GameObject attackPanel;
    GameObject itemPanel;
    GameObject partyPanel;

    HealthBar playerHealthBar;
    HealthBar opponentHealthBar;

    public int currentPlayerHealth;
    public int currentOpponentHealth;

    public int potionCount;
    public int xAttackCount;
    public int shieldCount;
    public int elixirCount;

    public GameObject currentPlayerPokemon;
    public GameObject currentOpponentPokemon;

    GameObject attackButtonMain;
    GameObject itemButtonMain;
    GameObject partyButtonMain;

    GameObject attackButton1;
    GameObject attackButton2;
    GameObject attackButton3;
    GameObject attackButton4;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;

    TMP_Text choiceText1;
    TMP_Text choiceText2;
    TMP_Text choiceText3;
    TMP_Text choiceText4;


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

    TMP_Text combatText;

    public GameObject battleManager, go;

    System.Random random = new System.Random();

    // if the user has activated xAttack or shield item this will be true;
    public bool isDamageBoosted, isShieldActivated;

    Color gray = new Color32(133, 133, 133, 255);
    Color blue = new Color32(0, 38, 255, 255);
    Color green = new Color32(5, 161, 0, 225);

    // Start is called before the first frame update
    void Start()
    {
        AIcounter = 0;
        
        isDamageBoosted = false;
        isShieldActivated = false;

        go = GameObject.Find("TeamCreater");

        battleManager = GameObject.Find("BattleManager");

        currentPlayerPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[0]);
        currentOpponentPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[0]);

        playerPokemonName = GameObject.Find("PokemonName").GetComponent<TMP_Text>();
        playerPokemonName.SetText(go.GetComponent<SelectPokemon>().PokemonTeam[0]);

        opponentPokemonName = GameObject.Find("OpponentName").GetComponent<TMP_Text>();
        opponentPokemonName.SetText(go.GetComponent<SelectPokemon>().opponentTeam[0]);

        playerHealthBar = GameObject.Find("PlayerHealthBar").GetComponent<HealthBar>();
        opponentHealthBar = GameObject.Find("OpponentHealthBar").GetComponent<HealthBar>();

        playerHealthBar.setMaxHealth(getCurrentPokemonMaxHealth());
        opponentHealthBar.setMaxHealth(getCurrentOpponentMaxHealth());

        currentOpponentHealth = getCurrentPokemonHealth();
        currentPlayerHealth = getOpponentPokemonHealth();

        attackButtonMain = GameObject.Find("AttackButton");
        itemButtonMain = GameObject.Find("BagButton");
        partyButtonMain = GameObject.Find("SwapButton");

        attackButton1 = GameObject.Find("Move1");
        attackButton2 = GameObject.Find("Move2");
        attackButton3 = GameObject.Find("Move3");
        attackButton4 = GameObject.Find("Move4");

        attackButtonText1 = GameObject.Find("MoveText1").GetComponent<TMP_Text>();
        attackButtonText2 = GameObject.Find("MoveText2").GetComponent<TMP_Text>();
        attackButtonText3 = GameObject.Find("MoveText3").GetComponent<TMP_Text>();
        attackButtonText4 = GameObject.Find("MoveText4").GetComponent<TMP_Text>();

        choiceText1 = GameObject.Find("choice1txt").GetComponent<TMP_Text>();
        choiceText2 = GameObject.Find("choice2txt").GetComponent<TMP_Text>();
        choiceText3 = GameObject.Find("choice3txt").GetComponent<TMP_Text>();
        choiceText4 = GameObject.Find("choice4txt").GetComponent<TMP_Text>();

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

        combatText = GameObject.Find("CombatText").GetComponent<TMP_Text>();

        moveDisplay();
        ItemDisplay();
        partyDisplay();

        attackPanel.gameObject.SetActive(false);
        itemPanel.gameObject.SetActive(false);
        partyPanel.gameObject.SetActive(false);

        potionCount = go.GetComponent<SelectPokemon>().Bag[0];
        xAttackCount = go.GetComponent<SelectPokemon>().Bag[1];
        shieldCount = go.GetComponent<SelectPokemon>().Bag[2];
        elixirCount = go.GetComponent<SelectPokemon>().Bag[3];

        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ItemDisplay();
        partyDisplay();

        currentOpponentHealth = getOpponentPokemonHealth();
        currentPlayerHealth = getCurrentPokemonHealth();

        if (getCurrentPokemonHealth() != 0)
            partyButton1.GetComponent<Image>().color = green;
        else
            partyButton1.GetComponent<Image>().color = gray;

        if (getPokemon2Health() != 0)
            partyButton2.GetComponent<Image>().color = green;
        else
            partyButton2.GetComponent<Image>().color = gray;

        if (getPokemon3Health() != 0)
            partyButton3.GetComponent<Image>().color = green;
        else
            partyButton3.GetComponent<Image>().color = gray;

        if(potionCount <= 0)
        {
            itemButton1.GetComponent<Image>().color = gray;
        }
        if (xAttackCount <= 0)
        {
            itemButton2.GetComponent<Image>().color = gray;
        }
        if (shieldCount <= 0)
        {
            itemButton3.GetComponent<Image>().color = gray;
        }
        if (elixirCount <= 0)
        {
            itemButton4.GetComponent<Image>().color = gray;
        }
    }

    public void moveDisplay()
    {
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Charizard>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Charizard>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Charizard>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Charizard>().displayMove4());
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Pikachu>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Pikachu>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Pikachu>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Pikachu>().displayMove4());
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Aerodactyl>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Aerodactyl>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Aerodactyl>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Aerodactyl>().displayMove4());
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Feraligatr>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Feraligatr>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Feraligatr>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Feraligatr>().displayMove4());
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Gallade>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Gallade>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Gallade>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Gallade>().displayMove4());
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            attackButtonText1.SetText(currentPlayerPokemon.GetComponent<Sceptile>().displayMove1());
            attackButtonText2.SetText(currentPlayerPokemon.GetComponent<Sceptile>().displayMove2());
            attackButtonText3.SetText(currentPlayerPokemon.GetComponent<Sceptile>().displayMove3());
            attackButtonText4.SetText(currentPlayerPokemon.GetComponent<Sceptile>().displayMove4());
        }
    }

    public void ItemDisplay()
    {
        itemButtonText1.SetText(go.GetComponent<Bag>().displayItem1(potionCount));
        itemButtonText2.SetText(go.GetComponent<Bag>().displayItem2(xAttackCount));
        itemButtonText3.SetText(go.GetComponent<Bag>().displayItem3(shieldCount));
        itemButtonText4.SetText(go.GetComponent<Bag>().displayItem4(elixirCount));
    }

    public void partyDisplay()
    {
        partyButtonText1.SetText(go.GetComponent<SelectPokemon>().PokemonTeam[0]);
        partyButtonText2.SetText(go.GetComponent<SelectPokemon>().PokemonTeam[1]);
        partyButtonText3.SetText(go.GetComponent<SelectPokemon>().PokemonTeam[2]);
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

    public void useMove1()
    {
      
        StartCoroutine(move1());

    }

    public void useMove2()
    {
        
        StartCoroutine(move2());
    }

    public void useMove3()
    {
        
        StartCoroutine(move3());
    }

    public void useMove4()
    {
       
        StartCoroutine(move4());
    }

    public void lowerHealth(int damage)
    {
        if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
        {
            currentOpponentPokemon.GetComponent<Charizard>().setHealth(currentOpponentPokemon.GetComponent<Charizard>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
        {
            currentOpponentPokemon.GetComponent<Gallade>().setHealth(currentOpponentPokemon.GetComponent<Gallade>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
        {
            currentOpponentPokemon.GetComponent<Pikachu>().setHealth(currentOpponentPokemon.GetComponent<Pikachu>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
        {
            currentOpponentPokemon.GetComponent<Feraligatr>().setHealth(currentOpponentPokemon.GetComponent<Feraligatr>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
        {
            currentOpponentPokemon.GetComponent<Sceptile>().setHealth(currentOpponentPokemon.GetComponent<Sceptile>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
        {
            currentOpponentPokemon.GetComponent<Aerodactyl>().setHealth(currentOpponentPokemon.GetComponent<Aerodactyl>().getHealth() - damage);
        }

        if (currentOpponentHealth - damage <= 0)
        {
            opponentHealthBar.setHealth(0);
            setOpponentPokemonHealth(0);
            AIcounter++;
        }
        else
        {
            currentOpponentHealth -= damage;            
            opponentHealthBar.setHealth(currentOpponentHealth);
        }
    }

    public void useItem1()
    {
        StartCoroutine(usedPotion());
    }

    public void useItem2()
    {
        StartCoroutine(usedxAttack());
    }

    public void useItem3()
    {
        StartCoroutine(usedShield());
    }

    public void useItem4()
    {
        StartCoroutine(usedElixir());
    }

    IEnumerator usedPotion()
    {
        itemPanel.gameObject.SetActive(false);

        // check to see if the user has potions
        if (potionCount > 0)
        {
            // check to see if the user has max health
            if (currentPlayerHealth == 1000)
            {
                combatText.SetText("You have full health!!!");
                yield return new WaitForSeconds(2);
                combatText.SetText("");
            }
            else
            {
                // The potion is used
                combatText.SetText("A Potion was used!");
                battleManager.GetComponent<BattleManager>().healthActivated();
                yield return new WaitForSeconds(2);
                potionCount--;
                ItemDisplay();

                // increasing the current pokemons health
                if (currentPlayerHealth + 300 >= 1000)
                    currentPlayerHealth = 1000;
                else
                    currentPlayerHealth += 300;
                setCurrentPokemonHealth(currentPlayerHealth);
                playerHealthBar.setHealth(currentPlayerHealth);

                combatText.SetText(go.GetComponent<SelectPokemon>().PokemonTeam[0] + " HP was restored!");
                battleManager.GetComponent<BattleManager>().healthDeactivated();

                yield return new WaitForSeconds(2);
                combatText.SetText("");
            }
        }
        else
        {
            combatText.SetText("You have no potions!!!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
        }
    }

    IEnumerator usedxAttack()
    {

        itemPanel.gameObject.SetActive(false);
        // check to see if the user already used an xattack
        if (isDamageBoosted) {

            combatText.SetText("Damage is already increased!!!");
            yield return new WaitForSeconds(2);

            combatText.SetText("Select an attack!!!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
        }
        else
        {
            // check to see if the user has any xattacks
            if (xAttackCount > 0)
            {
                combatText.SetText("Your next attack's damage has been increased!!");
                yield return new WaitForSeconds(2);
                battleManager.GetComponent<BattleManager>().xAttackActivated();
                xAttackCount--;
                ItemDisplay();
                combatText.SetText("");
                isDamageBoosted = true;
            }
            else
            {
                // the user has no more xAttacks
                combatText.SetText("You have no xAttacks!!!");
                yield return new WaitForSeconds(2);
                combatText.SetText("");
            }
        }
    }

    IEnumerator usedShield()
    {
        itemPanel.gameObject.SetActive(false);

        if (isShieldActivated)
        {
            combatText.SetText("Shield is currently being used!!!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");

        }
        else
        {
            if (shieldCount > 0)
            {
                shieldCount--;
                ItemDisplay();
                combatText.SetText("Shield has been activated");
                isShieldActivated = true;
                battleManager.GetComponent<BattleManager>().shieldActivated();
                combatText.SetText("");
            }
            else
            {
                combatText.SetText("You have no shields!!!");
                yield return new WaitForSeconds(2);
                combatText.SetText("");
            }
        }
    }

    IEnumerator usedElixir()
    {
        string moveName1 = "", moveName2 = "", moveName3 = "", moveName4 = "";
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            moveName1 = currentPlayerPokemon.GetComponent<Charizard>().getMove1();
            moveName2 = currentPlayerPokemon.GetComponent<Charizard>().getMove2();
            moveName3 = currentPlayerPokemon.GetComponent<Charizard>().getMove3();
            moveName4 = currentPlayerPokemon.GetComponent<Charizard>().getMove4();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            moveName1 = currentPlayerPokemon.GetComponent<Gallade>().getMove1();
            moveName2 = currentPlayerPokemon.GetComponent<Gallade>().getMove2();
            moveName3 = currentPlayerPokemon.GetComponent<Gallade>().getMove3();
            moveName4 = currentPlayerPokemon.GetComponent<Gallade>().getMove4();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            moveName1 = currentPlayerPokemon.GetComponent<Pikachu>().getMove1();
            moveName2 = currentPlayerPokemon.GetComponent<Pikachu>().getMove2();
            moveName3 = currentPlayerPokemon.GetComponent<Pikachu>().getMove3();
            moveName4 = currentPlayerPokemon.GetComponent<Pikachu>().getMove4();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            moveName1 = currentPlayerPokemon.GetComponent<Feraligatr>().getMove1();
            moveName2 = currentPlayerPokemon.GetComponent<Feraligatr>().getMove2();
            moveName3 = currentPlayerPokemon.GetComponent<Feraligatr>().getMove3();
            moveName4 = currentPlayerPokemon.GetComponent<Feraligatr>().getMove4();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            moveName1 = currentPlayerPokemon.GetComponent<Sceptile>().getMove1();
            moveName2 = currentPlayerPokemon.GetComponent<Sceptile>().getMove2();
            moveName3 = currentPlayerPokemon.GetComponent<Sceptile>().getMove2();
            moveName4 = currentPlayerPokemon.GetComponent<Sceptile>().getMove3();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            moveName1 = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove1();
            moveName2 = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove2();
            moveName3 = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove3();
            moveName4 = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove4();
        }

        if (elixirCount > 0)
        {
            
            if(attackButton1.GetComponent<Image>().color == blue && attackButton2.GetComponent<Image>().color == blue && attackButton3.GetComponent<Image>().color == blue
                && attackButton4.GetComponent<Image>().color == blue)
            {
                combatText.SetText("No move has ran out of uses!!!!");
            }
            else
            {
                elixirCount--;
                ItemDisplay();
                battleManager.GetComponent<BattleManager>().elixirActivated();

                if (attackButton1.GetComponent<Image>().color == gray)
                {
                    combatText.SetText("Which move would you like to restore?");
                    choice1.SetActive(true);
                    choiceText1.SetText(moveName1);


                }
                if (attackButton2.GetComponent<Image>().color == gray)
                {
                    combatText.SetText("Which move would you like to restore?");
                    choice2.SetActive(true);
                    choiceText2.SetText(moveName2);


                }
                if (attackButton3.GetComponent<Image>().color == gray)
                {
                    combatText.SetText("Which move would you like to restore?");
                    choice3.SetActive(true);
                    choiceText3.SetText(moveName3);


                }
                if (attackButton4.GetComponent<Image>().color == gray)
                {
                    combatText.SetText("Which move would you like to restore?");
                    choice4.SetActive(true);
                    choiceText4.SetText(moveName4);

                }
            }
            
        }
        else
        {
            combatText.SetText("You have no elixirs!!!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
        }
    }

    public void refill1()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);


        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            currentPlayerPokemon.GetComponent<Charizard>().reset1Uses();
            attackButton1.GetComponent<Image>().color = blue;
            moveDisplay();
            combatText.SetText("");

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            currentPlayerPokemon.GetComponent<Gallade>().reset1Uses();
            attackButton1.GetComponent<Image>().color = blue;
            moveDisplay();
            combatText.SetText("");

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            currentPlayerPokemon.GetComponent<Pikachu>().reset1Uses();
            attackButton1.GetComponent<Image>().color = blue;
            moveDisplay();
            combatText.SetText("");

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {

            currentPlayerPokemon.GetComponent<Feraligatr>().reset1Uses();
            attackButton1.GetComponent<Image>().color = blue;
            moveDisplay();
            combatText.SetText("");

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            currentPlayerPokemon.GetComponent<Sceptile>().reset1Uses();
            attackButton1.GetComponent<Image>().color = blue;
            moveDisplay();
            combatText.SetText("");


        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            currentPlayerPokemon.GetComponent<Aerodactyl>().reset1Uses();
            attackButton1.GetComponent<Image>().color = blue;
            moveDisplay();
            combatText.SetText("");

        }
        battleManager.GetComponent<BattleManager>().elixirActivated();
    }

    public void refill2()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);


        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            currentPlayerPokemon.GetComponent<Charizard>().reset2Uses();
            attackButton2.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            currentPlayerPokemon.GetComponent<Gallade>().reset2Uses();
            attackButton2.GetComponent<Image>().color = blue;
            combatText.SetText("");


            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            currentPlayerPokemon.GetComponent<Pikachu>().reset2Uses();
            attackButton2.GetComponent<Image>().color = blue;
            combatText.SetText("");


            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {

            currentPlayerPokemon.GetComponent<Feraligatr>().reset2Uses();
            attackButton2.GetComponent<Image>().color = blue;
            combatText.SetText("");


            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            currentPlayerPokemon.GetComponent<Sceptile>().reset2Uses();
            attackButton2.GetComponent<Image>().color = blue;
            combatText.SetText("");


            moveDisplay();

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            currentPlayerPokemon.GetComponent<Aerodactyl>().reset2Uses();
            attackButton2.GetComponent<Image>().color = blue;

            combatText.SetText("");

            moveDisplay();
        }
        battleManager.GetComponent<BattleManager>().elixirActivated();
    }

    public void refill3()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);


        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            currentPlayerPokemon.GetComponent<Charizard>().reset3Uses();
            attackButton3.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            currentPlayerPokemon.GetComponent<Gallade>().reset3Uses();
            attackButton3.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            currentPlayerPokemon.GetComponent<Pikachu>().reset3Uses();
            attackButton3.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {

            currentPlayerPokemon.GetComponent<Feraligatr>().reset3Uses();
            attackButton3.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            currentPlayerPokemon.GetComponent<Sceptile>().reset3Uses();
            attackButton3.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            currentPlayerPokemon.GetComponent<Aerodactyl>().reset3Uses();
            attackButton3.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        battleManager.GetComponent<BattleManager>().elixirActivated();
    }

    public void refill4()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        choice4.SetActive(false);

       

        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            currentPlayerPokemon.GetComponent<Charizard>().reset4Uses();
            attackButton4.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            currentPlayerPokemon.GetComponent<Gallade>().reset4Uses();
            attackButton4.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            currentPlayerPokemon.GetComponent<Pikachu>().reset4Uses();
            attackButton4.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {

            currentPlayerPokemon.GetComponent<Feraligatr>().reset4Uses();
            attackButton4.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            currentPlayerPokemon.GetComponent<Sceptile>().reset4Uses();
            attackButton4.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            currentPlayerPokemon.GetComponent<Aerodactyl>().reset4Uses();
            attackButton4.GetComponent<Image>().color = blue;
            combatText.SetText("");

            moveDisplay();
        }

        battleManager.GetComponent<BattleManager>().elixirDeactivated();
    }

    public void swapPokemon2()
    {
        StartCoroutine(swapParty2());
    }

    public void swapPokemon3()
    {
        StartCoroutine(swapParty3());
    }

    public int checkType(GameManager.Type moveType, GameManager.Type opponentType)
    {
        if (moveType == GameManager.Type.FIRE && opponentType == GameManager.Type.WATER)
            return 1;
        else if (moveType == GameManager.Type.FIRE && opponentType == GameManager.Type.GRASS)
            return 4;
        else if (moveType == GameManager.Type.FIRE && opponentType == GameManager.Type.FIRE)
            return 1;
        else if (moveType == GameManager.Type.WATER && opponentType == GameManager.Type.WATER)
            return 1;
        else if (moveType == GameManager.Type.WATER && opponentType == GameManager.Type.FIRE)
            return 4;
        else if (moveType == GameManager.Type.WATER && opponentType == GameManager.Type.GRASS)
            return 1;
        else if (moveType == GameManager.Type.GRASS && opponentType == GameManager.Type.WATER)
            return 4;
        else if (moveType == GameManager.Type.GRASS && opponentType == GameManager.Type.FIRE)
            return 1;
        else if (moveType == GameManager.Type.GRASS && opponentType == GameManager.Type.GRASS)
            return 1;
        else if (moveType == GameManager.Type.FLYING && opponentType == GameManager.Type.FLYING)
            return 1;
        else if (moveType == GameManager.Type.FLYING && opponentType == GameManager.Type.ELECTRIC)
            return 1;
        else if (moveType == GameManager.Type.FLYING && opponentType == GameManager.Type.FIGHTING)
            return 4;
        else if (moveType == GameManager.Type.FLYING && opponentType == GameManager.Type.GRASS)
            return 4;
        else if (moveType == GameManager.Type.ELECTRIC && opponentType == GameManager.Type.ELECTRIC)
            return 1;
        else if (moveType == GameManager.Type.ELECTRIC && opponentType == GameManager.Type.FIGHTING)
            return 1;
        else if (moveType == GameManager.Type.ELECTRIC && opponentType == GameManager.Type.FLYING)
            return 4;
        else if (moveType == GameManager.Type.ELECTRIC && opponentType == GameManager.Type.WATER)
            return 4;
        else if (moveType == GameManager.Type.FIGHTING && opponentType == GameManager.Type.FIGHTING)
            return 1;
        else if (moveType == GameManager.Type.FIGHTING && opponentType == GameManager.Type.ELECTRIC)
            return 4;
        else if (moveType == GameManager.Type.FIGHTING && opponentType == GameManager.Type.FLYING)
            return 1;
        else
            return 2;
    }

    public int getPokemon2Health()
    {
        int currentHealth = 0;

        GameObject thisPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[1]);

        if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Charizard")
        {
            currentHealth = thisPokemon.GetComponent<Charizard>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Gallade")
        {
            currentHealth = thisPokemon.GetComponent<Gallade>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Pikachu")
        {
            currentHealth = thisPokemon.GetComponent<Pikachu>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Feraligatr")
        {
            currentHealth = thisPokemon.GetComponent<Feraligatr>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Sceptile")
        {
            currentHealth = thisPokemon.GetComponent<Sceptile>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Aerodactyl")
        {
            currentHealth = thisPokemon.GetComponent<Aerodactyl>().getHealth();
        }

        return currentHealth;
    }

    public int getPokemon3Health()
    {
        int currentHealth = 0;

        GameObject thisPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[2]);

        if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Charizard")
        {
            currentHealth = thisPokemon.GetComponent<Charizard>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Gallade")
        {
            currentHealth = thisPokemon.GetComponent<Gallade>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Pikachu")
        {
            currentHealth = thisPokemon.GetComponent<Pikachu>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Feraligatr")
        {
            currentHealth = thisPokemon.GetComponent<Feraligatr>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Sceptile")
        {
            currentHealth = thisPokemon.GetComponent<Sceptile>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Aerodactyl")
        {
            currentHealth = thisPokemon.GetComponent<Aerodactyl>().getHealth();
        }

        return currentHealth;
    }

    public int getCurrentPokemonMaxHealth()
    {
        int maxHealth = 0;

        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            maxHealth = currentPlayerPokemon.GetComponent<Charizard>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            maxHealth = currentPlayerPokemon.GetComponent<Gallade>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            maxHealth = currentPlayerPokemon.GetComponent<Pikachu>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            maxHealth = currentPlayerPokemon.GetComponent<Feraligatr>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            maxHealth = currentPlayerPokemon.GetComponent<Sceptile>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            maxHealth = currentPlayerPokemon.GetComponent<Aerodactyl>().getMaxHealth();
        }

        return maxHealth;
    }

    public int getCurrentPokemonHealth()
    {
        int currentHealth = 0;

        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            currentHealth = currentPlayerPokemon.GetComponent<Charizard>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            currentHealth = currentPlayerPokemon.GetComponent<Gallade>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            currentHealth = currentPlayerPokemon.GetComponent<Pikachu>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            currentHealth = currentPlayerPokemon.GetComponent<Feraligatr>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            currentHealth = currentPlayerPokemon.GetComponent<Sceptile>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            currentHealth = currentPlayerPokemon.GetComponent<Aerodactyl>().getHealth();
        }

        return currentHealth;
    }

    public void setCurrentPokemonHealth(int health)
    {
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            currentPlayerPokemon.GetComponent<Charizard>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            currentPlayerPokemon.GetComponent<Gallade>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            currentPlayerPokemon.GetComponent<Pikachu>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            currentPlayerPokemon.GetComponent<Feraligatr>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            currentPlayerPokemon.GetComponent<Sceptile>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            currentPlayerPokemon.GetComponent<Aerodactyl>().setHealth(health);
        }
    }

    public int getCurrentOpponentMaxHealth()
    {
        int maxHealth = 0;

        if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
        {
            maxHealth = currentOpponentPokemon.GetComponent<Charizard>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
        {
            maxHealth = currentOpponentPokemon.GetComponent<Gallade>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
        {
            maxHealth = currentOpponentPokemon.GetComponent<Pikachu>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
        {
            maxHealth = currentOpponentPokemon.GetComponent<Feraligatr>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
        {
            maxHealth = currentOpponentPokemon.GetComponent<Sceptile>().getMaxHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
        {
            maxHealth = currentOpponentPokemon.GetComponent<Aerodactyl>().getMaxHealth();
        }

        return maxHealth;
    }

    public int getOpponentPokemonHealth()
    {
        int currentHealth = 0;

        if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
        {
            currentHealth = currentOpponentPokemon.GetComponent<Charizard>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
        {
            currentHealth = currentOpponentPokemon.GetComponent<Gallade>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
        {
            currentHealth = currentOpponentPokemon.GetComponent<Pikachu>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
        {
            currentHealth = currentOpponentPokemon.GetComponent<Feraligatr>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
        {
            currentHealth = currentOpponentPokemon.GetComponent<Sceptile>().getHealth();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
        {
            currentHealth = currentOpponentPokemon.GetComponent<Aerodactyl>().getHealth();
        }

        return currentHealth;
    }

    public void setOpponentPokemonHealth(int health)
    {
        if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
        {
            currentOpponentPokemon.GetComponent<Charizard>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
        {
            currentOpponentPokemon.GetComponent<Gallade>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
        {
            currentOpponentPokemon.GetComponent<Pikachu>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
        {
            currentOpponentPokemon.GetComponent<Feraligatr>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
        {
            currentOpponentPokemon.GetComponent<Sceptile>().setHealth(health);
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
        {
            currentOpponentPokemon.GetComponent<Aerodactyl>().setHealth(health);
        }
    }

    public void checkMoves()
    {
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            if (currentPlayerPokemon.GetComponent<Charizard>().getMove1Uses() <= 0)
                attackButton1.GetComponent<Image>().color = gray;
            else
                attackButton1.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Charizard>().getMove2Uses() <= 0)
                attackButton2.GetComponent<Image>().color = gray;
            else
                attackButton2.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Charizard>().getMove3Uses() <= 0)
                attackButton3.GetComponent<Image>().color = gray;
            else
                attackButton3.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Charizard>().getMove4Uses() <= 0)
                attackButton4.GetComponent<Image>().color = gray;
            else
                attackButton4.GetComponent<Image>().color = blue;
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            if (currentPlayerPokemon.GetComponent<Gallade>().getMove1Uses() <= 0)
                attackButton1.GetComponent<Image>().color = gray;
            else
                attackButton1.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Gallade>().getMove2Uses() <= 0)
                attackButton2.GetComponent<Image>().color = gray;
            else
                attackButton2.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Gallade>().getMove3Uses() <= 0)
                attackButton3.GetComponent<Image>().color = gray;
            else
                attackButton3.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Gallade>().getMove4Uses() <= 0)
                attackButton4.GetComponent<Image>().color = gray;
            else
                attackButton4.GetComponent<Image>().color = blue;
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            if (currentPlayerPokemon.GetComponent<Pikachu>().getMove1Uses() <= 0)
                attackButton1.GetComponent<Image>().color = gray;
            else
                attackButton1.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Pikachu>().getMove2Uses() <= 0)
                attackButton2.GetComponent<Image>().color = gray;
            else
                attackButton2.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Pikachu>().getMove3Uses() <= 0)
                attackButton3.GetComponent<Image>().color = gray;
            else
                attackButton3.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Pikachu>().getMove4Uses() <= 0)
                attackButton4.GetComponent<Image>().color = gray;
            else
                attackButton4.GetComponent<Image>().color = blue;
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            if (currentPlayerPokemon.GetComponent<Feraligatr>().getMove1Uses() <= 0)
                attackButton1.GetComponent<Image>().color = gray;
            else
                attackButton1.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Feraligatr>().getMove2Uses() <= 0)
                attackButton2.GetComponent<Image>().color = gray;
            else
                attackButton2.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Feraligatr>().getMove3Uses() <= 0)
                attackButton3.GetComponent<Image>().color = gray;
            else
                attackButton3.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Feraligatr>().getMove4Uses() <= 0)
                attackButton4.GetComponent<Image>().color = gray;
            else
                attackButton4.GetComponent<Image>().color = blue;
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            if (currentPlayerPokemon.GetComponent<Sceptile>().getMove1Uses() <= 0)
                attackButton1.GetComponent<Image>().color = gray;
            else
                attackButton1.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Sceptile>().getMove2Uses() <= 0)
                attackButton2.GetComponent<Image>().color = gray;
            else
                attackButton2.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Sceptile>().getMove3Uses() <= 0)
                attackButton3.GetComponent<Image>().color = gray;
            else
                attackButton3.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Sceptile>().getMove4Uses() <= 0)
                attackButton4.GetComponent<Image>().color = gray;
            else
                attackButton4.GetComponent<Image>().color = blue;
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            if (currentPlayerPokemon.GetComponent<Aerodactyl>().getMove1Uses() <= 0)
                attackButton1.GetComponent<Image>().color = gray;
            else
                attackButton1.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Aerodactyl>().getMove2Uses() <= 0)
                attackButton2.GetComponent<Image>().color = gray;
            else
                attackButton2.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Aerodactyl>().getMove3Uses() <= 0)
                attackButton3.GetComponent<Image>().color = gray;
            else
                attackButton3.GetComponent<Image>().color = blue;
            if (currentPlayerPokemon.GetComponent<Aerodactyl>().getMove4Uses() <= 0)
                attackButton4.GetComponent<Image>().color = gray;
            else
                attackButton4.GetComponent<Image>().color = blue;
        }
    }
    IEnumerator swapParty2()
    {
        bool faint = false;
        if (getCurrentPokemonHealth() == 0)
        {
            faint = true;
        }

        if (partyButton2.GetComponent<Image>().color == gray)
        {
            combatText.SetText("This Pokemon has Fainted.");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
            yield break;
        }

        attackButtonMain.gameObject.SetActive(false);
        itemButtonMain.gameObject.SetActive(false);
        partyButtonMain.gameObject.SetActive(false);
        partyPanel.gameObject.SetActive(false);

        combatText.SetText("Come back " + go.GetComponent<SelectPokemon>().PokemonTeam[0] + "!");
        yield return new WaitForSeconds(2);

        string temp;

        temp = go.GetComponent<SelectPokemon>().PokemonTeam[0];
        go.GetComponent<SelectPokemon>().PokemonTeam[0] = go.GetComponent<SelectPokemon>().PokemonTeam[1];
        go.GetComponent<SelectPokemon>().PokemonTeam[1] = temp;

        currentPlayerPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[0]);
        playerPokemonName.SetText(go.GetComponent<SelectPokemon>().PokemonTeam[0]);

        combatText.SetText("It's your turn " + go.GetComponent<SelectPokemon>().PokemonTeam[0] + "!!");
        yield return new WaitForSeconds(2);
        combatText.SetText("");

        playerHealthBar.setMaxHealth(getCurrentPokemonMaxHealth());
        playerHealthBar.setHealth(getCurrentPokemonHealth());
        moveDisplay();
        checkMoves();

        if (faint == false)
            StartCoroutine(AIuseMove(random.Next(1, 5)));
        else
        {
            faint = false;
            attackButtonMain.gameObject.SetActive(true);
            itemButtonMain.gameObject.SetActive(true);
            partyButtonMain.gameObject.SetActive(true);
        }
    }

    IEnumerator swapParty3()
    {
        bool faint = false;
        if (partyButton1.GetComponent<Image>().color == gray)
        {
            faint = true;
        }

        if (partyButton3.GetComponent<Image>().color == gray)
        {
            combatText.SetText("This Pokemon has Fainted.");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
            yield break;
        }

        attackButtonMain.gameObject.SetActive(false);
        itemButtonMain.gameObject.SetActive(false);
        partyButtonMain.gameObject.SetActive(false);
        partyPanel.gameObject.SetActive(false);

        combatText.SetText("Come back " + go.GetComponent<SelectPokemon>().PokemonTeam[0] + "!");
        yield return new WaitForSeconds(2);

        string temp;

        temp = go.GetComponent<SelectPokemon>().PokemonTeam[0];
        go.GetComponent<SelectPokemon>().PokemonTeam[0] = go.GetComponent<SelectPokemon>().PokemonTeam[2];
        go.GetComponent<SelectPokemon>().PokemonTeam[2] = temp;

        currentPlayerPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().PokemonTeam[0]);
        playerPokemonName.SetText(go.GetComponent<SelectPokemon>().PokemonTeam[0]);

        combatText.SetText("It's your turn " + go.GetComponent<SelectPokemon>().PokemonTeam[0] + "!!");
        yield return new WaitForSeconds(2);
        combatText.SetText("");

        playerHealthBar.setMaxHealth(getCurrentPokemonMaxHealth());
        playerHealthBar.setHealth(getCurrentPokemonHealth());
        moveDisplay();
        checkMoves();

        if (faint == false)
            StartCoroutine(AIuseMove(random.Next(1, 5)));
        else
        {
            faint = false;
            attackButtonMain.gameObject.SetActive(true);
            itemButtonMain.gameObject.SetActive(true);
            partyButtonMain.gameObject.SetActive(true);
        }
    }

    IEnumerator move1()
    {
        checkMoves();
        if (attackButton1.GetComponent<Image>().color == gray)
        {
            combatText.SetText("That move is out of uses.");
            yield break;
        }

        bool isCritical = false;
        attackButtonMain.gameObject.SetActive(false);
        itemButtonMain.gameObject.SetActive(false);
        partyButtonMain.gameObject.SetActive(false);
        attackPanel.gameObject.SetActive(false);

        string pokemonName = go.GetComponent<SelectPokemon>().PokemonTeam[0];
        string moveName = "";
        int movePower = 0;
        int opposingDefense = 0;
        GameManager.Type moveType = GameManager.Type.NORMAL;
        GameManager.Type opponentPokemonType = GameManager.Type.NORMAL;

        // Get player pokemon damage and typing.
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            moveName = currentPlayerPokemon.GetComponent<Charizard>().getMove1();
            movePower = currentPlayerPokemon.GetComponent<Charizard>().useMove1();
            moveType = currentPlayerPokemon.GetComponent<Charizard>().getMove1Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            moveName = currentPlayerPokemon.GetComponent<Gallade>().getMove1();
            movePower = currentPlayerPokemon.GetComponent<Gallade>().useMove1();
            moveType = currentPlayerPokemon.GetComponent<Gallade>().getMove1Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            moveName = currentPlayerPokemon.GetComponent<Pikachu>().getMove1();
            movePower = currentPlayerPokemon.GetComponent<Pikachu>().useMove1();
            moveType = currentPlayerPokemon.GetComponent<Pikachu>().getMove1Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            moveName = currentPlayerPokemon.GetComponent<Feraligatr>().getMove1();
            movePower = currentPlayerPokemon.GetComponent<Feraligatr>().useMove1();
            moveType = currentPlayerPokemon.GetComponent<Feraligatr>().getMove1Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            moveName = currentPlayerPokemon.GetComponent<Sceptile>().getMove1();
            movePower = currentPlayerPokemon.GetComponent<Sceptile>().useMove1();
            moveType = currentPlayerPokemon.GetComponent<Sceptile>().getMove1Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            moveName = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove1();
            movePower = currentPlayerPokemon.GetComponent<Aerodactyl>().useMove1();
            moveType = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove1Type();
        }

        // Get opponent pokemon damage and typing.
        if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Charizard>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Charizard>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Gallade>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Gallade>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Pikachu>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Pikachu>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Feraligatr>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Feraligatr>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Sceptile>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Sceptile>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Aerodactyl>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Aerodactyl>().getType();
        }

        combatText.SetText(pokemonName + " used " + moveName);
        yield return new WaitForSeconds(2);

        if (movePower == 0)
        {
            combatText.SetText("It missed!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
            StartCoroutine(AIuseMove(random.Next(1, 5)));
            yield break;
        }

        // If critical, multiply the damage by 1.5
        if (random.Next(1, 100) <= 5)
            isCritical = true;

        // Calculate damage
        int damage = ((((movePower * 3) / 2 - opposingDefense) * checkType(moveType, opponentPokemonType)) / 2) + 10;

        // if xAttack is used then
        if (isDamageBoosted)
        {
            damage *= 2;
            // after damage calcuations is done set it back to false;
            isDamageBoosted = false;

            battleManager.GetComponent<BattleManager>().xAttackDeactivated();

        }

        
        if (isCritical == true)
        {
            damage *= 2;
        }

        lowerHealth(damage);

        // If critical, say it was critical
        if (isCritical == true)
        {
            combatText.SetText("It's a critical hit!!");
            yield return new WaitForSeconds(2);
        }

        // Check for type effectiveness
        if (checkType(moveType, opponentPokemonType) == 1)
            combatText.SetText("It was not very effective.");
        else if (checkType(moveType, opponentPokemonType) == 2)
            combatText.SetText("It was effective.");
        else if (checkType(moveType, opponentPokemonType) == 4)
            combatText.SetText("It was super effective!!");

        yield return new WaitForSeconds(2);
        if (currentOpponentHealth <= 0)
        {
            StartCoroutine(AIfaint(AIcounter));
            yield break;
        }

        combatText.SetText("");
        moveDisplay();
        checkMoves();

        // if shield is activated then message will be blocked
        if (isShieldActivated)
        {
            isShieldActivated = false;
            battleManager.GetComponent<BattleManager>().shieldDeactivated();
            combatText.SetText("The shield blocked the opponent's attack!");
            yield return new WaitForSeconds(2);
            
            combatText.SetText("Your turn.");
            yield return new WaitForSeconds(1);
            combatText.SetText("");

            attackButtonMain.gameObject.SetActive(true);
            itemButtonMain.gameObject.SetActive(true);
            partyButtonMain.gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(AIuseMove(random.Next(1, 5)));
        }
    }

    IEnumerator move2()
    {
        checkMoves();
        if (attackButton2.GetComponent<Image>().color == gray)
        {
            combatText.SetText("That move is out of uses.");
            yield break;
        }

        bool isCritical = false;
        attackButtonMain.gameObject.SetActive(false);
        itemButtonMain.gameObject.SetActive(false);
        partyButtonMain.gameObject.SetActive(false);        
        attackPanel.gameObject.SetActive(false);

        string pokemonName = go.GetComponent<SelectPokemon>().PokemonTeam[0];
        string moveName = "";
        int movePower = 0;
        int opposingDefense = 0;
        GameManager.Type moveType = GameManager.Type.NORMAL;
        GameManager.Type opponentPokemonType = GameManager.Type.NORMAL;

        // Get player pokemon damage and typing.
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            moveName = currentPlayerPokemon.GetComponent<Charizard>().getMove2();
            movePower = currentPlayerPokemon.GetComponent<Charizard>().useMove2();
            moveType = currentPlayerPokemon.GetComponent<Charizard>().getMove2Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            moveName = currentPlayerPokemon.GetComponent<Gallade>().getMove2();
            movePower = currentPlayerPokemon.GetComponent<Gallade>().useMove2();
            moveType = currentPlayerPokemon.GetComponent<Gallade>().getMove2Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            moveName = currentPlayerPokemon.GetComponent<Pikachu>().getMove2();
            movePower = currentPlayerPokemon.GetComponent<Pikachu>().useMove2();
            moveType = currentPlayerPokemon.GetComponent<Pikachu>().getMove2Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            moveName = currentPlayerPokemon.GetComponent<Feraligatr>().getMove2();
            movePower = currentPlayerPokemon.GetComponent<Feraligatr>().useMove2();
            moveType = currentPlayerPokemon.GetComponent<Feraligatr>().getMove2Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            moveName = currentPlayerPokemon.GetComponent<Sceptile>().getMove2();
            movePower = currentPlayerPokemon.GetComponent<Sceptile>().useMove2();
            moveType = currentPlayerPokemon.GetComponent<Sceptile>().getMove2Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            moveName = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove2();
            movePower = currentPlayerPokemon.GetComponent<Aerodactyl>().useMove2();
            moveType = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove2Type();
        }

        // Get opponent pokemon damage and typing.
        if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Charizard>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Charizard>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Gallade>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Gallade>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Pikachu>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Pikachu>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Feraligatr>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Feraligatr>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Sceptile>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Sceptile>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Aerodactyl>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Aerodactyl>().getType();
        }

        combatText.SetText(pokemonName + " used " + moveName);
        yield return new WaitForSeconds(2);

        if (movePower == 0)
        {
            combatText.SetText("It missed!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
            StartCoroutine(AIuseMove(random.Next(1, 5)));
            yield break;
        }

        // If critical, multiply the damage by 1.5
        if (random.Next(1, 100) <= 5)
            isCritical = true;

        // Calculate damage
        int damage = ((((movePower * 3) / 2 - opposingDefense) * checkType(moveType, opponentPokemonType)) / 2) + 10;

        if (isCritical == true)
        {
            damage *= 2;
        }

        // if xAttack is used then
        if (isDamageBoosted)
        {
            damage *= 2;
            // after damage calcuations is done set it back to false;
            isDamageBoosted = false;
            battleManager.GetComponent<BattleManager>().xAttackDeactivated();

        }

        

        lowerHealth(damage);

        // If critical, say it was critical
        if (isCritical == true)
        {
            combatText.SetText("It's a critical hit!!");
            yield return new WaitForSeconds(2);
        }

        // Check for type effectiveness
        if (checkType(moveType, opponentPokemonType) == 1)
            combatText.SetText("It was not very effective.");
        else if (checkType(moveType, opponentPokemonType) == 2)
            combatText.SetText("It was effective.");
        else if (checkType(moveType, opponentPokemonType) == 4)
            combatText.SetText("It was super effective!!");

        yield return new WaitForSeconds(2);
        if (currentOpponentHealth <= 0)
        {
            StartCoroutine(AIfaint(AIcounter));
            yield break;
        }

        combatText.SetText("");
        moveDisplay();
        checkMoves();

        // if shield is activated then message will be blocked
        if (isShieldActivated)
        {
            isShieldActivated = false;
            battleManager.GetComponent<BattleManager>().shieldDeactivated();
            combatText.SetText("The shield blocked the opponent's attack!");
            yield return new WaitForSeconds(2);

            combatText.SetText("Your turn.");
            yield return new WaitForSeconds(1);
            combatText.SetText("");

            attackButtonMain.gameObject.SetActive(true);
            itemButtonMain.gameObject.SetActive(true);
            partyButtonMain.gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(AIuseMove(random.Next(1, 5)));
        }
    }

    IEnumerator move3()
    {
        checkMoves();
        if (attackButton3.GetComponent<Image>().color == gray)
        {
            combatText.SetText("That move is out of uses.");
            yield break;
        }

        bool isCritical = false;
        attackButtonMain.gameObject.SetActive(false);
        itemButtonMain.gameObject.SetActive(false);
        partyButtonMain.gameObject.SetActive(false);
        attackPanel.gameObject.SetActive(false);

        string pokemonName = go.GetComponent<SelectPokemon>().PokemonTeam[0];
        string moveName = "";
        int movePower = 0;
        int opposingDefense = 0;
        GameManager.Type moveType = GameManager.Type.NORMAL;
        GameManager.Type opponentPokemonType = GameManager.Type.NORMAL;

        // Get player pokemon damage and typing.
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            moveName = currentPlayerPokemon.GetComponent<Charizard>().getMove3();
            movePower = currentPlayerPokemon.GetComponent<Charizard>().useMove3();
            moveType = currentPlayerPokemon.GetComponent<Charizard>().getMove3Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            moveName = currentPlayerPokemon.GetComponent<Gallade>().getMove3();
            movePower = currentPlayerPokemon.GetComponent<Gallade>().useMove3();
            moveType = currentPlayerPokemon.GetComponent<Gallade>().getMove3Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            moveName = currentPlayerPokemon.GetComponent<Pikachu>().getMove3();
            movePower = currentPlayerPokemon.GetComponent<Pikachu>().useMove3();
            moveType = currentPlayerPokemon.GetComponent<Pikachu>().getMove3Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            moveName = currentPlayerPokemon.GetComponent<Feraligatr>().getMove3();
            movePower = currentPlayerPokemon.GetComponent<Feraligatr>().useMove3();
            moveType = currentPlayerPokemon.GetComponent<Feraligatr>().getMove3Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            moveName = currentPlayerPokemon.GetComponent<Sceptile>().getMove3();
            movePower = currentPlayerPokemon.GetComponent<Sceptile>().useMove3();
            moveType = currentPlayerPokemon.GetComponent<Sceptile>().getMove3Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            moveName = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove3();
            movePower = currentPlayerPokemon.GetComponent<Aerodactyl>().useMove3();
            moveType = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove3Type();
        }

        // Get opponent pokemon damage and typing.
        if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Charizard>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Charizard>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Gallade>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Gallade>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Pikachu>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Pikachu>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Feraligatr>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Feraligatr>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
        {

            opposingDefense = currentOpponentPokemon.GetComponent<Sceptile>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Sceptile>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Aerodactyl>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Aerodactyl>().getType();
        }

        combatText.SetText(pokemonName + " used " + moveName);
        yield return new WaitForSeconds(2);

        if (movePower == 0)
        {
            combatText.SetText("It missed!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
            StartCoroutine(AIuseMove(random.Next(1, 5)));
            yield break;
        }

        // If critical, multiply the damage by 1.5
        if (random.Next(1, 100) <= 5)
            isCritical = true;

        // Calculate damage
        int damage = ((((movePower * 3) / 2 - opposingDefense) * checkType(moveType, opponentPokemonType)) / 2) + 10;

        // if xAttack is used then
        if (isDamageBoosted)
        {
            damage *= 2;
            // after damage calcuations is done set it back to false;
            isDamageBoosted = false;
            battleManager.GetComponent<BattleManager>().xAttackDeactivated();

        }



        if (isCritical == true)
        {
            damage *= 2;
        }

        lowerHealth(damage);

        // If critical, say it was critical
        if (isCritical == true)
        {
            combatText.SetText("It's a critical hit!!");
            yield return new WaitForSeconds(2);
        }

        // Check for type effectiveness
        if (checkType(moveType, opponentPokemonType) == 1)
            combatText.SetText("It was not very effective.");
        else if (checkType(moveType, opponentPokemonType) == 2)
            combatText.SetText("It was effective.");
        else if (checkType(moveType, opponentPokemonType) == 4)
            combatText.SetText("It was super effective!!");

        yield return new WaitForSeconds(2);
        if (currentOpponentHealth <= 0)
        {
            StartCoroutine(AIfaint(AIcounter));
            yield break;
        }

        combatText.SetText("");
        moveDisplay();
        checkMoves();

        // if shield is activated then message will be blocked
        if (isShieldActivated)
        {
            isShieldActivated = false;
            battleManager.GetComponent<BattleManager>().shieldDeactivated();
            combatText.SetText("The shield blocked the opponent's attack!");
            yield return new WaitForSeconds(2);

            combatText.SetText("Your turn.");
            yield return new WaitForSeconds(1);
            combatText.SetText("");

            attackButtonMain.gameObject.SetActive(true);
            itemButtonMain.gameObject.SetActive(true);
            partyButtonMain.gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(AIuseMove(random.Next(1, 5)));
        }
    }

    IEnumerator move4()
    {
        checkMoves();
        if (attackButton4.GetComponent<Image>().color == gray)
        {
            combatText.SetText("That move is out of uses.");
            yield break;
        }

        bool isCritical = false;
        attackButtonMain.gameObject.SetActive(false);
        itemButtonMain.gameObject.SetActive(false);
        partyButtonMain.gameObject.SetActive(false);
        attackPanel.gameObject.SetActive(false);

        string pokemonName = go.GetComponent<SelectPokemon>().PokemonTeam[0];
        string moveName = "";
        int movePower = 0;
        int opposingDefense = 0;
        GameManager.Type moveType = GameManager.Type.NORMAL;
        GameManager.Type opponentPokemonType = GameManager.Type.NORMAL;

        // Get player pokemon damage and typing.
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            moveName = currentPlayerPokemon.GetComponent<Charizard>().getMove4();
            movePower = currentPlayerPokemon.GetComponent<Charizard>().useMove4();
            moveType = currentPlayerPokemon.GetComponent<Charizard>().getMove4Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            moveName = currentPlayerPokemon.GetComponent<Gallade>().getMove4();
            movePower = currentPlayerPokemon.GetComponent<Gallade>().useMove4();
            moveType = currentPlayerPokemon.GetComponent<Gallade>().getMove4Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            moveName = currentPlayerPokemon.GetComponent<Pikachu>().getMove4();
            movePower = currentPlayerPokemon.GetComponent<Pikachu>().useMove4();
            moveType = currentPlayerPokemon.GetComponent<Pikachu>().getMove4Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            moveName = currentPlayerPokemon.GetComponent<Feraligatr>().getMove4();
            movePower = currentPlayerPokemon.GetComponent<Feraligatr>().useMove4();
            moveType = currentPlayerPokemon.GetComponent<Feraligatr>().getMove4Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            moveName = currentPlayerPokemon.GetComponent<Sceptile>().getMove4();
            movePower = currentPlayerPokemon.GetComponent<Sceptile>().useMove4();
            moveType = currentPlayerPokemon.GetComponent<Sceptile>().getMove4Type();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            moveName = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove4();
            movePower = currentPlayerPokemon.GetComponent<Aerodactyl>().useMove4();
            moveType = currentPlayerPokemon.GetComponent<Aerodactyl>().getMove4Type();
        }

        // Get opponent pokemon damage and typing.
        if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Charizard>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Charizard>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Gallade>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Gallade>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Pikachu>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Pikachu>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Feraligatr>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Feraligatr>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Sceptile>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Sceptile>().getType();

        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
        {
            opposingDefense = currentOpponentPokemon.GetComponent<Aerodactyl>().getDefense();
            opponentPokemonType = currentOpponentPokemon.GetComponent<Aerodactyl>().getType();
        }

        combatText.SetText(pokemonName + " used " + moveName);
        yield return new WaitForSeconds(2);

        if (movePower == 0)
        {
            combatText.SetText("It missed!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
            StartCoroutine(AIuseMove(random.Next(1, 5)));
            yield break;
        }

        // If critical, multiply the damage by 1.5
        if (random.Next(1, 100) <= 5)
            isCritical = true;

        // Calculate damage
        int damage = ((((movePower * 3) / 2 - opposingDefense) * checkType(moveType, opponentPokemonType)) / 2) + 10;

        // if xAttack is used then
        if (isDamageBoosted)
        {
            damage *= 2;
            // after damage calcuations is done set it back to false;
            isDamageBoosted = false;
            battleManager.GetComponent<BattleManager>().xAttackDeactivated();


        }


        if (isCritical == true)
        {
            damage *= 2;
        }

        lowerHealth(damage);

        // If critical, say it was critical
        if (isCritical == true)
        {
            combatText.SetText("It's a critical hit!!");
            yield return new WaitForSeconds(2);
        }

        // Check for type effectiveness
        if (checkType(moveType, opponentPokemonType) == 1)
            combatText.SetText("It was not very effective.");
        else if (checkType(moveType, opponentPokemonType) == 2)
            combatText.SetText("It was effective.");
        else if (checkType(moveType, opponentPokemonType) == 4)
            combatText.SetText("It was super effective!!");

        yield return new WaitForSeconds(2);
        if (currentOpponentHealth <= 0)
        {
            StartCoroutine(AIfaint(AIcounter));
            yield break;
        }

        combatText.SetText("Your turn");
        moveDisplay();
        checkMoves();

        // if shield is activated then message will be blocked
        if (isShieldActivated)
        {
            isShieldActivated = false;
            battleManager.GetComponent<BattleManager>().shieldDeactivated();
            combatText.SetText("The shield blocked the opponent's attack!");
            yield return new WaitForSeconds(2);

            combatText.SetText("Your turn.");
            yield return new WaitForSeconds(1);
            combatText.SetText("");

            attackButtonMain.gameObject.SetActive(true);
            itemButtonMain.gameObject.SetActive(true);
            partyButtonMain.gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(AIuseMove(random.Next(1, 5)));
        }
    }

    public void clickParty1()
    {
        combatText.SetText("That pokemon is already out.");
    }


    // **************AI**************


    IEnumerator AIfaint(int c)
    {
        combatText.SetText(go.GetComponent<SelectPokemon>().opponentTeam[0] + " has fainted.");
        yield return new WaitForSeconds(2);

        if (c == 1)
        {
            combatText.SetText("Next up...");
            yield return new WaitForSeconds(2);

            string temp;

            temp = go.GetComponent<SelectPokemon>().opponentTeam[0];
            go.GetComponent<SelectPokemon>().opponentTeam[0] = go.GetComponent<SelectPokemon>().opponentTeam[1];
            go.GetComponent<SelectPokemon>().opponentTeam[1] = temp;

            currentOpponentPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[0]);
            opponentPokemonName.SetText(go.GetComponent<SelectPokemon>().opponentTeam[0]);

            combatText.SetText(go.GetComponent<SelectPokemon>().opponentTeam[0] + "!!");
        }
        else if (c == 2)
        {
            combatText.SetText("Next up...");
            yield return new WaitForSeconds(2);

            string temp;

            temp = go.GetComponent<SelectPokemon>().opponentTeam[0];
            go.GetComponent<SelectPokemon>().opponentTeam[0] = go.GetComponent<SelectPokemon>().opponentTeam[2];
            go.GetComponent<SelectPokemon>().opponentTeam[2] = temp;

            currentOpponentPokemon = GameObject.Find(go.GetComponent<SelectPokemon>().opponentTeam[0]);
            opponentPokemonName.SetText(go.GetComponent<SelectPokemon>().opponentTeam[0]);

            combatText.SetText(go.GetComponent<SelectPokemon>().opponentTeam[0] + "!!");
        }
        else
        {
            combatText.SetText("Congratulations!\nYou Win!!!");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Victory");
        }

        opponentHealthBar.setHealth(getOpponentPokemonHealth());

        yield return new WaitForSeconds(2);
        combatText.SetText("");

        attackButtonMain.gameObject.SetActive(true);
        itemButtonMain.gameObject.SetActive(true);
        partyButtonMain.gameObject.SetActive(true);
    }

    IEnumerator AIuseMove(int rand)
    {
        bool isCritical = false;
        string pokemonName = go.GetComponent<SelectPokemon>().opponentTeam[0];
        string moveName = "";
        int movePower = 0;
        int playerDefense = 0;
        GameManager.Type moveType = GameManager.Type.NORMAL;
        GameManager.Type playerPokemonType = GameManager.Type.NORMAL;

        if (rand == 1)
        {
            // Get opponent pokemon damage and typing.
            if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
            {
                moveName = currentOpponentPokemon.GetComponent<Charizard>().getMove1();
                movePower = currentOpponentPokemon.GetComponent<Charizard>().useMove1();
                moveType = currentOpponentPokemon.GetComponent<Charizard>().getMove1Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
            {
                moveName = currentOpponentPokemon.GetComponent<Gallade>().getMove1();
                movePower = currentOpponentPokemon.GetComponent<Gallade>().useMove1();
                moveType = currentOpponentPokemon.GetComponent<Gallade>().getMove1Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
            {
                moveName = currentOpponentPokemon.GetComponent<Pikachu>().getMove1();
                movePower = currentOpponentPokemon.GetComponent<Pikachu>().useMove1();
                moveType = currentOpponentPokemon.GetComponent<Pikachu>().getMove1Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
            {
                moveName = currentOpponentPokemon.GetComponent<Feraligatr>().getMove1();
                movePower = currentOpponentPokemon.GetComponent<Feraligatr>().useMove1();
                moveType = currentOpponentPokemon.GetComponent<Feraligatr>().getMove1Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
            {
                moveName = currentOpponentPokemon.GetComponent<Sceptile>().getMove1();
                movePower = currentOpponentPokemon.GetComponent<Sceptile>().useMove1();
                moveType = currentOpponentPokemon.GetComponent<Sceptile>().getMove1Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
            {
                moveName = currentOpponentPokemon.GetComponent<Aerodactyl>().getMove1();
                movePower = currentOpponentPokemon.GetComponent<Aerodactyl>().useMove1();
                moveType = currentOpponentPokemon.GetComponent<Aerodactyl>().getMove1Type();
            }
        }
        else if (rand == 2)
        {
            // Get opponent pokemon damage and typing.
            if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
            {
                moveName = currentOpponentPokemon.GetComponent<Charizard>().getMove2();
                movePower = currentOpponentPokemon.GetComponent<Charizard>().useMove2();
                moveType = currentOpponentPokemon.GetComponent<Charizard>().getMove2Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
            {
                moveName = currentOpponentPokemon.GetComponent<Gallade>().getMove2();
                movePower = currentOpponentPokemon.GetComponent<Gallade>().useMove2();
                moveType = currentOpponentPokemon.GetComponent<Gallade>().getMove2Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
            {
                moveName = currentOpponentPokemon.GetComponent<Pikachu>().getMove2();
                movePower = currentOpponentPokemon.GetComponent<Pikachu>().useMove2();
                moveType = currentOpponentPokemon.GetComponent<Pikachu>().getMove2Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
            {
                moveName = currentOpponentPokemon.GetComponent<Feraligatr>().getMove2();
                movePower = currentOpponentPokemon.GetComponent<Feraligatr>().useMove2();
                moveType = currentOpponentPokemon.GetComponent<Feraligatr>().getMove2Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
            {
                moveName = currentOpponentPokemon.GetComponent<Sceptile>().getMove2();
                movePower = currentOpponentPokemon.GetComponent<Sceptile>().useMove2();
                moveType = currentOpponentPokemon.GetComponent<Sceptile>().getMove2Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
            {
                moveName = currentOpponentPokemon.GetComponent<Aerodactyl>().getMove2();
                movePower = currentOpponentPokemon.GetComponent<Aerodactyl>().useMove2();
                moveType = currentOpponentPokemon.GetComponent<Aerodactyl>().getMove2Type();
            }
        }
        else if (rand == 3)
        {
            // Get opponent pokemon damage and typing.
            if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
            {
                moveName = currentOpponentPokemon.GetComponent<Charizard>().getMove3();
                movePower = currentOpponentPokemon.GetComponent<Charizard>().useMove3();
                moveType = currentOpponentPokemon.GetComponent<Charizard>().getMove4Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
            {
                moveName = currentOpponentPokemon.GetComponent<Gallade>().getMove3();
                movePower = currentOpponentPokemon.GetComponent<Gallade>().useMove3();
                moveType = currentOpponentPokemon.GetComponent<Gallade>().getMove3Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
            {
                moveName = currentOpponentPokemon.GetComponent<Pikachu>().getMove3();
                movePower = currentOpponentPokemon.GetComponent<Pikachu>().useMove3();
                moveType = currentOpponentPokemon.GetComponent<Pikachu>().getMove3Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
            {
                moveName = currentOpponentPokemon.GetComponent<Feraligatr>().getMove3();
                movePower = currentOpponentPokemon.GetComponent<Feraligatr>().useMove3();
                moveType = currentOpponentPokemon.GetComponent<Feraligatr>().getMove3Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
            {
                moveName = currentOpponentPokemon.GetComponent<Sceptile>().getMove3();
                movePower = currentOpponentPokemon.GetComponent<Sceptile>().useMove3();
                moveType = currentOpponentPokemon.GetComponent<Sceptile>().getMove3Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
            {
                moveName = currentOpponentPokemon.GetComponent<Aerodactyl>().getMove3();
                movePower = currentOpponentPokemon.GetComponent<Aerodactyl>().useMove3();
                moveType = currentOpponentPokemon.GetComponent<Aerodactyl>().getMove3Type();
            }
        }
        else if (rand == 4)
        {
            // Get opponent pokemon damage and typing.
            if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
            {
                moveName = currentOpponentPokemon.GetComponent<Charizard>().getMove4();
                movePower = currentOpponentPokemon.GetComponent<Charizard>().useMove4();
                moveType = currentOpponentPokemon.GetComponent<Charizard>().getMove4Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
            {
                moveName = currentOpponentPokemon.GetComponent<Gallade>().getMove4();
                movePower = currentOpponentPokemon.GetComponent<Gallade>().useMove4();
                moveType = currentOpponentPokemon.GetComponent<Gallade>().getMove4Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
            {
                moveName = currentOpponentPokemon.GetComponent<Pikachu>().getMove4();
                movePower = currentOpponentPokemon.GetComponent<Pikachu>().useMove4();
                moveType = currentOpponentPokemon.GetComponent<Pikachu>().getMove4Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
            {
                moveName = currentOpponentPokemon.GetComponent<Feraligatr>().getMove4();
                movePower = currentOpponentPokemon.GetComponent<Feraligatr>().useMove4();
                moveType = currentOpponentPokemon.GetComponent<Feraligatr>().getMove4Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
            {
                moveName = currentOpponentPokemon.GetComponent<Sceptile>().getMove4();
                movePower = currentOpponentPokemon.GetComponent<Sceptile>().useMove4();
                moveType = currentOpponentPokemon.GetComponent<Sceptile>().getMove4Type();
            }
            else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
            {
                moveName = currentOpponentPokemon.GetComponent<Aerodactyl>().getMove4();
                movePower = currentOpponentPokemon.GetComponent<Aerodactyl>().useMove4();
                moveType = currentOpponentPokemon.GetComponent<Aerodactyl>().getMove4Type();
            }
        }

        // Get player pokemon damage and typing.
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            playerDefense = currentPlayerPokemon.GetComponent<Charizard>().getDefense();
            playerPokemonType = currentPlayerPokemon.GetComponent<Charizard>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            playerDefense = currentPlayerPokemon.GetComponent<Gallade>().getDefense();
            playerPokemonType = currentPlayerPokemon.GetComponent<Gallade>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            playerDefense = currentPlayerPokemon.GetComponent<Pikachu>().getDefense();
            playerPokemonType = currentPlayerPokemon.GetComponent<Pikachu>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            playerDefense = currentPlayerPokemon.GetComponent<Feraligatr>().getDefense();
            playerPokemonType = currentPlayerPokemon.GetComponent<Feraligatr>().getType();
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            playerDefense = currentPlayerPokemon.GetComponent<Sceptile>().getDefense();
            playerPokemonType = currentPlayerPokemon.GetComponent<Sceptile>().getType();

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            playerDefense = currentPlayerPokemon.GetComponent<Aerodactyl>().getDefense();
            playerPokemonType = currentPlayerPokemon.GetComponent<Aerodactyl>().getType();
        }

        combatText.SetText(pokemonName + " used " + moveName);
        yield return new WaitForSeconds(2);

        if (movePower == 0)
        {
            combatText.SetText("It missed!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
            attackButtonMain.gameObject.SetActive(true);
            itemButtonMain.gameObject.SetActive(true);
            partyButtonMain.gameObject.SetActive(true);
            yield break;
        }

        // If critical, multiply the damage by 1.5
        if (random.Next(1, 100) <= 10)
            isCritical = true;

        // Calculate damage
        int damage = ((((movePower * 3) / 2 + 10 - playerDefense) * checkType(moveType, playerPokemonType)) / 2) + 30;

        if (isCritical == true)
            damage *= 2;

        AIlowerHealth(damage);

        // If critical, say it was critical
        if (isCritical == true)
        {
            combatText.SetText("It's a critical hit!!");
            yield return new WaitForSeconds(2);
        }

        // Check for type effectiveness
        if (checkType(moveType, playerPokemonType) == 1)
            combatText.SetText("It was not very effective.");
        else if (checkType(moveType, playerPokemonType) == 2)
            combatText.SetText("It was effective.");
        else if (checkType(moveType, playerPokemonType) == 4)
            combatText.SetText("It was super effective!!");

        yield return new WaitForSeconds(2);
        if (getCurrentPokemonHealth() == 0)
        {
            combatText.SetText(go.GetComponent<SelectPokemon>().PokemonTeam[0] + " fainted.");
            yield return new WaitForSeconds(2);

            if (partyButton2.GetComponent<Image>().color == green)
            {
                StartCoroutine(swapParty2());

                attackButtonMain.gameObject.SetActive(true);
                itemButtonMain.gameObject.SetActive(true);
                partyButtonMain.gameObject.SetActive(true);

                yield break;
            }
            else if (partyButton3.GetComponent<Image>().color == green)
            {
                StartCoroutine(swapParty3());

                attackButtonMain.gameObject.SetActive(true);
                itemButtonMain.gameObject.SetActive(true);
                partyButtonMain.gameObject.SetActive(true);

                yield break;
            }
            else
            {
                StartCoroutine(lost());
                yield return new WaitForSeconds(2);
                SceneManager.LoadScene("Defeat");
                yield return new WaitForSeconds(2);
                yield break;
            }
        }

        combatText.SetText("Your turn.");
        yield return new WaitForSeconds(1);
        combatText.SetText("");

        attackButtonMain.gameObject.SetActive(true);
        itemButtonMain.gameObject.SetActive(true);
        partyButtonMain.gameObject.SetActive(true);
    }

    private void AIlowerHealth(int damage)
    {
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            currentPlayerPokemon.GetComponent<Charizard>().setHealth(currentPlayerPokemon.GetComponent<Charizard>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            currentPlayerPokemon.GetComponent<Gallade>().setHealth(currentPlayerPokemon.GetComponent<Gallade>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            currentPlayerPokemon.GetComponent<Pikachu>().setHealth(currentPlayerPokemon.GetComponent<Pikachu>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            currentPlayerPokemon.GetComponent<Feraligatr>().setHealth(currentPlayerPokemon.GetComponent<Feraligatr>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            currentPlayerPokemon.GetComponent<Sceptile>().setHealth(currentPlayerPokemon.GetComponent<Sceptile>().getHealth() - damage);
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            currentPlayerPokemon.GetComponent<Aerodactyl>().setHealth(currentPlayerPokemon.GetComponent<Aerodactyl>().getHealth() - damage);
        }

        if (currentPlayerHealth - damage <= 0)
        {
            playerHealthBar.setHealth(0);
            setCurrentPokemonHealth(0);
        }
        else
        {
            currentPlayerHealth -= damage;
            playerHealthBar.setHealth(currentPlayerHealth);
        }
    }

    IEnumerator lost()
    {
        combatText.SetText("Defeat...\nYou are out of pokemon.");
        yield return new WaitForSeconds(2);
    }
}
