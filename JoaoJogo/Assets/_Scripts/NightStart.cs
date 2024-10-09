using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightStart : MonoBehaviour
{
    public GameObject DayTime;
    // Start is called before the first frame update
    void Start()
    {
        DayTime.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
