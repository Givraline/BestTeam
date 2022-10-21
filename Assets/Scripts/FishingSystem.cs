using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingSystem : MonoBehaviour
{
    [HideInInspector] public bool isSea;
   
    [HideInInspector] public bool isFishing;

    private bool canFish;
    private Rigidbody2D rb;
    private Transform target;
    private Animator animator;


    [SerializeField] private GameObject fishing;
    [SerializeField] private GameObject fishQTE;
    [SerializeField] private PlayerInputAction controler;
    [SerializeField] private InputAction toggleFishing;
    [SerializeField] private InputAction move;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controler = new PlayerInputAction();
        controler.Player.ToggleFishing.performed += toggle => ToggleFishingMode(ref isFishing);
    }
    private void OnEnable()
    {
        canFish = true;
        toggleFishing = controler.Player.ToggleFishing;
        move = controler.Player.Move;
        toggleFishing.Enable();
    }

    private void OnDisable()
    {
        toggleFishing.Disable();
        canFish = false;
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
                LookAtTheLake();
                animator.SetTrigger("FishTriger");

                fishing.SetActive(true);
                GetComponent<Mouvement>().enabled = false;
                rb.velocity = Vector3.zero;
                Debug.Log("Fishing mode enabled");
            }
            else
            {
                animator.SetTrigger("StopFishing");
                fishQTE.SetActive(false);
                fishing.SetActive(false);
                GetComponent<Mouvement>().enabled = true;
                Debug.Log("Fishing mode disable.");
            }
        }
    }

    private void LookAtTheLake()
    {
        float playerPosX = transform.position.x;
        float playerPosY = transform.position.y;

        float yMaxLimit = 19.4f;
        float yMinLimit = -10.3f;

        if (!isSea)
        {
            yMaxLimit = 6.6f;
            yMinLimit = -4.7f;
        }

        if(playerPosY >= yMaxLimit)
        {
            //Debug.Log(playerPosY);
            //Debug.Log("Top");
        }
        else if(playerPosY <= yMinLimit)
        {
            //Debug.Log("Bot");
        }
        else if(playerPosX > 0.5f)
        {
            //Debug.Log("right");
        }
        else if(playerPosX < 0.5f)
        {
            //Debug.Log("left");
        }

        //Debug.Log(playerPosX + " " + playerPosY);

        // -26
        // 3.6
    }

    private void AllowDisable()
    {
        toggleFishing.Enable();
    }

    public void ExternalDisableFishingMode()
    {
        isFishing = true;
        ToggleFishingMode(ref isFishing);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FishableArea")
        {
            canFish = true;
            target = collision.transform;

            if (collision.gameObject.name == "Sea")
                isSea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FishableArea")
        {
            canFish = false;
            target = null;
            isSea=false;
        }
    }

}
