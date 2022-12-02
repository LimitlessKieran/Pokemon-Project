using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject potionInfoText;
    public bool mouse_over = false;
    // Start is called before the first frame update
    void Start()
    {
        potionInfoText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse_over)
        {
            potionInfoText.SetActive(true);
        }
        else
        {
            potionInfoText.SetActive(false);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        
    }
}
