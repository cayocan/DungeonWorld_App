using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentosHelper : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;

    public void DestroyElement()
    {
        GameObject.Destroy(this.gameObject);
    }
}
