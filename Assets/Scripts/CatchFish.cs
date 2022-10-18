using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CatchFish : MonoBehaviour
{
    [SerializeField] private PlayerInputAction controler;
    [SerializeField] private InputAction catchFish;

    [SerializeField] private GameObject fishQTE;
    [SerializeField] private GameObject player;

    [SerializeField] private Slider minValue;
    [SerializeField] private Slider maxValue;
    [SerializeField] private Slider cursor;

    [SerializeField] private Fish fish;

    private bool isSliderValuePositive;
    private event Action OnCursorMove;

    private void Awake()
    {
        controler = new PlayerInputAction();
        controler.Player.CatchFish.performed += tryCatch => TryCatch();
    }

    private void OnEnable()
    {
        fishQTE.SetActive(true);

        catchFish = controler.Player.CatchFish;
        catchFish.Enable();

        minValue.value = fish.minSliderValue;
        maxValue.value = fish.maxSliderValue;
        cursor.value = 0;

        OnCursorMove += CursorMove;
    }

    private void Update()
    {
        OnCursorMove?.Invoke();
    }

    private void CursorMove()
    {
        if(cursor.value == 0)
            isSliderValuePositive = true;
        else if(cursor.value == 1)
            isSliderValuePositive = false;

        if(isSliderValuePositive)
            cursor.value += Time.deltaTime * fish.cursorSpeed;
        else
            cursor.value -= Time.deltaTime * fish.cursorSpeed;
    }

    private bool TryCatch()
    {
        Invoke("Disable", 0.5f);
        OnCursorMove -= CursorMove;
        if (cursor.value < maxValue.value && cursor.value > minValue.value)
        {
            Debug.Log("Catch Fish!");
            return true;
        }
        else
        {
            Debug.Log("better luck next time");
            return false;
        }

    }

    public void Disable()
    {
        fishQTE.SetActive(false);
        player.GetComponent<FishingSystem>().ExternalDisableFishingMode();
    }

}
