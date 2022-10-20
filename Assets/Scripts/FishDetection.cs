using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FishDetection : MonoBehaviour
{
    public GameObject[] Slot;
    public Fish[] FishArray;
    public TextMeshPro[] FishDescription;

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
                Slot[i].GetComponent<Image>().sprite = f.fishImage;
                Slot[i].GetComponentInChildren<TextMeshPro>().text = f.fishName;
                break;
           }
            i++;
        }
    }
}
