using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour {
    public Text slotText;
    public Button slotButton;
    [Space(15)]

    public int slotId;
    public string slotCharName = "";
    public string slotCharRace = "";
    public string slotCharClass = "";


    private void Start()
    {
        InitializeSlotText();

        slotButton.onClick.AddListener(ChangeTabs);
        slotButton.onClick.AddListener(() => SaveManager.instance.LoadCharSheet(this.GetComponent<SaveSlot>()));
    }

    private void OnEnable()
    {
        InitializeSlotText();
    }

    private void InitializeSlotText()
    {
        if (ES2.Exists(slotId + "slotCharName"))
        {
            slotCharName = ES2.Load<string>("slotCharName" + slotId);
        }

        if (ES2.Exists(slotId + "slotCharRace"))
        {
            slotCharRace = ES2.Load<string>("slotCharRace" + slotId);
        }

        if (ES2.Exists(slotId + "slotCharClass"))
        {
            slotCharClass = ES2.Load<string>("slotCharClass" + slotId);
        }
        
        slotText.text = slotCharName + " | " + slotCharRace + " | " + slotCharClass;
    }

    public void ChangeTabs()
    {
        TabsHolder.instance.homeTab.SetActive(false);
        TabsHolder.instance.sheetTab.SetActive(true);
    }
}
