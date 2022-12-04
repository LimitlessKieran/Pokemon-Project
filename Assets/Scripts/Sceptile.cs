using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sceptile : MonoBehaviour
{
    int health;
    int attack;
    int defense;
    GameManager.Type type = GameManager.Type.GRASS;

    string move1Name = "Leaf Blade";
    int move1Uses = 3;
    int move1Power = 90;
    int move1Accuracy = 100;
    GameManager.Type move1Type = GameManager.Type.GRASS;

    string move2Name = "Slash";
    int move2Uses = 10;
    int move2Power = 70;
    int move2Accuracy = 100;
    GameManager.Type move2Type = GameManager.Type.NORMAL;

    string move3Name = "X-Scissor";
    int move3Uses = 5;
    int move3Power = 80;
    int move3Accuracy = 100;
    GameManager.Type move3Type = GameManager.Type.FIGHTING;

    string move4Name = "Leaf Storm";
    int move4Uses = 2;
    int move4Power = 120;
    int move4Accuracy = 85;
    GameManager.Type move4Type = GameManager.Type.GRASS;

    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        health = 1000;
        attack = 100;
        defense = 100;
    }

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int newHealth)
    {
        health = newHealth;
    }

    public int getAttack()
    {
        return attack;
    }

    public int getDefense()
    {
        return defense;
    }

    public GameManager.Type getType()
    {
        return type;
    }

    public string getMove1()
    {
        return move1Name;
    }

    public int useMove1()
    {
        int damage;

        if (random.Next(1, 100) <= move1Accuracy)
            damage = move1Power + attack;
        else
            damage = 0;

        move1Uses -= 1;

        return damage;
    }

    public string displayMove1()
    {
        return move1Name + "\n" +
            " Uses: " + move1Uses + "\n\n" +
            " Power: " + move1Power + "\n" +
            " Accuracy: " + move1Accuracy + "\n" +
            " Type: " + move1Type;
    }

    public int getMove1Uses()
    {
        return move1Uses;
    }

    public GameManager.Type getMove1Type()
    {
        return move1Type;
    }

    public string getMove2()
    {
        return move2Name;
    }

    public int useMove2()
    {
        int damage;

        if (random.Next(1, 100) <= move2Accuracy)
            damage = move2Power + attack;
        else
            damage = 0;

        move2Uses -= 1;

        return damage;
    }

    public string displayMove2()
    {
        return move2Name + "\n" +
            " Uses: " + move2Uses + "\n\n" +
            " Power: " + move2Power + "\n" +
            " Accuracy: " + move2Accuracy + "\n" +
            " Type: " + move2Type;
    }

    public int getMove2Uses()
    {
        return move2Uses;
    }


    public GameManager.Type getMove2Type()
    {
        return move2Type;
    }


    public string getMove3()
    {
        return move3Name;
    }

    public int useMove3()
    {
        int damage;

        if (random.Next(1, 100) <= move3Accuracy)
            damage = move3Power + attack;
        else
            damage = 0;

        move3Uses -= 1;

        return damage;
    }

    public string displayMove3()
    {
        return move3Name + "\n" +
            " Uses: " + move3Uses + "\n\n" +
            " Power: " + move3Power + "\n" +
            " Accuracy: " + move3Accuracy + "\n" +
            " Type: " + move3Type;
    }

    public int getMove3Uses()
    {
        return move3Uses;
    }

    public GameManager.Type getMove3Type()
    {
        return move3Type;
    }

    public string getMove4()
    {
        return move4Name;
    }

    public int useMove4()
    {
        int damage;

        if (random.Next(1, 100) <= move4Accuracy)
            damage = move4Power + attack;
        else
            damage = 0;

        move4Uses -= 1;

        return damage;
    }

    public string displayMove4()
    {
        return move4Name + "\n" +
            " Uses: " + move4Uses + "\n\n" +
            " Power: " + move4Power + "\n" +
            " Accuracy: " + move4Accuracy + "\n" +
            " Type: " + move4Type;
    }

    public int getMove4Uses()
    {
        return move4Uses;
    }

    public GameManager.Type getMove4Type()
    {
        return move4Type;
    }
}
