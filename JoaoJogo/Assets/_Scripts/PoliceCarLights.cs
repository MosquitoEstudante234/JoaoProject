using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarLights : MonoBehaviour
{
    public GameObject light1, light2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CarLights());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator CarLights()
    {
        yield return new WaitForSeconds(0.5f);
        light1.SetActive(true);
        light2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        light1.SetActive(false);
        light2.SetActive(true);
        StartCoroutine(CarLights());
    }
}
