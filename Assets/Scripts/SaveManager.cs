using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour {
    public static SaveManager instance;

    public GameObject saveSlotPrefab;
    public GameObject saveSlotGrid;

    [HideInInspector]
    public int currentSlotId;

    #region Save Bindings
    
    [HideInInspector]
    public Classe.Classes classe;//enum

    [Space(20)]
    public InputField nome;//string
    public InputField FOR, DES, CON, INT, SAB, CAR;//int
    public InputField armadura, cargaAtual, moedas, nivel, xp;//int
    public Dropdown alinhamento, raca;//int value
    public InputField vinculos;//string
    public GameObject equipamentosGrid, movimentosIniciaisGrid, movimentosAvancadosGrid;
    #endregion

    [Space(10)]
    public GameObject equipamentoElement;
    public GameObject movimentosIniciaisElement;
    public GameObject movimentosAvancadosElement;

    private List<int> saveSlotsId = new List<int>();

    private void Awake()
    {
        #region Singleton Statement
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion
    }

    public void CreateSaveSlot()
    {
        StartCoroutine(GenerateNewSlot());
    }

    public void LoadSaveSlots()
    {
        //Limpo o grid de slot buttons
        foreach (Transform item in saveSlotGrid.transform)
        {
            Destroy(item.gameObject);
        }

        if (ES2.Exists("saveSlotsId"))
        {
            List<int> saveSlots = ES2.LoadList<int>("saveSlotsId");
            Debug.Log(saveSlots);

            foreach (int item in saveSlots)
            {
                SaveSlot slot = Instantiate(saveSlotPrefab, saveSlotGrid.transform).GetComponent<SaveSlot>();

                slot.slotId = item;
                slot.slotCharName = ES2.Load<string>("nome" + slot.slotId);
                //slot.slotCharRace = raca.options[ES2.Load<int>("raca" + slot.slotId)].ToString();
                slot.slotCharClass = ES2.Load<Classe.Classes>("classe" + slot.slotId).ToString();
            }
        }
    }

    public void SaveCharSheet()
    {      
        ES2.Save<Classe.Classes>(GameManager.instance.classeSelecionada.classe, "classe" + currentSlotId);
        ES2.Save<string>(nome.text, "nome" + currentSlotId);
        ES2.Save<string>(FOR.text, "FOR" + currentSlotId);
        ES2.Save<string>(DES.text, "DES" + currentSlotId);
        ES2.Save<string>(CON.text, "CON" + currentSlotId);
        ES2.Save<string>(INT.text, "INT" + currentSlotId);
        ES2.Save<string>(SAB.text, "SAB" + currentSlotId);
        ES2.Save<string>(CAR.text, "CAR" + currentSlotId);
        ES2.Save<string>(armadura.text, "armadura" + currentSlotId);
        ES2.Save<string>(cargaAtual.text, "cargaAtual" + currentSlotId);
        ES2.Save<string>(moedas.text, "moedas" + currentSlotId);
        ES2.Save<string>(nivel.text, "nivel" + currentSlotId);
        ES2.Save<string>(xp.text, "xp" + currentSlotId);
        ES2.Save<int>(alinhamento.value, "alinhamento" + currentSlotId);
        ES2.Save<int>(raca.value, "raca" + currentSlotId);

        Dictionary<string, string> equipamentosDic = new Dictionary<string, string>();

        foreach (Transform item in equipamentosGrid.transform)
        {
            EquipmentHelper equipHelper = item.GetComponent<EquipmentHelper>();

            equipamentosDic.Add(equipHelper.nameText.text, equipHelper.descriptionText.text);
        }

        Dictionary<string, string> movInicDic = new Dictionary<string, string>();

        foreach (Transform item in movimentosIniciaisGrid.transform)
        {
            MovimentosHelper movInicHelper = item.GetComponent<MovimentosHelper>();

            movInicDic.Add(movInicHelper.nameText.text, movInicHelper.descriptionText.text);
        }

        Dictionary<string, string> movAvanDic = new Dictionary<string, string>();

        foreach (Transform item in movimentosAvancadosGrid.transform)
        {
            MovimentosHelper movAvanHelper = item.GetComponent<MovimentosHelper>();

            movAvanDic.Add(movAvanHelper.nameText.text, movAvanHelper.descriptionText.text);
        }

        ES2.Save(equipamentosDic, "equipamentos" + currentSlotId);
        ES2.Save(movInicDic, "movimentosIniciais" + currentSlotId);
        ES2.Save(movAvanDic, "movimentosAvancados" + currentSlotId);
    }

    public void LoadCharSheet(SaveSlot slot)
    {
        currentSlotId = slot.slotId;

        Classe.Classes classe = ES2.Load<Classe.Classes>("classe" + slot.slotId);

        foreach (var item in Ficha.instance.classeList)
        {
            if (item.classe == classe)
            {
                GameManager.instance.classeSelecionada = item;
            }
        }

        Ficha.instance.CarregarFicha();

        string x = ES2.Load<string>("nome" + slot.slotId);
        nome.text = x;

        FOR.text = ES2.Load<string>("FOR" + slot.slotId);
        DES.text = ES2.Load<string>("DES" + slot.slotId);
        CON.text = ES2.Load<string>("CON" + slot.slotId);
        INT.text = ES2.Load<string>("INT" + slot.slotId);
        SAB.text = ES2.Load<string>("SAB" + slot.slotId);
        CAR.text = ES2.Load<string>("CAR" + slot.slotId);
        armadura.text = ES2.Load<string>("armadura" + slot.slotId);
        cargaAtual.text = ES2.Load<string>("cargaAtual" + slot.slotId);
        moedas.text = ES2.Load<string>("moedas" + slot.slotId);
        nivel.text = ES2.Load<string>("nivel" + slot.slotId);
        xp.text = ES2.Load<string>("xp" + slot.slotId);
        alinhamento.value = ES2.Load<int>("alinhamento" + slot.slotId);
        raca.value = ES2.Load<int>("raca" + slot.slotId);

        foreach (var item in ES2.LoadDictionary<string, string>("equipamentos" + slot.slotId))
        {
            EquipmentHelper equipHelper = Instantiate(equipamentoElement, equipamentosGrid.transform).GetComponent<EquipmentHelper>();

            equipHelper.nameText.text = item.Key;
            equipHelper.descriptionText.text = item.Value;
        }

        foreach (var item in ES2.LoadDictionary<string, string>("movimentosIniciais" + slot.slotId))
        {
            MovimentosIniciaisHelper movInicHelper = Instantiate(movimentosIniciaisElement, movimentosIniciaisGrid.transform).GetComponent<MovimentosIniciaisHelper>();

            movInicHelper.nameText.text = item.Key;
            movInicHelper.descriptionText.text = item.Value;
        }

        foreach (var item in ES2.LoadDictionary<string, string>("movimentosAvancados" + slot.slotId))
        {
            MovimentosAvancadosHelper movAvancHelper = Instantiate(movimentosAvancadosElement, movimentosAvancadosGrid.transform).GetComponent<MovimentosAvancadosHelper>();

            movAvancHelper.nameText.text = item.Key;
            movAvancHelper.descriptionText.text = item.Value;
        }
    }

    IEnumerator GenerateNewSlot()
    {
        int randomId = Random.Range(0, 1000);

        while (saveSlotsId.Contains(randomId))
        {
            randomId = Random.Range(0, 1000);
            yield return null;
        }

        saveSlotsId.Add(randomId);
        currentSlotId = randomId;

        ES2.Save(saveSlotsId, "saveSlotsId");
    }
}
