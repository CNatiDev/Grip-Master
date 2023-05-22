using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor_P : MonoBehaviour
{
    public Transform anchor_Point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(anchor_Point.position.x, anchor_Point.position.y, -11);
        transform.rotation = Quaternion.EulerAngles(0, 0, 0);
    }
}
