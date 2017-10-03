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
        Leal,
        Neutro,
        Caótico,
        Mau
    };
}
