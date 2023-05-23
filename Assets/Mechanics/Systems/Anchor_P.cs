using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor_P : MonoBehaviour
{
    public Transform anchor_Point;
    public Transform neighbor_Point;
    private float Distance_Between_Neighbor;
    // Start is called before the first frame update
    void Start()
    {
        Distance_Between_Neighbor = Vector3.Distance(anchor_Point.position, neighbor_Point.position);
    }

    // Update is called once per frame
    void Update()
    {
       // if (Distance_Between_Neighbor > Vector3.Distance(anchor_Point.position, neighbor_Point.position))
        transform.position = new Vector3(anchor_Point.position.x, anchor_Point.position.y, -11);
        transform.rotation = Quaternion.EulerAngles(0, 0, 0);
    }
}
