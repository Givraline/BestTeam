using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private PlayerInputActions controler;
    [SerializeField] private InputAction move;

    private Vector2 mouvement;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controler = new PlayerInputActions();
    }
    private void OnEnable()
    {
        move = controler.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        mouvement = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mouvement.x * speed, mouvement.y * speed);
    }
}
