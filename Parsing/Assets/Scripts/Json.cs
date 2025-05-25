using System.Collections;
using System.Collections.Generic;
//using static UnityEngine.JsonUtility;
using UnityEngine;
using System.IO;

public class Json : MonoBehaviour
{
    //[SerializeField]
    public DataTable data; // 데이터 테이블 형식
    [ContextMenu("To Json Data")] // 유니티에 메뉴창 추가
    void SavePlayerDataToJson() // Json 데이터에 데이터 저장
    {
        string jsonData = JsonUtility.ToJson(data, true); 
        string path = Path.Combine(Application.dataPath, "playerData.json"); 
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("Form Json Data")]
    void LoadPlayerDataToJson() // Json 데이터 불러오기
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        //data = JsonUtility.FromJson<DataTable>(jsonData);
        JsonUtility.FromJsonOverwrite(jsonData, data);
    }
}
