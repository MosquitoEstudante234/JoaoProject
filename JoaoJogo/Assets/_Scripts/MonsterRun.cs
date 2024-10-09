using UnityEngine;

public class MonsterRun : MonoBehaviour
{
    public AudioSource Footsteps;
    public GameObject[] playerAudios = new GameObject[0];
    public static bool CanRun;


    public void Start()
    {
        CanRun = false;
    }
    private void Update()
    {
        if (CanRun == true)
        {
            playerAudios[0].SetActive(true);

        }
        else
        {
            playerAudios[0].SetActive(false);
        }
    }
}
