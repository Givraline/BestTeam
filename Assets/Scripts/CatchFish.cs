using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CatchFish : MonoBehaviour
{
    public float fishCatchLifeTime;

    [SerializeField] private PlayerInputAction controler;
    [SerializeField] private InputAction getFish;
    [SerializeField] private InputAction catchFish;

    [SerializeField] private GameObject fishQTE;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fishIndicator;
    [SerializeField] private GameObject canva;
    [SerializeField] private GameObject fishPulled;
    [SerializeField] Animator animator;

    [SerializeField] private Slider minValue;
    [SerializeField] private Slider maxValue;
    [SerializeField] private Slider cursor;

    [SerializeField] private Fish fish;
    [SerializeField] private FishingSystem systemFish;

    private float fishLifeTimeLeft;
    private float fishSpeed;
    private bool isSliderValuePositive;
    private bool isFishing;
    private event Action OnCursorMove;
    private event Action OnFishLifeTime;

    private void Awake()
    {
        controler = new PlayerInputAction();
        controler.Player.CatchFish.performed += tryCatch => TryCatch();
        controler.Player.GetFish.performed += getFish => TryGetFish();
    }

    private void OnEnable()
    {
        if (systemFish.isSea)
        {
            fish = RandomLoot.instance.chooseSeaFish();
        }
        else
        {
            fish = RandomLoot.instance.chooseFish();
        }
        Debug.Log(fish.fishName);

        isFishing = false;
        catchFish = controler.Player.CatchFish;
        getFish = controler.Player.GetFish;

        fishLifeTimeLeft = fishCatchLifeTime;
        minValue.value = fish.minSliderValue;
        maxValue.value = fish.maxSliderValue;
        fishSpeed = fish.cursorSpeed;
        cursor.value = 0;

        WaitForFish();

    }

    private void OnDisable()
    {
        fishLifeTimeLeft = fishCatchLifeTime;
        fishIndicator.SetActive(false);
        OnCursorMove -= CursorMove;
        OnFishLifeTime -= DecreaseFishLifeTime;
        catchFish.Disable();
        getFish.Disable();
    }

    private void Update()
    {
        OnCursorMove?.Invoke();
        OnFishLifeTime?.Invoke();
    }

    private void WaitForFish()
    {
        if (!isFishing)
        {
            Debug.Log("prout");
            isFishing = true;
            Invoke("FishBiteBait", RandomLoot.instance.RandomNumer(1f, 10f));
        }
    }

    private void FishBiteBait()
    {
        getFish.Enable();
        OnFishLifeTime += DecreaseFishLifeTime;
        fishIndicator.SetActive(true);
    }
    public void StartQTE()
    {
        fishQTE.SetActive(true);
        OnCursorMove += CursorMove;
        catchFish.Enable();
    }

    private void TryGetFish()
    {
        getFish.Disable();
        OnFishLifeTime -= DecreaseFishLifeTime;
        fishIndicator.SetActive(false);

        if (fishLifeTimeLeft > 0)
        {
            StartQTE();
        }
        else
        {
            isFishing = false;
            Disable();
        }
    }

    private void DecreaseFishLifeTime()
    {
        getFish.Enable();
        fishLifeTimeLeft -= Time.deltaTime;

        if(fishLifeTimeLeft <= 0)
        {
            OnFishLifeTime -= DecreaseFishLifeTime;
            Disable();
            getFish.Disable();
        }
    }

    private void CursorMove()
    {
        if(cursor.value == 0)
            isSliderValuePositive = true;
        else if(cursor.value == 1)
            isSliderValuePositive = false;

        if(isSliderValuePositive)
            cursor.value += Time.deltaTime * fishSpeed;
        else
            cursor.value -= Time.deltaTime * fishSpeed;
    }

    private bool TryCatch()
    {
        catchFish.Disable();
        OnCursorMove -= CursorMove;
        isFishing = false;

        Invoke("Disable", 0.5f);
        if (cursor.value < maxValue.value && cursor.value > minValue.value)
        {
            Debug.Log("Catch Fish!");
            canva.GetComponent<FishDetection>().EnableFish(fish);
            fishPulled.GetComponent<Image>().sprite = fish.hideFishImage;
            fishPulled.SetActive(true);
            animator.SetTrigger("Triger");
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
        isFishing = false;
        fishQTE.SetActive(false);
        player.GetComponent<FishingSystem>().ExternalDisableFishingMode();
        gameObject.SetActive(false);
    }

}
