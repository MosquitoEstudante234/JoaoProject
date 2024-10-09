using UnityEditor;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Animator eyeDown, eyeUp;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            eyeDown.SetBool("IsClosed", true);
            eyeUp.SetBool("IsClosed", true);

            gameObject.GetComponent<Outline>().enabled = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            eyeDown.SetBool("IsClosed", false);
            eyeUp.SetBool("IsClosed", false);

            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
