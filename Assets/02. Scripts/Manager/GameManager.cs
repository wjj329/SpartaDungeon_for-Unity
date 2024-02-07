using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Status
{
    public int atk;
    public int def;
    public int sta;
    public int crt;

    public Status(int atk, int def, int sta, int crt)
    {
        this.atk = atk;
        this.def = def;
        this.sta = sta;
        this.crt = crt;
    }
}


[System.Serializable]
public class UserData
{
    public string Name;
    public int Lv;
    public int NowExp;
    public int FullExp;
    public Status Stat;
    public List<Item> Inventory = new List<Item>();

    public Status GetAllStat()
    {
        Status status = new Status(Stat.atk, Stat.def, Stat.sta, Stat.crt);

        foreach(Item item in Inventory)
        {
            if(item.IsEquipped)
            {
                status.atk += item.Data.Stat.atk;
                status.def += item.Data.Stat.def;
                status.crt += item.Data.Stat.crt;
                status.sta += item.Data.Stat.sta;
            }
        }
        return status;
    }
}

[System.Serializable]
public class Item
{
    public bool IsEquipped;
    public ItemData Data;
}

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    public UserData User;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        LoadUserData("기사");
    }

    private void Start()
    {
        UIManager.Instance.Show("PopupMain");
    }

    public void SaveUserData()
    {
        string data = JsonUtility.ToJson(User, true);

        string path = Path.Combine(Application.dataPath, User.Name + ".json");

        File.WriteAllText(path, data);

        Debug.Log("저장 완료" + path);
    }    

    public void LoadUserData(string userName)
    {
        string path = Path.Combine(Application.dataPath, User.Name + ".json");

        string data = File.ReadAllText(path);

        User = JsonUtility.FromJson<UserData>(data);

        Debug.Log("불러오기 완료" + path);
    }
}
