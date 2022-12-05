using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectItem : MonoBehaviour
{
    public int potionCount = 0;
    public int xAttackCount = 0;
    public int shieldCount = 0;
    public int elixirCount = 0;
    public int seconds = 0;
    public TextMeshProUGUI potionCountText;
    public TextMeshProUGUI xAttackCountText;
    public TextMeshProUGUI shieldCountText;
    public TextMeshProUGUI elixirCountText;

    public GameObject errortxt;
    public GameObject clearbtn;
  
    void Start()
    {
        errortxt.SetActive(false);
        clearbtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (errortxt)
        {
            seconds++;
            if( seconds % 600 == 0)
            {
                errortxt.SetActive(false);
                seconds = 0;
            }
        }
    }

    public void onPotionSelect()
    {
        if (potionCount < 2)
        {
            clearbtn.SetActive(true);
            potionCount++;
            potionCountText.text = potionCount.ToString();
        }
        else
        {
            errortxt.SetActive(true);
        }
    }

    public void onxAttackSelect()
    {
        if (xAttackCount < 2)
        {
            clearbtn.SetActive(true);
            xAttackCount++;
            xAttackCountText.text = xAttackCount.ToString();
        }
        else
        {
            errortxt.SetActive(true);
        }
    }

    public void onShieldSelect()
    {
        if (shieldCount < 2)
        {
            clearbtn.SetActive(true);
            shieldCount++;
            shieldCountText.text = shieldCount.ToString();
        }
        else
        {
            errortxt.SetActive(true);
        }
    }

    public void onElixirSelect()
    {
        if (elixirCount < 2)
        {
            clearbtn.SetActive(true);
            elixirCount++;
            elixirCountText.text = elixirCount.ToString();
        }
        else
        {
            errortxt.SetActive(true);
        }
    }

    public void clearBag()
    {
        potionCount = 0;
        xAttackCount = 0;
        shieldCount = 0;
        elixirCount = 0;

        potionCountText.text = potionCount.ToString();
        xAttackCountText.text = xAttackCount.ToString();
        shieldCountText.text = shieldCount.ToString();
        elixirCountText.text = elixirCount.ToString();

        clearbtn.SetActive(false);
    }
}
