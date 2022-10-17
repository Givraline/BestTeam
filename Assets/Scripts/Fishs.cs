using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Fishs : ScriptableObject
{

    [Header("Fish")]
    public string fishName;
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
    public Sprite fishImage;


    [Header("QTE Area")]
    [Range(0f, 1f)]
    public float minSliderValue;
    [Range(0f, 1f)]
    public float maxSliderValue;
}
