using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomEquipmentHelper : MonoBehaviour {

    public InputField nameText;
    public InputField descriptionText;

    public void DestroyElement()
    {
        GameObject.Destroy(this.gameObject);
    }
}
