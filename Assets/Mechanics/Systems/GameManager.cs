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
    #region Stamina_Parameters
    public Slider Stamina;
    [HideInInspector]
    public float NormalStamina = 1;
    [HideInInspector]
    private float DragStamina = 2.5f;
    [HideInInspector]
    public bool Drag;
    [HideInInspector]
    public bool IsCatch;
    [HideInInspector]
    public float OldStamina = 0;
    [HideInInspector]
    public bool Add_Stamina = false;
    [HideInInspector]
    public float Stamina_Quantity = 20;
    #endregion
    public bool IsDie = false;
    
    void Update()
    {
        #region STAMINA
        if (!Add_Stamina)
        if(Drag)
            Stamina.value -= DragStamina * Time.deltaTime;
        else
            Stamina.value -= NormalStamina * Time.deltaTime;
        if (Stamina.value == 0)
        {
            R_Hand.GetComponent<ObjectDrag>().Die();
            L_Hand.GetComponent<ObjectDrag>().Die();
        }
        if (Add_Stamina)
        {
            AddStaminaOnSlider(); 
        }
        #endregion
    }

    public void AddStaminaOnSlider()
    {

            if (Stamina.value > OldStamina + Stamina_Quantity||Stamina.value ==100)
                Add_Stamina = false;
            else
                Stamina.value += 5 * Time.deltaTime;

    }
}
