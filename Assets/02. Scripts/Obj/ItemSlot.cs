using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image thumbnail;
    [SerializeField] private GameObject EquipObject;

    private Item item;

    public void Init(Item item)
    {
        this.item = item;

        thumbnail.sprite = item.Data.ItemSprite;
        EquipObject.SetActive(item.IsEquipped);
    }

    public void OnClickItem()
    {
        GameObject obj = UIManager.Instance.Show("PopupAlert");
        PopupAlert popupAlert = obj.GetComponent<PopupAlert>();

        popupAlert.Setting(item.IsEquipped ? "장착 해제 하시겠습니까??" : "장착 하시겠습니까??",
            () =>
            {
                item.IsEquipped = !item.IsEquipped;
                EquipObject.SetActive(item.IsEquipped);

                GameManager.Instance.SaveUserData();

                UIManager.Instance.Hide("PopupAlert");
            },
            () =>
            {
                UIManager.Instance.Hide("PopupAlert");
            });

        //void OnClickConfirm()
        //{
        //    item.IsEquipped = !item.IsEquipped;
        //    EquipObject.SetActive(item.IsEquipped);

        //    GameManager.Instance.SaveUserData();

        //    UIManager.Instance.Hide("PopupAlert");
        //}

        //void OnClickCancel()
        //{
        //    UIManager.Instance.Hide("PopupAlert");
        //}
    }
}
