using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private PlayerInputAction playerControler;
    [SerializeField] private InputAction move;
    [SerializeField] private InputAction toggleNote;

    private Vector2 mouvement;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControler = new PlayerInputAction();
        playerControler.Player.ToggleNote.performed += toggle => Test();
    }
    private void OnEnable()
    {
        move = playerControler.Player.Move;
        toggleNote = playerControler.Player.ToggleNote;
        toggleNote.Enable();
        move.Enable();

    }

    private void OnDisable()
    {
        move.Disable();
        toggleNote.Disable();
    }

    private void Update()
    {
        mouvement = move.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mouvement.x * speed, mouvement.y * speed);
    }
    
    private void Test()
    {
        Debug.Log("test");
    }
}
