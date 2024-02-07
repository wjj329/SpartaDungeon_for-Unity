using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupAlert : UIBase
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private Button confirm;
    [SerializeField] private Button cancel;

    public void Setting(string title, UnityAction confirmAction, UnityAction cancelAction)
    {
        this.title.text = title;
        confirm.onClick.RemoveAllListeners();
        confirm.onClick.AddListener(confirmAction);
        cancel.onClick.RemoveAllListeners();
        cancel.onClick.AddListener(cancelAction);
    }
}
