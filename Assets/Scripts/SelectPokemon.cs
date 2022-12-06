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
    Image image, image2, image3, backgroundimage;
    public GameObject battlebtn;
    public GameObject TeamCreater;
    public GameObject lockbtn, unlockbtn;
    public GameObject errortxt;
    public Sprite c_Sprite;
    public Sprite s_Sprite;
    public Sprite f_Sprite;
    public Sprite p_Sprite;
    public Sprite a_Sprite;
    public Sprite g_Sprite;
    public Sprite ball1, ball2, ball3;
    public int counter = 1;
    public string pokemon1;
    public string pokemon2;
    public string pokemon3;
    public SelectPokemon Instance;

    public List<string> PokemonTeam = new List<string>();
    public List<string> opponentTeam = new List<string>();
    public List<string> allPokemon = new List<string>();
    public List<int> Bag = new List<int>();

    int seconds = 0;
    void Start()
    {
        image = GameObject.FindWithTag("pokemon1").GetComponent<Image>();
        image2 = GameObject.FindWithTag("pokemon2").GetComponent<Image>();
        image3 = GameObject.FindWithTag("pokemon3").GetComponent<Image>();
        backgroundimage = GameObject.FindWithTag("backgroundimage").GetComponent<Image>();
        lockbtn.SetActive(false);
        unlockbtn.SetActive(false);
        battlebtn.SetActive(false);
        errortxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (errortxt)
        {
            seconds++;
            if (seconds % 600 == 0)
            {
                errortxt.SetActive(false);
                seconds = 0;
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
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
            } else if (counter == 2)
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
        swapPlaces("Sceptile", s_Sprite);
        lockbtn.SetActive(true);
    }

    public void ChooseFeraligatr()
    {
        swapPlaces("Feraligatr", f_Sprite);
        lockbtn.SetActive(true);
    }

    public void ChoosePikachu()
    {
        swapPlaces("Pikachu", p_Sprite);
        lockbtn.SetActive(true);
    }

    public void ChooseAerodactyl()
    {
        swapPlaces("Aerodactyl", a_Sprite);
        lockbtn.SetActive(true);
    }

    public void ChooseGallade()
    {
        swapPlaces("Gallade", g_Sprite);
        lockbtn.SetActive(true);
    }

    public void onSelect()
    {
        if (counter == 1)
        {
            PokemonTeam.Add(pokemon1);
            counter++;
        }
        else if (counter == 2)
        {
            if (PokemonTeam.Contains(pokemon2))
            {
                errortxt.SetActive(true);
                print("Err0r");
            }
            else
            {
                PokemonTeam.Add(pokemon2);
                counter++;
            }
        }
        else if (counter == 3)
        {
            if (PokemonTeam.Contains(pokemon3))
            {
                errortxt.SetActive(true);
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
        unlockbtn.SetActive(true);
    }

    public void onClear()
    {
        counter = 1;
        PokemonTeam.Clear();
        pokemon1 = "";
        pokemon2 = "";
        pokemon3 = "";

        image.sprite = ball1;
        image2.sprite = ball2;
        image3.sprite = ball3;

        battlebtn.SetActive(false);
        lockbtn.SetActive(false);
        unlockbtn.SetActive(false);
        pokemon.transform.position = awayPosition;
        backgroundimage.sprite = null;
    }

    public void battleTime()
    {
        Bag.Add(TeamCreater.GetComponent<SelectItem>().potionCount);
        Bag.Add(TeamCreater.GetComponent<SelectItem>().xAttackCount);
        Bag.Add(TeamCreater.GetComponent<SelectItem>().shieldCount);
        Bag.Add(TeamCreater.GetComponent<SelectItem>().elixirCount);

        GameObject manager = GameObject.Find("GameManager");
        allPokemon.Add("Charizard");
        allPokemon.Add("Sceptile");
        allPokemon.Add("Pikachu");
        allPokemon.Add("Feraligatr");
        allPokemon.Add("Aerodactyl");
        allPokemon.Add("Gallade");

        for (int i = 0; i < allPokemon.Count; i++)
        {
            if (PokemonTeam.Contains(allPokemon[i]))
            {

            }
            else
            {
                opponentTeam.Add(allPokemon[i]);
            }
        }
        if (manager)
        {
            if (manager.GetComponent<GameManager>().isStageForest)
            {
                manager.GetComponent<GameManager>().LoadScene("ForestStadium");
            }
            else if ((manager.GetComponent<GameManager>().isStageNight))
            {
                manager.GetComponent<GameManager>().LoadScene("NightStadium");
            }            
        }
        else
        {
            manager.GetComponent<GameManager>().LoadScene("ForestStadium");
            print("Default");
        }
    }
}

