using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Ficha : MonoBehaviour
{
    public static Ficha instance;

    public InputField forInput;
    public List<Atributo> atributoList;
    [Space(15)]

    public Text vidaText;
    public Text cargaText;
    [Space(15)]

    public Dropdown alinhamentoDropdown;
    public Text alinhamentoText;
    [Space(15)]

    public Dropdown racaDropdown;
    public Text racaText;
    [Space(15)]

    public InputField vinculoInput;
    [Space(15)]

    public Text equipamentoInicial;
    [Space(15)]

    public GameObject movimentoInicialElement;
    public Text movimentosIniciaisText;
    public GameObject fichaMovimentosIniciaisGrid;
    public GameObject movimentosIniciaisGrid;
    [Space(15)]

    public GameObject movimentoAvancadoElement;
    public Text movimentosAvancadosText;
    public GameObject fichaMovimentosAvancadosGrid;
    public GameObject movimentosAvancadosGrid;
    [Space(15)]

    public Text danoText;
    [Space(30)]

    public InputField nome;
    public InputField FOR, DES, CON, INT, SAB, CAR,
        armadura, cargaAtual, moedas, nivel, xp, vinculos;
    public Dropdown alinhamento, raca;
    public GameObject equipamentosGrid;
    [Space(15)]

    public List<Classe> classeList;

    private void Awake()
    {
        //Singleton statement.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    

    private void OnEnable()
    {

        //Registrando o método CalcularAtributos em todos o InputField OnChangeValue();
        foreach (Atributo att in atributoList)
        {
            att.attInput.onEndEdit.AddListener(delegate { CalcularAtributos(); });
        }

        alinhamentoDropdown.onValueChanged.AddListener(delegate { SelecionarAlinhamento(); });
        racaDropdown.onValueChanged.AddListener(delegate { SelecionarRaca(); });

        CarregarFicha();
    }

    private void OnDisable()
    {
        //Desregistrando o método CalcularAtributos em todos o InputField OnChangeValue();
        foreach (Atributo att in atributoList)
        {
            att.attInput.onEndEdit.RemoveAllListeners();
        }
    }

    private void Start()
    {
        CarregarFicha();
    }

    public void CarregarFicha()
    {
        CarregarDicionarios();
        CarregarDano();

        CarregarTextoEquipamentoInicial();

        CarregarTextoMovimentosIniciais();
        CarregarMovimentosIniciais();


        CarregarTextoMovimentosAvancados();
        CarregarMovimentosAvancados();
    }

    public void CalcularAtributos()
    {
        foreach (Atributo att in atributoList)
        {
            if (att.attInput.text == "")
            {
                att.attInput.text = "0";
            }
        }

        foreach (Atributo att in atributoList)
        {
            if (int.Parse(att.attInput.text) <= 3)
            {
                att.modText.text = "-3";
            }
            else if (int.Parse(att.attInput.text) >= 4 && int.Parse(att.attInput.text) <= 5)
            {
                att.modText.text = "-2";
            }
            else if (int.Parse(att.attInput.text) >= 6 && int.Parse(att.attInput.text) <= 8)
            {
                att.modText.text = "-1";
            }
            else if (int.Parse(att.attInput.text) >= 9 && int.Parse(att.attInput.text) <= 12)
            {
                att.modText.text = "0";
            }
            else if (int.Parse(att.attInput.text) >= 13 && int.Parse(att.attInput.text) <= 15)
            {
                att.modText.text = "+1";
            }
            else if (int.Parse(att.attInput.text) >= 16 && int.Parse(att.attInput.text) <= 17)
            {
                att.modText.text = "+2";
            }
            else if (int.Parse(att.attInput.text) >= 18)
            {
                att.modText.text = "+3";
            }


            if (att.attInput.CompareTag("Con"))
            {
                CalcularVida(int.Parse(att.attInput.text));
            }

            if (att.attInput.CompareTag("For"))
            {
                CalcularCarga(int.Parse(att.attInput.text));
            }
        }
    }

    public void CalcularVida(int _con)
    {
        vidaText.text = (GameManager.instance.classeSelecionada.modificadorVida + _con).ToString();
    }

    public void CalcularCarga(int _for)
    {
        cargaText.text = (GameManager.instance.classeSelecionada.modificadorCarga + _for).ToString();
    }

    public void CarregarDicionarios()
    {
        GameManager.instance.classeSelecionada.SignDictionaries();

        List<string> listaAux = new List<string>();

        foreach (var item in GameManager.instance.classeSelecionada.alinhamentoDictionary.Keys)
        {
            listaAux.Add(item);
        }

        alinhamentoDropdown.AddOptions(listaAux);
        try
        {
            alinhamentoDropdown.onValueChanged.Invoke(0);
        }
        catch (Exception)
        { }

        listaAux.Clear();

        foreach (var item in GameManager.instance.classeSelecionada.racaDictionary.Keys)
        {
            listaAux.Add(item);
        }

        racaDropdown.AddOptions(listaAux);
        try
        {
            racaDropdown.onValueChanged.Invoke(0);
        }
        catch (Exception)
        { }

    }

    public void CarregarDano()
    {
        danoText.text = "1D" + GameManager.instance.classeSelecionada.dano;
    }

    public void SelecionarAlinhamento()
    {
        alinhamentoText.text = GameManager.instance.classeSelecionada.alinhamentoDictionary[alinhamentoDropdown.options[alinhamentoDropdown.value].text];
    }

    public void SelecionarRaca()
    {
        racaText.text = GameManager.instance.classeSelecionada.racaDictionary[racaDropdown.options[racaDropdown.value].text];
    }

    public void AdicionarVinculoTemplate()
    {
        vinculoInput.text = GameManager.instance.classeSelecionada.vinculoTemplate;
    }

    public void CarregarTextoEquipamentoInicial()
    {
        equipamentoInicial.text = GameManager.instance.classeSelecionada.equipamentoDeComeco;
    }

    public void CarregarTextoMovimentosIniciais()
    {
        movimentosIniciaisText.text = GameManager.instance.classeSelecionada.textMovimentosIniciais;
    }

    public void CarregarMovimentosIniciais()
    {
        //Limpa a grid de movimentos iniciais
        foreach (Transform item in movimentosIniciaisGrid.transform)
        {
            Destroy(item.gameObject);
        }

        //Carrega a grid de movimentos iniciais da raça escolhida

        GameObject obj = new GameObject();
        MovimentosHelper helper;

        foreach (var item in GameManager.instance.classeSelecionada.movimentosIniciaisList)
        {
            obj = Instantiate(movimentoInicialElement, movimentosIniciaisGrid.transform);
            helper = obj.GetComponent<MovimentosHelper>();

            helper.nameText.text = item.nome;
            helper.descriptionText.text = item.descricao;
        }

    }

    public void CarregarTextoMovimentosAvancados()
    {
        movimentosAvancadosText.text = GameManager.instance.classeSelecionada.textMovimentosAvancados;
    }

    public void CarregarMovimentosAvancados()
    {
        //Limpa a grid de movimentos Avancados
        foreach (Transform item in movimentosAvancadosGrid.transform)
        {
            Destroy(item.gameObject);
        }

        //Carrega a grid de movimentos Avancados da raça escolhida

        GameObject obj = new GameObject();
        MovimentosHelper helper;

        foreach (var item in GameManager.instance.classeSelecionada.movimentosAvancadosList)
        {
            obj = Instantiate(movimentoAvancadoElement, movimentosAvancadosGrid.transform);
            helper = obj.GetComponent<MovimentosHelper>();

            helper.nameText.text = item.nome;
            helper.descriptionText.text = item.descricao;
        }
    }

    public void CarregarValoresDefault()
    {
        nome.text = "";
        FOR.text = "";
        DES.text = "";
        CON.text = "";
        INT.text = "";
        SAB.text = "";
        CAR.text = "";
        armadura.text = "";
        cargaAtual.text = "";
        moedas.text = "";
        nivel.text = "";
        xp.text = "";
        vinculos.text = "";

        alinhamento.value = 0;
        raca.value = 0;

        foreach (Transform item in equipamentosGrid.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in fichaMovimentosIniciaisGrid.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in movimentosAvancadosGrid.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
