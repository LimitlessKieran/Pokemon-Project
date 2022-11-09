using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAttack : MonoBehaviour
{
    int uses = 20;
    int power = 60;
    int accuracy = 100;
    GameManager.Type type = GameManager.Type.FLYING;

    public string display()
    {
        return " Wing Attack \n" +
            " Uses: " + uses + "\n\n" +
            " Power: " + power + "\n" +
            " Accuracy: " + accuracy + "\n" +
            " Type: " + type;
    }

    public int getPower()
    {
        return power;
    }

    public int getAccuracy()
    {
        return accuracy;
    }

    public int getUses()
    {
        return uses;
    }

    public GameManager.Type getType()
    {
        return type;
    }
}
