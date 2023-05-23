using UnityEngine;

public class DragWithLimit : MonoBehaviour
{
    [SerializeField]
    private HingeJoint hingeJoint;

    [SerializeField]
    private float maxDistance = 2f; // Valoarea maximă pentru distanța permisă între obiectul de tragere și ragdoll

    private Vector3 originalPosition;
    private float originalDistance;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        originalDistance = Vector3.Distance(transform.position, hingeJoint.connectedBody.transform.position);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, originalDistance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float distance = Vector3.Distance(objPosition, hingeJoint.connectedBody.transform.position);

        if (distance <= maxDistance)
        {
            hingeJoint.connectedAnchor = objPosition;
        }
        else
        {
            Vector3 direction = (objPosition - hingeJoint.connectedBody.transform.position).normalized;
            Vector3 limitedPosition = hingeJoint.connectedBody.transform.position + (direction * maxDistance);
            hingeJoint.connectedAnchor = limitedPosition;
        }
    }

    private void OnMouseUp()
    {
        hingeJoint.connectedAnchor = originalPosition;
    }
}

