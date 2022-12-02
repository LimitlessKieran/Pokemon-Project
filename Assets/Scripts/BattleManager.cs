using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public GameObject go;
    public GameObject Pokemon1;
    public GameObject Pokemon2;
    public GameObject Pokemon3;
    public List<string> PokemonTeam = new List<string>() { "Charizard", "2", "3" };
    public static BattleManager battleManagerInstance;

    Vector3 yourTeam = new Vector3(42.59f, .009f, 44.98f); //6868628
    Vector3 oppTeam = new Vector3(25.4567f, 0.15f, 33.15f);
    Vector3 away = new Vector3(25.4567f, 0.15f, 33.15f);

    // Start is called before the first frame update
    void Start()
    {                
        for (int i = 0; i < GameManager.gameManagerInstance.PokemonTeam.Count-1; i++)
        {
            PokemonTeam[i] = GameManager.gameManagerInstance.PokemonTeam[i];
        }
        
        Pokemon1 = GameObject.Find(PokemonTeam[0]);
        Destroy(Pokemon1.GetComponent<RotateMe>());
        Pokemon1.transform.position = yourTeam;  
        
    }

    // Update is called once per frame
    void Update()
    {        
       
    }

    private void Awake()
    {
        if (battleManagerInstance == null)
        {
            battleManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (battleManagerInstance != this)
        {
            Destroy(gameObject);
        }
    }
}
