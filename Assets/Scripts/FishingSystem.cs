using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingSystem : MonoBehaviour
{
    private bool canFish;
    private bool isFishing;
    private Rigidbody2D rb;


    [SerializeField] private GameObject fishing;
    [SerializeField] private GameObject fishQTE;
    [SerializeField] private PlayerInputAction controler;
    [SerializeField] private InputAction toggleFishing;
    [SerializeField] private InputAction move;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controler = new PlayerInputAction();
        controler.Player.ToggleFishing.performed += toggle => ToggleFishingMode(ref isFishing);
    }
    private void OnEnable()
    {
        toggleFishing = controler.Player.ToggleFishing;
        move = controler.Player.Move;
        toggleFishing.Enable();
    }

    private void OnDisable()
    {
        toggleFishing.Disable();
    }

    private void ToggleFishingMode(ref bool isFishing)
    {
        toggleFishing.Disable();
        Invoke("AllowDisable", 0.5f);
        if (canFish)
        {
            isFishing = !isFishing;
            if (isFishing)
            {
                fishing.SetActive(true);
                GetComponent<Mouvement>().enabled = false;
                rb.velocity = Vector3.zero;
                Debug.Log("Fishing mode enabled");
            }
            else
            {
                fishQTE.SetActive(false);
                fishing.SetActive(false);
                GetComponent<Mouvement>().enabled = true;
                Debug.Log("Fishing mode disable.");
            }
        }
    }

    private void AllowDisable()
    {
        toggleFishing.Enable();
    }

    public void ExternalDisableFishingMode()
    {
        isFishing = true;
        Debug.Log("sdf");
        ToggleFishingMode(ref isFishing);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FishableArea")
            canFish = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FishableArea")
        {
            canFish = false;
        }
    }

}
