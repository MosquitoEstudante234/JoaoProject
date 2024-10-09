using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CurrentMission : MonoBehaviour
{
    public TMP_Text Mission;
    public string missiontxt;
    public void Start()
    {
        missiontxt = "Find your flashlight";
    }


    private void Update()
    {   
        if (PickFlashlight.IsPicked == true)
        {
            missiontxt = "Check the garage";
        }
        Mission.text = missiontxt.ToString();
    }
   
}