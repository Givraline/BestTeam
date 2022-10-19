using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Fish : ScriptableObject
{

    public int index;

    [Header("Fish")]
    public string fishName;
    [TextArea]
    public string fishDescription;

    public enum FishRarity
    {
        Common,
        UnCommon,
        Rare,
        Epic,
        Legendary
    };
    public FishRarity fishRarity;
    public Sprite hideFishImage;
    public Sprite fishImage;


    [Header("QTE Area")]
    [Range(0f, 1f)]
    public float minSliderValue;
    [Range(0f, 1f)]
    public float maxSliderValue;
    [Range(0f, 2.5f)]
    public float cursorSpeed;

}
