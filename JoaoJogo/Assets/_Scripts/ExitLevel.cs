using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public GameObject Fade;
    public void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("ExitTrigger"))
        {
            FindObjectOfType<AudioManager>().Play("EnterExit");
            StartCoroutine(TrocaCena());
            Destroy(col.gameObject);
            Fade.SetActive(true);
        }
    }
    public IEnumerator TrocaCena()
    {
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene("HospitalScene");
    }
}
