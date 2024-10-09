using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TutoPapers : MonoBehaviour
{
    public GameObject Paper;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) 
        { 
            Paper.SetActive(false);
        }
        if (Input.GetKey(KeyCode.P))
        {
            MemoriesCounter.Instance.Artifact = 0;
        }
    }
    public void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Paper.SetActive(true);
            Destroy(gameObject);
            TutorialMission.PaperCount--;
            FindObjectOfType<AudioManager>().Play("TurnPage");
        }
    }
}
