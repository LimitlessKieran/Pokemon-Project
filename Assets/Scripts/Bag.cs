using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public string displayItem1(int amount)
    {
        return " Potion " + "\n\n Restore 300 Health" + "\n\n" +
            " Uses left : " + amount;
    }

    public string displayItem2(int amount)
    {
        return " xAttack " + "\n\n Powers up your next\n attack by 2x" + "\n\n" +
            " Uses left : " + amount;
    }

    public string displayItem3(int amount)
    {
        return " Shield " + "\n\n Blocks the next\n incoming attack" + "\n\n" +
            " Uses left : " + amount;
    }

    public string displayItem4(int amount)
    {
        return " Elixir " + "\n\n Fully restore the\n uses of 1 move" + "\n\n" +
            " Uses left : " + amount;
    }
}
