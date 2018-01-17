using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterManager : MonoBehaviour {
    [SerializeField]
    private List<ClassToCreate> charactersToggleList;

    public void ChooseCharacter()
    {
        foreach (var item in charactersToggleList)
        {
            if (item.comboBox.isOn)
            {
                foreach (var classe in Ficha.instance.classeList)
                {
                    if (classe.classe == item.classe)
                    {
                        GameManager.instance.classeSelecionada = classe;
                        break;
                    }
                }
                break;
            }
        }

        Ficha.instance.CarregarFicha();
    }
}
