using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Alinhamento
{
    public Alinhamentos alinhamentoEnum;
    [TextArea]
    public string descricao;

    public enum Alinhamentos
    {
        Bom,
        Ordeiro,
        Leal,
        Neutro,
        Caótico,
        Mau
    };
}
