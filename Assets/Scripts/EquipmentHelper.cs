using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentHelper : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;
    public GameObject equipFichaElement;


    public void AddEquipment()
    {
        GameObject obj = Instantiate(equipFichaElement, EquipamentosGridSingleton.instance.gameObject.transform);
        EquipmentHelper helper = obj.GetComponent<EquipmentHelper>();

        helper.nameText.text = nameText.text;
        helper.descriptionText.text = descriptionText.text;
    }

    public void DestroyElement()
    {
        GameObject.Destroy(this.gameObject);
    }
}
