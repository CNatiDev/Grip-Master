using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHeight : MonoBehaviour
{
    private void Update()
    {   float newY = (GameManager.Instance.L_Hand.transform.position.y + GameManager.Instance.R_Hand.transform.position.y) / 2;
        float newX = (GameManager.Instance.L_Hand.transform.position.x + GameManager.Instance.R_Hand.transform.position.x) / 2;
        transform.position = new Vector3(newX, newY , transform.position.z);
    }
}
