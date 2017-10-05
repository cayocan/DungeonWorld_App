using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentosIniciaisHelper : MonoBehaviour {

    public Text nameText;
    public Text descriptionText;
    public GameObject movimentoInicialFichaElement;


    public void AddInitialMovement()
    {
        GameObject obj = Instantiate(movimentoInicialFichaElement, Ficha.instance.fichaMovimentosIniciaisGrid.gameObject.transform);
        MovimentosIniciaisHelper helper = obj.GetComponent<MovimentosIniciaisHelper>();

        helper.nameText.text = nameText.text;
        helper.descriptionText.text = descriptionText.text;
    }

    public void DestroyElement()
    {
        GameObject.Destroy(this.gameObject);
    }
}
