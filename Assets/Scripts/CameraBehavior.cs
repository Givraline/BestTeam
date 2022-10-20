using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cinemachine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;
    [SerializeField] float maxFieldOfView;
    [SerializeField] float minFieldOfView;
    [SerializeField] float zoomSpeed;
    [SerializeField] bool zoomTest;
    private

    void Start()
    {

    }

    void Update()
    {
        cameraZoom();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FishableArea")
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FishableArea")
        {
            vcam.m_Lens.FieldOfView = 9;
        }
    }

    private void cameraZoom()
    {
        if (zoomTest)
        {
            Debug.Log("cam");
            //vcam.m_Lens.FieldOfView = Mathf.Clamp(vcam.m_Lens.FieldOfView - 3, 3, 9);
            vcam.m_Lens.FieldOfView = 3;
        }
        else
        {
            //vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView + 6, 9, 3);
            vcam.m_Lens.FieldOfView = 9;
        }
    }
}
