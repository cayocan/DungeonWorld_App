using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentosAvancadosHelper : MovimentosHelper
{
    public GameObject movimentoFichaElement;

    public void AddAdvancedMovement()
    {
        GameObject obj = Instantiate(movimentoFichaElement, Ficha.instance.fichaMovimentosAvancadosGrid.gameObject.transform);
        MovimentosHelper helper = obj.GetComponent<MovimentosHelper>();

        helper.nameText.text = nameText.text;
        helper.descriptionText.text = descriptionText.text;
    }
}
