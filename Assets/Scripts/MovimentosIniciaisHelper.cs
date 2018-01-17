﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentosIniciaisHelper : MovimentosHelper
{
    public GameObject movimentoFichaElement;

    public void AddInitialMovement()
    {
        GameObject obj = Instantiate(movimentoFichaElement, Ficha.instance.fichaMovimentosIniciaisGrid.gameObject.transform);
        MovimentosHelper helper = obj.GetComponent<MovimentosHelper>();

        helper.nameText.text = nameText.text;
        helper.descriptionText.text = descriptionText.text;
    }
}
