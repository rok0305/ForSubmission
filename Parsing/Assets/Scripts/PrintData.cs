using UnityEngine;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;

public class PrintData : MonoBehaviour
{
    [SerializeField]
    private DataTable dataTable;
    //[SerializeField]
    private MonsterDataTable monsterDataTable;

    private void Awake() // ATK, DEF, MaxHP status 안에 저장
    {
         monsterDataTable = new MonsterDataTable();
         monsterDataTable.data = new List<MonsterDataTableEntity> { };

        for (int i = 0; i < dataTable.data.Count; i++)
        {
            MonsterDataTableEntity mdte = new MonsterDataTableEntity();

            mdte.ID = dataTable.data[i].ID;
            mdte.NameString = dataTable.data[i].NameString;
            mdte.status.ATK = dataTable.data[i].ATK;
            mdte.status.DEF = dataTable.data[i].DEF;
            mdte.status.MaxHP = dataTable.data[i].MaxHP;

            /*Debug.Log(dataTable.data[i].ID);
            Debug.Log(dataTable.data[i].NameString);
            Debug.Log(dataTable.data[i].ATK);
            Debug.Log(dataTable.data[i].DEF);
            Debug.Log(dataTable.data[i].MaxHP);*/

            monsterDataTable.data.Add(mdte);
        }

    }

    [ContextMenu("To Json Data")]
    void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(monsterDataTable, true);
        string path = Path.Combine(Application.dataPath, "playData.json");
        File.WriteAllText(path, jsonData);
    }
}
