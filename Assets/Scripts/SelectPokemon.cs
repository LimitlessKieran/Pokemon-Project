using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPokemon : MonoBehaviour
{

    public GameObject pokemon;
    Vector3 pedestalPos = new Vector3(0.17f, -1.47f, 0.6f); //6868628
    Vector3 pedestalRotation = new Vector3(0f, 90f, 0f);
    Vector3 awayPosition = new Vector3(-946f, -1.47f, -205);
    Image image,image2,image3, backgroundimage;
    public GameObject battlebtn;
    public GameObject lockbtn;
    public Sprite c_Sprite;
    public Sprite s_Sprite;
    public Sprite f_Sprite;
    public Sprite p_Sprite;
    public Sprite a_Sprite;
    public Sprite g_Sprite;
    public int counter = 1;
    public string pokemon1;
    public string pokemon2;
    public string pokemon3;

    public List<string> PokemonTeam = new List<string>();

    void Start()
    {
        image = GameObject.FindWithTag("pokemon1").GetComponent<Image>();
        image2 = GameObject.FindWithTag("pokemon2").GetComponent<Image>();
        image3 = GameObject.FindWithTag("pokemon3").GetComponent<Image>();
        backgroundimage = GameObject.FindWithTag("backgroundimage").GetComponent<Image>();
        lockbtn.SetActive(false);
        battlebtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void swapPlaces(string pokemonName, Sprite sprite)
    {
        if (pokemon != null)
        {

            if (counter == 1)
            {
                image.sprite = sprite;
                pokemon1 = pokemonName;
                backgroundimage.sprite = sprite;
            }else if (counter == 2)
            {
                image2.sprite = sprite;
                pokemon2 = pokemonName;
                backgroundimage.sprite = sprite;
            }
            else if (counter == 3)
            {
                image3.sprite = sprite;
                pokemon3 = pokemonName;
                backgroundimage.sprite = sprite;

            }
            pokemon.transform.position = awayPosition;
            pokemon = GameObject.Find(pokemonName);

            pokemon.transform.position = pedestalPos;
            pokemon.transform.eulerAngles = pedestalRotation;
        }
        else
        {
            image.sprite = sprite;
            pokemon1 = pokemonName;
            backgroundimage.sprite = sprite;
            pokemon = GameObject.Find(pokemonName);
            pokemon.transform.position = pedestalPos;
            pokemon.transform.eulerAngles = pedestalRotation;
        }
    }
    public void ChooseCharizard()
    {
        swapPlaces("Charizard", c_Sprite);
        lockbtn.SetActive(true);
       
    }
    public void ChooseSeceptile()
    {

        swapPlaces("Sceptile",s_Sprite);
        lockbtn.SetActive(true);

    }

    public void ChooseFeraligatr()
    {
        swapPlaces("Feraligatr",f_Sprite);
        lockbtn.SetActive(true);
    }

    public void ChoosePikachu()
    {
        swapPlaces("Pikachu",p_Sprite);
        lockbtn.SetActive(true);

    }
    public void ChooseAerodactyl()
    {
        swapPlaces("Aerodactyl",a_Sprite);
        lockbtn.SetActive(true);

    }
    public void ChooseGallade()
    {
        swapPlaces("Gallade",g_Sprite);
        lockbtn.SetActive(true);


    }
    public void onSelect()
    {
      if(counter == 1)
      {
            PokemonTeam.Add(pokemon1);
            counter++;
      }
      else if (counter == 2)
        {
            if (PokemonTeam.Contains(pokemon2))
            {
                print("Err0r");
            }
            else
            {
                PokemonTeam.Add(pokemon2);
                counter++;
            }
        }
      else if(counter == 3)
        {
            if (PokemonTeam.Contains(pokemon3))
            {
                print("Err0r");
            }
            else
            {
                PokemonTeam.Add(pokemon3);
                counter++;
                battlebtn.SetActive(true);
                lockbtn.SetActive(false);
            }
            
        }

        lockbtn.SetActive(false);
    }

    public void battleTime()
    {
       

    }
}

