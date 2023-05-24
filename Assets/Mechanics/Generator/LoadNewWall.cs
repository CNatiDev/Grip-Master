using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewWall : MonoBehaviour
{
    public bool FirstWall = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("L_hand")|| other.gameObject.CompareTag("R_hand"))
        {
            GameManager.Instance.GetComponent<ProceduralGenerator>().LoadWall();
            if(!FirstWall)
            Destroy(GameManager.Instance.GetComponent<ProceduralGenerator>().LastWall);
            this.gameObject.SetActive(false);
        }
    }
}
