using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [HideInInspector]
    public Canvas canvas;

    public GameObject Show()
    {
        canvas = UIManager.Instance.MainCanvas;

        GameObject obj = Instantiate(gameObject, canvas.transform);
        obj.name = obj.name.Replace("(Clone)", "");

        UIManager.Instance.UI_Obj_List.Add(obj.name, obj.GetComponent<UIBase>());

        return obj;
    }

    public void Hide()
    {
        UIManager.Instance.UI_Obj_List.Remove(name);

        Destroy(gameObject);
    }
}
