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
    [TextArea(0, 15)]
    public string vinculoTemplate;

    [Space(10)]
    [TextArea(0, 15)]
    public string equipamentoDeComeco;

    [Space(10)]
    [TextArea(0, 15)]
    public string textMovimentosIniciais;
    [Space(5)]
    public List<Movimento> movimentosIniciaisList;

    [Space(10)]
    [TextArea(0, 15)]
    public string textMovimentosAvancados;
    [Space(5)]
    public List<Movimento> movimentosAvancadosList;



    public Dictionary<string, string> equipamentoDictionary = new Dictionary<string, string>();

    public Dictionary<string, string> racaDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> alinhamentoDictionary = new Dictionary<string, string>();

    public Dictionary<string, string> movimentoDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> movimentoAvancadoDictionary = new Dictionary<string, string>();

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
        alinhamentoDictionary.Clear();
        racaDictionary.Clear();

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
