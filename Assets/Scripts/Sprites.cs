using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// this script will be used to assign sprites to the victory and defeat scene;


public class Sprites : MonoBehaviour
{


    public Sprite c_Sprite;
    public Sprite s_Sprite;
    public Sprite f_Sprite;
    public Sprite p_Sprite;
    public Sprite a_Sprite;
    public Sprite g_Sprite;

    Image myImage, myImage2, myImage3, oppImage, oppImage2, oppImage3;


    GameObject go;
    

    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("TeamCreater");

        myImage = GameObject.FindWithTag("pokemon1").GetComponent<Image>();
        myImage2 = GameObject.FindWithTag("pokemon2").GetComponent<Image>();
        myImage3 = GameObject.FindWithTag("pokemon3").GetComponent<Image>();

        oppImage = GameObject.Find("OpponentPokemon1").GetComponent<Image>();
        oppImage2 = GameObject.Find("OpponentPokemon2").GetComponent<Image>();
        oppImage3 = GameObject.Find("OpponentPokemon3").GetComponent<Image>();

        assignOpponentSprites();
        assignUserSprites();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function for placing sprites to the  opponents images
    public void assignOpponentSprites()
    {

        // first sprite for first pokemon on opponent team 
        if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Charizard")
        {
            oppImage.sprite = c_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Gallade")
        {
            oppImage.sprite = g_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Pikachu")
        {
            oppImage.sprite = p_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Feraligatr")
        {
            oppImage.sprite = f_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Sceptile")
        {
            oppImage.sprite = s_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[0] == "Aerodactyl")
        {
            oppImage.sprite = a_Sprite;
        }

        // second sprite for second pokemon on opponent team 
        if (go.GetComponent<SelectPokemon>().opponentTeam[1] == "Charizard")
        {
            oppImage2.sprite = c_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[1] == "Gallade")
        {
            oppImage2.sprite = g_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[1] == "Pikachu")
        {
            oppImage2.sprite = p_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[1] == "Feraligatr")
        {
            oppImage2.sprite = f_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[1] == "Sceptile")
        {
            oppImage2.sprite = s_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[1] == "Aerodactyl")
        {
            oppImage2.sprite = a_Sprite;
        }

        // third sprite for third pokemon on opponent team 
        if (go.GetComponent<SelectPokemon>().opponentTeam[2] == "Charizard")
        {
            oppImage3.sprite = c_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[2] == "Gallade")
        {
            oppImage3.sprite = g_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[2] == "Pikachu")
        {
            oppImage3.sprite = p_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[2] == "Feraligatr")
        {
            oppImage3.sprite = f_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[2] == "Sceptile")
        {
            oppImage3.sprite = s_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().opponentTeam[2] == "Aerodactyl")
        {
            oppImage3.sprite = a_Sprite;
        }
    }

    // function for placing sprites to the user images
    public void assignUserSprites()
    {
        // first sprite for first pokemon on user team 
        if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Charizard")
        {
            myImage.sprite = c_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Gallade")
        {
            myImage.sprite = g_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Pikachu")
        {
            myImage.sprite = p_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Feraligatr")
        {
            myImage.sprite = f_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Sceptile")
        {
            myImage.sprite = s_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[0] == "Aerodactyl")
        {
            myImage.sprite = a_Sprite;

        }

        // second sprite for second pokemon on user team 
        if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Charizard")
        {
            myImage2.sprite = c_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Gallade")
        {
            myImage2.sprite = g_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Pikachu")
        {
            myImage2.sprite = p_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Feraligatr")
        {
            myImage2.sprite = f_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Sceptile")
        {
            myImage2.sprite = s_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[1] == "Aerodactyl")
        {
            myImage2.sprite = a_Sprite;

        }

        // third sprite for third pokemon on user team 
        if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Charizard")
        {
            myImage3.sprite = c_Sprite;
        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Gallade")
        {
            myImage3.sprite = g_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Pikachu")
        {
            myImage3.sprite = p_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Feraligatr")
        {
            myImage3.sprite = f_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Sceptile")
        {
            myImage3.sprite = s_Sprite;

        }
        else if (go.GetComponent<SelectPokemon>().PokemonTeam[2] == "Aerodactyl")
        {
            myImage3.sprite = a_Sprite;

        }

    }
}
