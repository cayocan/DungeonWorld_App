using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipamentosGridSingleton : MonoBehaviour
{
    public static EquipamentosGridSingleton instance;


    void Awake()
    {//Singleton statement.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
