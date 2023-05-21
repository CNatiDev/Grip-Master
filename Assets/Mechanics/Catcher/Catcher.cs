using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Catcher : MonoBehaviour
{
    private GameObject L_Hand;
    private GameObject R_Hand;
    private void Start()
    {
        L_Hand = GameObject.FindGameObjectWithTag("L_hand");
        R_Hand = GameObject.FindGameObjectWithTag("R_hand");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("L_hand"))
        {
            Connect_Hands(L_Hand, R_Hand);
            R_Hand.GetComponent<ObjectDrag>().Increase_Next_Point_Limit();
        }
        else if(other.gameObject.CompareTag("R_hand"))
        {
            Connect_Hands(R_Hand,L_Hand);
            L_Hand.GetComponent<ObjectDrag>().Increase_Next_Point_Limit();
        }
    }
    void Connect_Hands(GameObject Hand, GameObject Neighbor)
    {
        Hand.GetComponent<ObjectDrag>().Increase_Next_Point_Limit();
        Hand.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Hand.GetComponent<ObjectDrag>().connect = true;
        Hand.GetComponent<ObjectDrag>().isDragging = false;
        Neighbor.GetComponent<ObjectDrag>().connect = false;
        Debug.Log("catch");
    }
}
