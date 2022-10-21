using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTreeChanger : MonoBehaviour
{
    [SerializeField] private Transform player;

    private SpriteRenderer sp;
    private SpriteRenderer playerSp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        playerSp = player.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(player.position.y > transform.position.y)
        {
            sp.sortingOrder  = playerSp.sortingOrder + 1;
        }
        else
        {
            sp.sortingOrder = playerSp.sortingOrder - 1;
        }
    }
}
