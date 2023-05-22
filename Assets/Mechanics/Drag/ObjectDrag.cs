using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ObjectDrag : MonoBehaviour
{
    [HideInInspector]
    public bool isDragging = false;
    [HideInInspector]
    public bool connect = false;
    private Vector3 offset;
    public float Max_Y, Min_Y;
    public float Max_X, Min_X;
    public float Add_Max_Y, Add_Max_X;
    public ObjectDrag Neighbor;
    public UnityEvent FinalEvent;
    public Transform P;
    void OnMouseDown()
    {   
        isDragging = true;
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        isDragging = false;
        GameManager.Instance.Drag = false;
        if (!connect)
        {
            Die();
        }

    }
    void OnMouseDrag()
    {
        if (isDragging)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -11);
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            newPosition.y = Mathf.Clamp(newPosition.y, Min_Y, Max_Y);
            newPosition.x = Mathf.Clamp(newPosition.x, Mathf.Min(Min_X, Max_X), Mathf.Max(Min_X, Max_X));
            gameObject.transform.position= newPosition;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -11);
            GameManager.Instance.Drag = true;
            Min_X = P.transform.position.x;
            Max_X = Min_X + Add_Max_X;
        }

    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    public void Increase_Next_Point_Limit()
    {
        
        float Neighbor_Y = Neighbor.transform.localPosition.y;
        if (this.transform.position.y!= Neighbor_Y + Add_Max_Y&& this.transform.position.y< Neighbor_Y)
        Min_Y = this.transform.position.y;
        Max_Y = Neighbor_Y + Add_Max_Y;
       
    }
    public void Die()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Neighbor.GetComponent<Rigidbody>().isKinematic = false;
        FinalEvent.Invoke();
    }

}

