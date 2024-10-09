using UnityEngine;

public class PlayerAudios : MonoBehaviour
{
    public AudioSource Footsteps;
    public GameObject[] playerAudios = new GameObject[0];
    public float normalPitch = 1f;
    public float runningPitch = 2f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerAudios[0].SetActive(true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Footsteps.pitch = runningPitch;
            }
            else
            {
                Footsteps.pitch = normalPitch;
            }
        }
        else
        {
            playerAudios[0].SetActive(false);
            Footsteps.pitch = normalPitch; 
        }
    }
}
