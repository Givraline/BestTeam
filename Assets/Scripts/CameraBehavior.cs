using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cinemachine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;

    void Start()
    {
        //vcam.m_Lens.FieldOfView = 80;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FishableArea")
        {
            StartCoroutine(Zoom());
            IEnumerator Zoom()
            {
                float zoomTotalTime = 3;
                float zoomTime = 1;
                float maxFieldOfView = 80;
                float minFieldOfView = 60;
                while(zoomTime > 0)
                {
                    zoomTime -= Time.deltaTime;
                    vcam.m_Lens.FieldOfView = Mathf.Lerp(maxFieldOfView, minFieldOfView, 1 - (zoomTime / zoomTotalTime));
                    yield return null;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FishableArea")
        {
            StartCoroutine(DeZoom());
            IEnumerator DeZoom()
            {
                float zoomTotalTime = 1;
                float zoomTime = 1;
                float maxFieldOfView = 80;
                float minFieldOfView = 60;
                while (zoomTime > 0)
                {
                    zoomTime -= Time.deltaTime;
                    vcam.m_Lens.FieldOfView = Mathf.Lerp(minFieldOfView, maxFieldOfView, 1 - (zoomTime / zoomTotalTime));
                    yield return null;
                }
            }
        }
    }
}
