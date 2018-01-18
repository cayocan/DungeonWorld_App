using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenuHelper : MonoBehaviour {

    private void Start()
    {
        SaveManager.instance.LoadSaveSlots();
    }

    private void OnEnable()
    {
        SaveManager.instance.LoadSaveSlots();
    }
}
