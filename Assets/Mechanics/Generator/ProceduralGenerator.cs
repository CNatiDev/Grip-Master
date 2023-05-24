using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject LastWall;
    public GameObject LastWall_2;
    public float addY;

    public void LoadWall()
    {
        Vector3 position = Vector3.zero;

        if (LastWall != null)
            position = LastWall.transform.position + new Vector3(0f, addY, 0f);
        LastWall_2 = LastWall;
        LastWall = Instantiate(prefab, position, Quaternion.identity);
    }
}

