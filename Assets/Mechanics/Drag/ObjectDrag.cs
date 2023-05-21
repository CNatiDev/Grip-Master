using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    [HideInInspector]
    public bool isDragging = false;
    [HideInInspector]
    public bool connect = false;
    private Vector3 offset;
    public float Max_Y, Min_Y;
    public float Max_X, Min_X;
    public float Add_Max_Y;
    public ObjectDrag Neighbor;
    void OnMouseDown()
    {   if(!connect)
        isDragging = true;
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -11);
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            newPosition.x = Mathf.Min(newPosition.x, Max_X);
            newPosition.x = Mathf.Max(newPosition.x, Min_X);
            newPosition.y = Mathf.Clamp(newPosition.y, Min_Y, Max_Y);
            gameObject.transform.position = newPosition;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -11);
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
        Min_Y = this.transform.position.y;
        Max_Y = Neighbor.transform.localPosition.y+Add_Max_Y;
    }
}

