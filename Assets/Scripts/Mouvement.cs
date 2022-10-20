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
    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerControler = new PlayerInputAction();
    }
    private void OnEnable()
    {
        move = playerControler.Player.Move;
        toggleNote.Enable();
        move.Enable();

    }

    private void OnDisable()
    {
        animator.SetFloat("Speed", 0);
        move.Disable();
        toggleNote.Disable();
    }

    private void Update()
    {
        mouvement = move.ReadValue<Vector2>().normalized;
        if(mouvement.x == 0 && mouvement.y == 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(mouvement.x) + Mathf.Abs(mouvement.y));
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(mouvement.x) + Mathf.Abs(mouvement.y));
        }


        Vector3 characterScale = transform.localScale;
        if(mouvement.x > 0)
        {
            //transform.eulerAngles = new Vector3(0,180,0);
            characterScale.x = -1;
        }
        else if(mouvement.x < 0)
        {
            //transform.eulerAngles = new Vector3(0,0,0);
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
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
