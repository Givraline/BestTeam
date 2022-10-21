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

    private void Update()
    {
        bool fCircle = Physics2D.OverlapCircle(Vector2.zero, fisrtCircleRadius, layer);
        bool sCircle = Physics2D.OverlapCircle(Vector2.zero, secondCircleRadius, layer);

        Debug.Log(fCircle);

        if(fCircle && sCircle)
        {
            Debug.Log("bruit que de lac");
        }
        else if (sCircle)
        {
            Debug.Log("Bruit blend");
        }
        else
        {
            Debug.Log("Bruit que de mer");
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