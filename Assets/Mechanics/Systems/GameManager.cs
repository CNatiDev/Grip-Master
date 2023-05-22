using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    }
    #region Stamina
    public Slider Stamina;
    private float NormalStamina = 1;
    private float DragStamina = 2.5f;
    [HideInInspector]
    public bool Drag;
    #endregion
    void Update()
    {
        if(Drag)
        Stamina.value -= DragStamina * Time.deltaTime;
    else
        Stamina.value -= NormalStamina * Time.deltaTime;
        if (Stamina.value == 0)
        {
            R_Hand.GetComponent<ObjectDrag>().Die();
            L_Hand.GetComponent<ObjectDrag>().Die();
        }

    }
}
