using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FishDetection : MonoBehaviour
{
    public GameObject[] Slot;
    public Fish[] FishArray;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(GameObject obj in Slot)
        {
            obj.GetComponent<Image>().sprite = FishArray[i].hideFishImage;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableFish(Fish fish)
    {
        int i = 0;
        foreach (Fish f in FishArray)
        {
           if(f == fish)
           {
                TextMeshProUGUI[] texts = Slot[i].GetComponentsInChildren<TextMeshProUGUI>();

                Slot[i].GetComponent<Image>().sprite = f.fishImage;
                Slot[i].GetComponent<Image>().color = Color.white;
                texts[0].text = f.fishName;
                texts[1].text = f.fishDescription;
                break;
           }
            i++;
        }
    }
}
