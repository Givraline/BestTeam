using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cinemachine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;
    public GameObject cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //d�sac
        if (collision.tag == "FishableArea")
        {
            cam.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //r�ac
        if (collision.tag == "FishableArea")
        {
            cam.SetActive(true);
        }
    }
}
