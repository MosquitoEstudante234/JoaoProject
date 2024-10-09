using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFlashlight : MonoBehaviour
{
    public GameObject FlashLight, flashobj;
    public static bool IsPicked = false;

    public void Start()
    {
        IsPicked = false;
    }
    public void Update()
    {   
        if (IsPicked == true)
        {
            FlashLight.SetActive(true);
            flashobj.SetActive(false);
        }

    }
}
