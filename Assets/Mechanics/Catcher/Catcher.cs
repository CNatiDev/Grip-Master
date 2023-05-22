using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Catcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("L_hand"))
        {
            Connect_Hands(GameManager.Instance.L_Hand, GameManager.Instance.R_Hand);
            GameManager.Instance.R_Hand.GetComponent<ObjectDrag>().Increase_Next_Point_Limit();
        }
        else if(other.gameObject.CompareTag("R_hand"))
        {
            Connect_Hands(GameManager.Instance.R_Hand, GameManager.Instance.L_Hand);
            GameManager.Instance.L_Hand.GetComponent<ObjectDrag>().Increase_Next_Point_Limit();
        }
    }
    void Connect_Hands(GameObject Hand, GameObject Neighbor)
    {
        Hand.GetComponent<ObjectDrag>().Increase_Next_Point_Limit();
        Hand.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Hand.GetComponent<ObjectDrag>().connect = true;
        Hand.GetComponent<ObjectDrag>().isDragging = false;
        Neighbor.GetComponent<ObjectDrag>().connect = false;
    }
}
