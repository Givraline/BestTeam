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

    [SerializeField] private PlayerInputAction controler;
    [SerializeField] private InputAction toggleFishing;

    private void OnEnable()
    {
        controler = new PlayerInputAction();
        toggleFishing = controler.Player.ToggleFishing;
        toggleFishing.Enable();
    }

    private void OnDisable()
    {
        toggleFishing.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canFish = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canFish = false;
    }

    private void ToggleFishingMode(bool isFishing)
    {

    }
}
