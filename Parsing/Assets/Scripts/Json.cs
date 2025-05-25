using System.Collections;
using System.Collections.Generic;
//using static UnityEngine.JsonUtility;
using UnityEngine;
using System.IO;

public class Json : MonoBehaviour
{
    //[SerializeField]
    public DataTable data; // ������ ���̺� ����
    [ContextMenu("To Json Data")] // ����Ƽ�� �޴�â �߰�
    void SavePlayerDataToJson() // Json �����Ϳ� ������ ����
    {
        string jsonData = JsonUtility.ToJson(data, true); 
        string path = Path.Combine(Application.dataPath, "playerData.json"); 
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("Form Json Data")]
    void LoadPlayerDataToJson() // Json ������ �ҷ�����
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        //data = JsonUtility.FromJson<DataTable>(jsonData);
        JsonUtility.FromJsonOverwrite(jsonData, data);
    }
}
