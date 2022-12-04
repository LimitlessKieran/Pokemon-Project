using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
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

    GameObject attackButton1;
    GameObject attackButton2;
    GameObject attackButton3;
    GameObject attackButton4;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;

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

        playerHealthBar.setMaxHealth(getCurrentPokemonHealth());
        opponentHealthBar.setMaxHealth(getOpponentPokemonHealth());

        currentOpponentHealth = getCurrentPokemonHealth();
        currentPlayerHealth = getOpponentPokemonHealth();

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
    }

    // Update is called once per frame
    void Update()
    {
        ItemDisplay();
        partyDisplay();

        currentOpponentHealth = getCurrentPokemonHealth();
        currentPlayerHealth = getOpponentPokemonHealth();

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
        }
        else
        {
            opponentHealthBar.setHealth(currentOpponentHealth - damage);
            currentOpponentHealth -= damage;
            setOpponentPokemonHealth(currentOpponentHealth - damage);
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
                yield return new WaitForSeconds(2);
                potionCount--;
                ItemDisplay();

                // increasing the current pokemons health
                setCurrentPokemonHealth(currentPlayerHealth + 100);

                combatText.SetText(go.GetComponent<SelectPokemon>().PokemonTeam[0] + " HP was restored!");
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

            combatText.SetText("Select a attack!!!");
            yield return new WaitForSeconds(2);
            combatText.SetText("");
        }
        else
        {
            // check to see if the user has any xattacks
            if (xAttackCount > 0)
            {
                combatText.SetText("Your next attack damage has been increased!!");
                yield return new WaitForSeconds(2);
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
    
        if (elixirCount > 0)
        {
            elixirCount--;
            ItemDisplay();
            combatText.SetText("Which move would you like to restore?");
            yield return new WaitForSeconds(2);
        }
      
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
            return 3;
        else if (moveType == GameManager.Type.FIRE && opponentType == GameManager.Type.FIRE)
            return 1;
        else if (moveType == GameManager.Type.WATER && opponentType == GameManager.Type.WATER)
            return 1;
        else if (moveType == GameManager.Type.WATER && opponentType == GameManager.Type.FIRE)
            return 3;
        else if (moveType == GameManager.Type.WATER && opponentType == GameManager.Type.GRASS)
            return 1;
        else if (moveType == GameManager.Type.GRASS && opponentType == GameManager.Type.WATER)
            return 3;
        else if (moveType == GameManager.Type.GRASS && opponentType == GameManager.Type.FIRE)
            return 1;
        else if (moveType == GameManager.Type.GRASS && opponentType == GameManager.Type.GRASS)
            return 1;
        else if (moveType == GameManager.Type.FLYING && opponentType == GameManager.Type.FLYING)
            return 1;
        else if (moveType == GameManager.Type.FLYING && opponentType == GameManager.Type.ELECTRIC)
            return 1;
        else if (moveType == GameManager.Type.FLYING && opponentType == GameManager.Type.FIGHTING)
            return 3;
        else if (moveType == GameManager.Type.ELECTRIC && opponentType == GameManager.Type.ELECTRIC)
            return 1;
        else if (moveType == GameManager.Type.ELECTRIC && opponentType == GameManager.Type.FIGHTING)
            return 1;
        else if (moveType == GameManager.Type.ELECTRIC && opponentType == GameManager.Type.FLYING)
            return 3;
        else if (moveType == GameManager.Type.FIGHTING && opponentType == GameManager.Type.FIGHTING)
            return 1;
        else if (moveType == GameManager.Type.FIGHTING && opponentType == GameManager.Type.ELECTRIC)
            return 3;
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

        moveDisplay();
        checkMoves();
    }

    IEnumerator swapParty3()
    {
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

        moveDisplay();
        checkMoves();
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
            yield break;
        }

        // If critical, multiply the damage by 1.5
        if (random.Next(1, 100) <= 10)
            isCritical = true;

        // Calculate damage
        int damage = ((movePower - opposingDefense) * checkType(moveType, opponentPokemonType)) / 2;

        // if xAttack is used then 
        if (isDamageBoosted)
        {
            damage *= 3 / 2;
        }

        // after damage calcuations is done set it back to false; 
        isDamageBoosted = false;

        if (isCritical == true)
        {
            damage *= 3 / 2;
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
        else if (checkType(moveType, opponentPokemonType) == 3)
            combatText.SetText("It was super effective!!");

        yield return new WaitForSeconds(2);
        combatText.SetText("");
        moveDisplay();
        checkMoves();
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
            yield break;
        }

        // If critical, multiply the damage by 1.5
        if (random.Next(1, 100) <= 10)
            isCritical = true;

        // Calculate damage
        int damage = ((movePower - opposingDefense) * checkType(moveType, opponentPokemonType)) / 2;

        if (isCritical == true)
        {
            damage *= 3 / 2;
        }
            
        // if xAttack is used then 
        if (isDamageBoosted)
        {
            damage *= 3 / 2;
        }

        // after damage calcuations is done set it back to false; 
        isDamageBoosted = false;

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
        else if (checkType(moveType, opponentPokemonType) == 3)
            combatText.SetText("It was super effective!!");

        yield return new WaitForSeconds(2);
        combatText.SetText("");
        moveDisplay();
        checkMoves();
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
            yield break;
        }

        // If critical, multiply the damage by 1.5
        if (random.Next(1, 100) <= 10)
            isCritical = true;

        // Calculate damage
        int damage = ((movePower - opposingDefense) * checkType(moveType, opponentPokemonType)) / 2;

        // if xAttack is used then 
        if (isDamageBoosted)
        {
            damage *= 3 / 2;
        }

        // after damage calcuations is done set it back to false; 
        isDamageBoosted = false;

        if (isCritical == true)
        {
            damage *= 3 / 2;
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
        else if (checkType(moveType, opponentPokemonType) == 3)
            combatText.SetText("It was super effective!!");

        yield return new WaitForSeconds(2);
        combatText.SetText("");
        moveDisplay();
        checkMoves();
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
            yield break;
        }

        // If critical, multiply the damage by 1.5
        if (random.Next(1, 100) <= 10)
            isCritical = true;

        // Calculate damage
        int damage = ((movePower - opposingDefense) * checkType(moveType, opponentPokemonType)) / 2;

        // if xAttack is used then 
        if (isDamageBoosted)
        {
            damage *= 3/2;
        }

        // after damage calcuations is done set it back to false; 
        isDamageBoosted = false;

        if (isCritical == true)
        {
            damage *= 3 / 2;
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
        else if (checkType(moveType, opponentPokemonType) == 3)
            combatText.SetText("It was super effective!!");

        yield return new WaitForSeconds(2);
        combatText.SetText("");
        moveDisplay();
        checkMoves();
    }

    public void clickParty1()
    {
        combatText.SetText("That pokemon is already out.");
    }
}
    