using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    //Common : 45%
    //Uncommon : 30%
    //Rare : 15%
    //Epic : 8%
    //Legendary : 2%
    public int[] table = { 45, 30, 15, 8, 2 };

    public int randomNumber;
    public int randomCommon;
    public int randomUncommon;
    public int randomRare;
    public int randomEpic;

    [SerializeField] private Fish[] commonFish;
    [SerializeField] private Fish[] uncommonFish;
    [SerializeField] private Fish[] rareFish;
    [SerializeField] private Fish[] epicFish;
    [SerializeField] private Fish[] legendaryFish;

    private void Start()
    {
        chooseFish();
    }

    Fish chooseFish()
    {
        randomNumber = Random.Range(1, 101);
        randomCommon = Random.Range(0, 5);
        randomUncommon = Random.Range(0, 3);
        randomRare = Random.Range(0, 2);
        randomEpic = Random.Range(0, 1);

        if (randomNumber <= 45)
        {
            Debug.Log("Common");
            return commonFish[randomCommon];
        }
        else if ((randomNumber > 45) && (randomNumber <= 75))
        {
            Debug.Log("Uncommon");
            return uncommonFish[randomUncommon];
        }
        else if ((randomNumber > 75) && (randomNumber <= 90))
        {
            Debug.Log("Rare");
            return rareFish[randomRare];
        }
        else if ((randomNumber > 90) && (randomNumber <= 98))
        {
            Debug.Log("Epic");
            return epicFish[randomEpic];
        }
        else
        {
            Debug.Log("Legendary");
            return legendaryFish[0];
        }
    }

    private void Update()
    {
        
    }
}
