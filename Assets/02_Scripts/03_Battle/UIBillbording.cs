using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillbording : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        transform.forward = cam.transform.forward;
    }
}
