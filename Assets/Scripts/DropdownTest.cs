using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownTest : MonoBehaviour {
    Dictionary<string, string> alinhamento = new Dictionary<string, string>();
    Dropdown drop;
    
    private void Start()
    {
        drop = GetComponent<Dropdown>();
        alinhamento.Add("Neutro", "O personagem é neutro.");
        alinhamento.Add("Bom", "O personagem é bonzinho.");

        List<string> lista = new List<string>();

        foreach (var item in alinhamento.Keys)
        {
            lista.Add(item);
        }

        drop.AddOptions(lista);
        drop.onValueChanged.Invoke(0);
    }

    public void PrintResponse()
    {
        Debug.Log(drop.options[drop.value].text);
        Debug.Log(alinhamento[drop.options[drop.value].text]);
    }


}
