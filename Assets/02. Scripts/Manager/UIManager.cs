using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Canvas MainCanvas;

    [SerializeField] private List<UIBase> uiList = new List<UIBase>();

    public Dictionary<string, UIBase> UI_List = new Dictionary<string, UIBase>();
    public Dictionary<string, UIBase> UI_Obj_List = new Dictionary<string, UIBase>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Init();
    }

    void Init()
    {
        foreach (UIBase ui in uiList)
        {
            UI_List.Add(ui.name, ui);
        }

        uiList.Clear();
    }

    public GameObject Show(string uiName)
    {
        if (!UI_List.ContainsKey(uiName))
            return null;

        UIBase ui = UI_List[uiName];

        GameObject obj = ui.Show();

        return obj;
    }

    public void Hide(string uiName)
    {
        if (!UI_Obj_List.ContainsKey(uiName))
            return;

        UIBase ui = UI_Obj_List[uiName];

        ui.Hide();
    }
}
