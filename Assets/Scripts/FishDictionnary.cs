using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FishDictionnary : MonoBehaviour
{

    [SerializeField] public GameObject dictionnaryUi;
    [SerializeField] private PlayerInputAction dictionnary;
    [SerializeField] private InputAction E;

    private void Awake()
    {
        dictionnary = new PlayerInputAction();
        dictionnary.Player.Fishdictionnary.performed += press => DictionnaryOpen();
    }

    void DictionnaryOpen()
    {
        dictionnaryUi.SetActive(!dictionnaryUi.activeSelf);
    }

    private void OnEnable()
    {
        E = dictionnary.Player.Fishdictionnary; 
        E.Enable();
    }

    private void OnDisable()
    {
        E.Disable();
    }
}
