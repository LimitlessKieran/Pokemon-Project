using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the bag of items for the user 
public class Bag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Potion is always going to be the 1st item in the list so we hardcoded it in
    // BattleUI Script will call this function to display the potions and the amount. 
    public string displayItem1(int amount)
    {
        return "Potion " + "\n\n" +
            " Uses left : " + amount;
    }
    // xAttack is always going to be the 2nd item in the list so we hardcoded it in
    // BattleUI Script will call this function to display the xAttacks and the amount. 
    public string displayItem2(int amount)
    {
        return "xAttack " + "\n\n" +
            " Uses left : " + amount;
    }
    // Shield is always going to be the 3nd item in the list so we hardcoded it in
    // BattleUI Script will call this function to display the shield and the amount. 
    public string displayItem3(int amount)
    {
        return "Shield " + "\n\n" +
            " Uses left : " + amount;
    }
    // Elixir is always going to be the 4th item in the list so we hardcoded it in
    // BattleUI Script will call this function to display the elixir and the amount. 
    public string displayItem4(int amount)
    {
        return "Elixir " + "\n\n" +
            " Uses left : " + amount;
    }
}
