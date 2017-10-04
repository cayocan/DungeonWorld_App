using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipamento : MonoBehaviour
{
    public GameObject equipElement;
    [Space(10)]

    public GameObject equipFichaGrid;
    [Space(10)]

    public GameObject armasGrid;
    public GameObject armadurasGrid;
    public GameObject aventuraEquipsGrid;
    public GameObject venenosGrid;
    public GameObject transportesGrid;
    public GameObject presentesGrid;

    private bool alreadyLoad = false;

    public Dictionary<string, string> armasDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> armadurasDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> aventuraEquipsDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> venenosDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> transportesDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> presentesOrnamentosDictionary = new Dictionary<string, string>();

    public void Awake()
    {
        #region Armas

        armasDictionary.Add("Arco Rústico", "próximo, 15 moedas, peso 2");
        armasDictionary.Add("Arco de Alta Qualidade", "próximo, distante, 60 moedas, peso 2");
        armasDictionary.Add("Arco de Caçador", "próximo, distante, 100 moedas, peso 1");
        armasDictionary.Add("Besta", "próximo, +1 de dano, recarga, 35 moedas, peso 3");
        armasDictionary.Add("Maço de Flechas", "munição 3, 1 moeda, peso 1");
        armasDictionary.Add("Flechas Élficas", "munição 4, 20 moedas, peso 1");
        armasDictionary.Add("Clava, Shillelagh", "corpo a corpo, 1 moeda, peso 2");
        armasDictionary.Add("Shillelagh", "corpo a corpo, 1 moeda, peso 2");
        armasDictionary.Add("Cajado", "corpo a corpo, duas mãos, 1 moeda, peso 1");
        armasDictionary.Add("Adaga", " mão, 2 moedas, peso 1");
        armasDictionary.Add("Shiv", "mão, 2 moedas, peso 1");
        armasDictionary.Add("Faca", "mão, 2 moedas, peso 1");
        armasDictionary.Add("Adaga de Arremesso", "arremesso, próximo, 1 moeda, peso 0");
        armasDictionary.Add("Espada Curta", "corpo a corpo, 8 moedas, peso 1");
        armasDictionary.Add("Machado", "corpo a corpo, 8 moedas, peso 1");
        armasDictionary.Add("Martelo de Batalha", "corpo a corpo, 8 moedas, peso 1");
        armasDictionary.Add("Maça", "corpo a corpo, 8 moedas, peso 1");
        armasDictionary.Add("Lança", "alcance, arremesso, próximo, 5 moedas, peso 1");
        armasDictionary.Add("Espada Longa", "corpo a corpo, +1 de dano, 15 moedas, peso 2");
        armasDictionary.Add("Machado de Batalha", "corpo a corpo, +1 de dano, 15 moedas, peso 2");
        armasDictionary.Add("Mangual", "corpo a corpo, +1 de dano, 15 moedas, peso 2");
        armasDictionary.Add("Alabarda", "alcance, +1 de dano, duas mãos, 9 moedas, peso 2");
        armasDictionary.Add("Florete", "corpo a corpo, preciso, 25 moedas, peso 1");
        armasDictionary.Add("Florete de Duelo", "corpo a corpo, 1 penetrante, preciso, 50 moedas, peso 2");

        #endregion


        #region Armaduras

        armadurasDictionary.Add("Couro", "armadura 1, vestida, 10 moedas, peso 1");
        armadurasDictionary.Add("Cota de Malha", "armadura 1, vestida, 10 moedas, peso 1");
        armadurasDictionary.Add("Armadura de Escamas", "armadura 2, vestida, desengonçada, 50 moedas, peso 3");
        armadurasDictionary.Add("Armadura de Placas", "armadura 3, vestida, desengonçada, 350 moedas, peso 4");
        armadurasDictionary.Add("Escudo", "armadura +1, 15 moedas, peso 2");

        #endregion


        #region Equipamentos de Aventura

        aventuraEquipsDictionary.Add("EQUIPAMENTO DE AVENTUREIRO - 5 usos, 20 moedas, peso 1", "O equipamento de aventureiro é uma coleção de itens mundanos úteis como giz, bastões, espigões, cordas, etc. Quando mexer em seu equipamento de aventureiro em busca de algum item mundano útil, encontre o que precisa, e gaste um uso.");
        aventuraEquipsDictionary.Add("BANDAGENS - 3 usos, lento, 5 moedas, peso 0", "Quando tiver alguns minutos para colocar bandagens nos ferimentos de alguém, cure 4 PV daquela pessoa e gaste um uso.");
        aventuraEquipsDictionary.Add("POMADAS E ERVAS - 2 usos, lento, 10 moedas, peso 1", "Quando cuidadosamente tratar os ferimentos de uma pessoa com o uso de pomadas e ervas, cure 7 PV daquela pessoa e gaste um uso.");
        aventuraEquipsDictionary.Add("POÇÃO DE CURA - 50 moedas, peso 0", "Quando você beber uma poção de cura inteira, cure 10 PV ou remova uma debilidade, à sua escolha.");
        aventuraEquipsDictionary.Add("BARRIL DE CERVEJA ANÃ - 10 moedas, peso 4", "Quando abrir um barril de cerveja anã e deixar que todos bebam livremente, receba +1 para suas rolagens de Farrear. Se beber o barril inteiro sozinho, você fica muito, mas muito bêbado mesmo.");
        aventuraEquipsDictionary.Add("SACOLA DE LIVROS - 5 usos, 10 moedas, peso 2", "Quando sua sacola de livros contém aquele exato tomo a respeito do assunto sobre o qual você estiver falando difícil, consulte o livro, gaste um uso, e receba +1 em sua rolagem.");
        aventuraEquipsDictionary.Add("ANTITOXINA - 10 moedas, peso 0", "Quando beber uma antitoxina, você será curado de um veneno que lhe estiver afligindo.");
        aventuraEquipsDictionary.Add("RAÇÕES DE MASMORRA - Ração, 5 usos, 3 moedas, peso 1", "Não tem um gosto muito bom, mas também não é de todo ruim.");
        aventuraEquipsDictionary.Add("BANQUETE PESSOAL - Ração, 1 uso, 10 moedas, peso 1", "Pura ostentação, para dizer o mínimo.");
        aventuraEquipsDictionary.Add("BOLACHA ANÃ - Requer anão, ração, 7 usos, 3 moedas, peso 1", "Anões dizem que tem o sabor de sua terra natal. Todas as outras pessoas dizem que se tem sabor de terra natal, você veio de uma fazenda de suínos que estava pegando fogo.");
        aventuraEquipsDictionary.Add("PÃO ÉLFICO - Ração, 7 usos, 10 moedas, peso 1", "Apenas os maiores dos amigos dos elfos recebem esta rara delícia.");
        aventuraEquipsDictionary.Add("CACHIMBO HALFLING - 6 usos, 5 moedas, peso 0", "Quando você compartilha um cachimbo halfling com alguém, gaste dois usos e receba +1 adiante para negociar com aquela pessoa.");

        #endregion


        #region Venenos

        venenosDictionary.Add("ÓLEO DE TAGIT - Perigoso, aplicado, 15 moedas, peso 0", "O alvo cai em um sono profundo.");
        venenosDictionary.Add("ERVA SANGRENTA - Perigoso, toque, 12 moedas, peso 0", "Até ser curado, sempre que o alvo rolar para causar dano, ele rola um d4 adicional e subtrai o resultado do dano provocado.");
        venenosDictionary.Add("RAIZ DOURADA - Perigoso, aplicado, 20 moedas, peso 0", "O alvo trata a próxima criatura que ver como um aliado confiável, até que se prove o contrário.");
        venenosDictionary.Add("LÁGRIMAS DA SERPENTE - Perigoso, toque, 10 moedas, peso 0", "Qualquer pessoa que role para causar dano no alvo deve rolar duas vezes o dado e utilizar o melhor resultado.");

        #endregion


        #region Transportes

        transportesDictionary.Add("Carroça e burro", "50 moedas, carga 20");
        transportesDictionary.Add("Cavalo", "75 moedas, carga 10");
        transportesDictionary.Add("Cavalo de Guerra", "400 moedas, carga 12");
        transportesDictionary.Add("Carroção", "150 moedas, carga 40");
        transportesDictionary.Add("Barca", "carga 15");
        transportesDictionary.Add("Bote", "150 moedas, carga 20");
        transportesDictionary.Add("Navio Mercante", "5.000 moedas, carga 200");
        transportesDictionary.Add("Navio de Guerra", "20.000 moedas, carga 100");

        #endregion


        #region Presentes e Ornamentos

        presentesOrnamentosDictionary.Add("Presente camponês", "1 moeda");
        presentesOrnamentosDictionary.Add("Presente fino", "55 moedas");
        presentesOrnamentosDictionary.Add("Presente nobre", "200 moedas");
        presentesOrnamentosDictionary.Add("Anel", "75 moedas");
        presentesOrnamentosDictionary.Add("Camafeu", "75 moedas");
        presentesOrnamentosDictionary.Add("Ornamento", "105 moedas");
        presentesOrnamentosDictionary.Add("Tapeçaria fina", "350+ moedas");
        presentesOrnamentosDictionary.Add("Uma coroa digna de um rei", "5.000 moedas");

        #endregion
    }

    private void Start()
    {
        CarregarTelaEquipamentos();
    }
    
    public void CarregarTelaEquipamentos()
    {
        GameObject obj = new GameObject();
        EquipmentHelper helper;

        if (!alreadyLoad)
        {
            //Carrega as Armas
            foreach (var item in armasDictionary)
            {
                obj = Instantiate(equipElement, armasGrid.transform);
                helper = obj.GetComponent<EquipmentHelper>();

                helper.nameText.text = item.Key;
                helper.descriptionText.text = item.Value;
            }

            //Carrega as Armaduras
            foreach (var item in armadurasDictionary)
            {
                obj = Instantiate(equipElement, armadurasGrid.transform);
                helper = obj.GetComponent<EquipmentHelper>();

                helper.nameText.text = item.Key;
                helper.descriptionText.text = item.Value;
            }

            //Carrega os Equipamentos de Aventura
            foreach (var item in aventuraEquipsDictionary)
            {
                obj = Instantiate(equipElement, aventuraEquipsGrid.transform);
                helper = obj.GetComponent<EquipmentHelper>();

                helper.nameText.text = item.Key;
                helper.descriptionText.text = item.Value;
            }

            //Carrega os Venenos
            foreach (var item in venenosDictionary)
            {
                obj = Instantiate(equipElement, venenosGrid.transform);
                helper = obj.GetComponent<EquipmentHelper>();

                helper.nameText.text = item.Key;
                helper.descriptionText.text = item.Value;
            }

            //Carrega os Transportes
            foreach (var item in transportesDictionary)
            {
                obj = Instantiate(equipElement, transportesGrid.transform);
                helper = obj.GetComponent<EquipmentHelper>();

                helper.nameText.text = item.Key;
                helper.descriptionText.text = item.Value;
            }

            //Carrega os Presentes e Ornamentos
            foreach (var item in presentesOrnamentosDictionary)
            {
                obj = Instantiate(equipElement, presentesGrid.transform);
                helper = obj.GetComponent<EquipmentHelper>();

                helper.nameText.text = item.Key;
                helper.descriptionText.text = item.Value;
            }
        }

        alreadyLoad = true;
    }

}