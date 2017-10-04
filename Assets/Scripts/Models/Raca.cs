using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Raca
{
    public Racas racaEnum;
    [TextArea(0, 10)]
    public string descricao;

    public enum Racas
    {
        Humano,
        Elfo,
        Anao,
        Halfling
    };

}


