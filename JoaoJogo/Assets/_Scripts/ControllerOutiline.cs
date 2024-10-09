using System.Collections;
using UnityEngine;

public class ControllerOutiline : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(OutlineAppears());
        }
        if (Input.GetButtonUp("Jump"))
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
    public IEnumerator OutlineAppears()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Outline>().enabled = true;
    }
}
