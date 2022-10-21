using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBasedOnPosition : MonoBehaviour
{
    [Range(0f, 40f)]
    [SerializeField] private float fisrtCircleRadius;
    [Range(0f, 40f)]
    [SerializeField] private float secondCircleRadius;

    [SerializeField] LayerMask layer;
    private Sound ocean;
    private Sound lake;

    private AudioManager audio;

    private void Start()
    {
        audio = AudioManager.instance;
        audio.Play("Ocean");
        audio.Play("Lake");

        ocean = audio.Findsound("Ocean");
        lake = audio.Findsound("Lake");
    }


    private void Update()
    {
        bool fCircle = Physics2D.OverlapCircle(Vector2.zero, fisrtCircleRadius, layer);
        bool sCircle = Physics2D.OverlapCircle(Vector2.zero, secondCircleRadius, layer);

        Debug.Log(fCircle);

        if(fCircle && sCircle)
        {
            audio.UpdateSound("Ocean", 0, ocean.pitch, ocean.loop);
            audio.UpdateSound("Lake", lake.volume, lake.pitch, lake.loop);
        }
        else if (sCircle)
        {
            audio.UpdateSound("Ocean", ocean.volume / 2, ocean.pitch, ocean.loop);
            audio.UpdateSound("Lake", lake.volume / 2, lake.pitch, lake.loop);
        }
        else
        {
            audio.UpdateSound("Lake", 0, lake.pitch, lake.loop);
            audio.UpdateSound("Ocean", ocean.volume, ocean.pitch, ocean.loop);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Vector2.zero, fisrtCircleRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Vector2.zero, secondCircleRadius);
    }
}