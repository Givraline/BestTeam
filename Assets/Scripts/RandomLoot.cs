using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    //Common : 45%
    //Uncommon : 30%
    //Rare : 20%
    //Legendary : 5%

    public static RandomLoot instance;
    public int[] table = { 45, 30, 20, 5 };

    private int randomNumber;
    private int randomCommon;
    private int randomUncommon;
    private int randomRare;

    [Header("Lake")]
    [SerializeField] private Fish[] commonFish;
    [SerializeField] private Fish[] uncommonFish;
    [SerializeField] private Fish[] rareFish;
    [SerializeField] private Fish[] legendaryFish;

    [Header("Sea")]
    [SerializeField] private Fish[] commonFishSea;
    [SerializeField] private Fish[] uncommonFishSea;
    [SerializeField] private Fish[] rareFishSea;
    [SerializeField] private Fish[] legendaryFishSea;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public Fish chooseFish()
    {
        randomNumber = Random.Range(1, 101);
        randomCommon = Random.Range(0, commonFish.Length);
        randomUncommon = Random.Range(0, uncommonFish.Length);
        randomRare = Random.Range(0, rareFish.Length);

        if (randomNumber <= 45)
        {
            //Debug.Log("Common");
            return commonFish[randomCommon];
        }
        else if ((randomNumber > 45) && (randomNumber <= 75))
        {
            //Debug.Log("Uncommon");
            return uncommonFish[randomUncommon];
        }
        else if ((randomNumber > 75) && (randomNumber <= 95))
        {
            //Debug.Log("Rare");
            return rareFish[randomRare];
        }
        else
        {
            //Debug.Log("Legendary");
            return rareFish[randomRare];
        }



    }

    public Fish chooseSeaFish()
    {
        randomNumber = Random.Range(1, 101);
        randomCommon = Random.Range(0, commonFish.Length);
        randomUncommon = Random.Range(0, uncommonFish.Length);
        randomRare = Random.Range(0, rareFish.Length);

        if (randomNumber <= 45)
        {
            //Debug.Log("Common");
            return commonFishSea[randomCommon];
        }
        else if ((randomNumber > 45) && (randomNumber <= 75))
        {
            //Debug.Log("Uncommon");
            return uncommonFishSea[randomUncommon];
        }
        else if ((randomNumber > 75) && (randomNumber <= 95))
        {
            //Debug.Log("Rare");
            return rareFishSea[randomRare];
        }
        else
        {
            //Debug.Log("Legendary");
            return legendaryFishSea[0];
        }

    }
    public float RandomNumer(float minVal, float maxVal)
    {
        return Random.Range(minVal, maxVal);
    }

}
