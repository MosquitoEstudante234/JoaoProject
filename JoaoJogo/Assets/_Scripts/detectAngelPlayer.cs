using UnityEngine;

public class detectAngelPlayer : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            BlindCreature.Instance.seekPlayer = true;
        }
    }
}