using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareObj : MonoBehaviour
{
   public GameObject JumpscarePanel, JumpscareAudio;

   public void OnTriggerEnter(Collider col)
   {
        if(col.CompareTag("JumpscareTrigger"))
        {
            JumpscarePanel.SetActive(true);
            JumpscareAudio.SetActive(true);
        }
   }
}
