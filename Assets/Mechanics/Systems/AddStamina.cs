using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStamina : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("L_hand") && other.GetComponent<Rigidbody>().isKinematic)
        {
            GameManager.Instance.Add_Stamina = true;
            GameManager.Instance.OldStamina = GameManager.Instance.Stamina.value;
            gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("R_hand") && other.GetComponent<Rigidbody>().isKinematic)
        {
            GameManager.Instance.Add_Stamina = true;
            GameManager.Instance.OldStamina = GameManager.Instance.Stamina.value;
            gameObject.SetActive(false);
        }
    }
}
