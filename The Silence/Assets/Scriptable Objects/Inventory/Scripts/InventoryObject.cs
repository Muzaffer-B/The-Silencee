using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject 
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventoryy Container;

//    private void OnEnable()
//    {
//#if UNITY_EDITOR

//        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset",typeof(ItemDatabaseObject));
//#else
//        database = Resources.Load<ItemDatabaseObject>("Database");
//#endif
//    }

    public void AddItem(Item _item,int _amount)
    {
        if(_item.buffs.Length > 0)
        {
            Container.Items.Add(new InventorySlot(_item.Id, _item, _amount));
            return;
        }
        
        for (int i = 0; i < Container.Items.Count; i++)
        {
            if(Container.Items[i].item.Id == _item.Id)
            {
                Container.Items[i].AddAmount(_amount);
                
                return;
            }
        }
        
            Container.Items.Add(new InventorySlot(_item.Id,_item, _amount));
            
    }

    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath,savePath),FileMode.Create,FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Container = (Inventoryy)formatter.Deserialize(stream);
            stream.Close();
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventoryy();
    }
    //public void OnAfterDeserialize()
    //{
    //    for (int i = 0; i < Container.Items.Count; i++)
    //    {
    //        Container.Items[i].item = database.GetItem[Container.Items[i].ID];
    //    }
    //}

    //public void OnBeforeSerialize()
    //{
        
    //}
}

[System.Serializable]
public class Inventoryy
{
    public List<InventorySlot> Items = new List<InventorySlot>();

}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item;
    public int amount;
    public InventorySlot(int _id,Item _item,int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public  void AddAmount(int value)
    {
        amount += value;
    }
}