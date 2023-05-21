using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is null");
            }
            return _instance;
        }

    }
    public GameObject L_Hand;
    public GameObject R_Hand;
    private void Awake()
    {
        _instance = this;
        L_Hand = GameObject.FindGameObjectWithTag("L_hand");
        R_Hand = GameObject.FindGameObjectWithTag("R_hand");
    }
    void Update()
    {
        
    }
}
