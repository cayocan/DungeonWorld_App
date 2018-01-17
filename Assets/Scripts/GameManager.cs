using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public Ficha ficha;

    [HideInInspector]
    public Classe classeSelecionada;

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

        //classeSelecionada = Ficha.instance.classeList[0];
    }
}
