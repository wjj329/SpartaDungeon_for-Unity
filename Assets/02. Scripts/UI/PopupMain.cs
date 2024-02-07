using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupMain : UIBase
{
    [Header("User Info")]
    [SerializeField] private TMP_Text userName;
    [SerializeField] private TMP_Text userLv;
    [SerializeField] private TMP_Text userExp;
    [SerializeField] private Slider userExpSlider;

    [Header("User Stat")]
    [SerializeField] private TMP_Text userAtk;
    [SerializeField] private TMP_Text userDef;
    [SerializeField] private TMP_Text userSta;
    [SerializeField] private TMP_Text userCrt;

    [Header("User Inventory")]
    [SerializeField] private Transform content;
    [SerializeField] private GameObject itemSlot;

    private void Start()
    {
        Init();
        Refresh();
    }

    void Init()
    {
        foreach(Item item in GameManager.Instance.User.Inventory)
        {
            ItemSlot itemslot = Instantiate(itemSlot, content).GetComponent<ItemSlot>();
            itemslot.Init(item);
        }
    }

    public void Refresh()
    {
        UserData userData = GameManager.Instance.User;

        userName.text = userData.Name;
        userLv.text = $"LV <size=120%><b>{userData.Lv}</b></size>";
        userExp.text = $"{userData.NowExp} / {userData.FullExp}";
        userExpSlider.value = (float)userData.NowExp / userData.FullExp;

        Status stat = userData.GetAllStat();

        userAtk.text = $"공격력\n<b>{stat.atk}</b>";
        userDef.text = $"방어력\n<b>{stat.def}</b>";
        userSta.text = $"체  력\n<b>{stat.sta}</b>";
        userCrt.text = $"치명타\n<b>{stat.crt}</b>";

    }

}
