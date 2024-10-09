using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagReducer : MonoBehaviour
{
    public GameObject TablesnChairs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            TablesnChairs.SetActive(true);
        } else
        {
            TablesnChairs.SetActive(false);
        }
    }
}
