using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLasWall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("L_hand") || other.gameObject.CompareTag("R_hand"))
        {
            Destroy(GameManager.Instance.GetComponent<ProceduralGenerator>().LastWall);
            this.gameObject.SetActive(false);
        }
    }
}
