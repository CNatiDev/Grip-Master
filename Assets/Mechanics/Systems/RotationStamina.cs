using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationStamina : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Speed of rotation
    float rotationAmount;
    // Update is called once per frame
    void Update()
    {

        rotationAmount +=  rotationSpeed * Time.deltaTime;
        // Rotate the object around the X-axis
        transform.rotation = Quaternion.EulerAngles(rotationAmount, -90, -90);
    }
}
