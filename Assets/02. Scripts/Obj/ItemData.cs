using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="ItemData_", menuName="Data/Item")]
public class ItemData : ScriptableObject
{
    public string Name;
    public Sprite ItemSprite;
    public Status Stat;

}
