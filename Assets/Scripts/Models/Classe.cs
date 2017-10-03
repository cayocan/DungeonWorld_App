using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Classe{
    public Classes classe;

    public int modificadorVida;
    public int modificadorCarga;
    public int dano;

    public List<Alinhamento> alinhamentosList;
    public List<Raca> racasList;

    [Space(10)]
    [TextArea]
    public string vinculoTemplate;

    [Space(10)]
    public List<Movimento> movimentoList;

    public Dictionary<string, string> racaDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> alinhamentoDictionary = new Dictionary<string, string>();

    public enum Classes
    {
        Barbaro,
        Bardo,
        Clerigo,
        Druida,
        Guerreiro,
        Ladrao,
        Mago,
        Paladino,
        Ranger
    };

    public void SignDictionaries()
    {
        foreach (Alinhamento alinhamento in alinhamentosList)
        {
            alinhamentoDictionary.Add(alinhamento.alinhamentoEnum.ToString(), alinhamento.descricao);
        }

        foreach (Raca raca in racasList)
        {
            racaDictionary.Add(raca.racaEnum.ToString(), raca.descricao);
        }        
    }
}
