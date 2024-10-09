using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialMission : MonoBehaviour
{
    public static int PaperCount;
    public TMP_Text PaperCountTxt;
    public GameObject ExitTutorialCol, OtherMissions, TutorialTextObj;
    public bool IsUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        PaperCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUnlocked == true)
        {
            TutorialTextObj.SetActive(false);
        }
        else
        {
            PaperCountTxt.text = "Find " + PaperCount.ToString() + " Papers";
            print("sim");
        }

        if (PaperCount == 0)
        {
            PaperCountTxt.text = "Unlock the door";
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (PaperCount == 0 && col.CompareTag("Tutorial"))
        {
            ExitTutorialCol.SetActive(false);
            OtherMissions.SetActive(true);
            IsUnlocked = true;
        }
    }
}
