using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Audio;
public class ObjectDrag : MonoBehaviour
{
    [HideInInspector]
    public bool isDragging = false;
    public bool connect = false;
    private Vector3 offset;
    public float Max_Y, Min_Y;
    public float Max_X, Min_X;
    public float Add_Max_Y, Add_Max_X;
    public ObjectDrag Neighbor;
    public UnityEvent FinalEvent;
    public Transform P;
    public Transform Hand_Grip;
    void OnMouseDown()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -11);
        isDragging = true;
        offset = gameObject.transform.position - GetMouseWorldPosition();
        GetComponent<Rigidbody>().isKinematic = true;
        connect = false;
    }

    void OnMouseUp()
    {
        isDragging = false;
        GameManager.Instance.Drag = false;
        if (!connect)
        {
            GetComponent<Rigidbody>().isKinematic = false;
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
            GameManager.Instance.Drag = true;
            Increase_Next_Point_Limit();
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

        Min_X = P.transform.position.x;
        Max_X = Min_X + Add_Max_X;
        Min_Y = P.transform.localPosition.y - Add_Max_Y;
        Max_Y = Min_Y + 2.3f * Add_Max_Y;
    }
    public void Die()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Neighbor.GetComponent<Rigidbody>().isKinematic = false;
        FinalEvent.Invoke();
        GameManager.Instance.gameObject.GetComponent<ScoreManager>().SaveHighScore();
        GameManager.Instance.IsDie = true;
        ScoreManager Score_M = FindObjectOfType<ScoreManager>();
        float score = Score_M.score;
        TinySauce.OnGameFinished(score);
    }
    private void Update()
    {
        if (!isDragging && !GetComponent<Rigidbody>().isKinematic)
            transform.position = new Vector3(Hand_Grip.position.x, Hand_Grip.position.y, Hand_Grip.position.z);
        if (!connect && !Neighbor.connect)
            Die();
    }
}

