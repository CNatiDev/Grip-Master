using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject LastWall;
    public float Add_Y;
    public void LoadWall()
    {
        Vector3 Position = new Vector3(LastWall.transform.position.x, LastWall.transform.position.y + Add_Y, LastWall.transform.position.z);
        LastWall = Instantiate(Prefab, Position, Quaternion.identity);

    }
}
