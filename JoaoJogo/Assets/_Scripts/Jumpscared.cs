using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscared : MonoBehaviour
{
    public GameObject jumpscareImage;
    float timerJumpscare = 2f;
    [SerializeField] bool isJumpscared;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jumpscareImage.SetActive(true);
            isJumpscared = true;
            FindObjectOfType<AudioManager>().Play("MainJumpscare");

        }
    }
    private void Update()
    {
        if (isJumpscared)
        {
            timerJumpscare -= Time.deltaTime;
            if(timerJumpscare <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
