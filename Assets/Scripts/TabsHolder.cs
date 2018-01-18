using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsHolder : MonoBehaviour {
    public static TabsHolder instance;

    public GameObject homeTab, charTab, sheetTab;

    private void Awake()
    {
        #region Singleton Statement
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion
    }
}
