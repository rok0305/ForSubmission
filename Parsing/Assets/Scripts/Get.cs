using UnityEngine;
using System.IO;
using TMPro;
public class Get : MonoBehaviour
{
    private TextMeshProUGUI textData;
    private void Awake() // 실행 시 Json 데이터에서 값을 불러와 text로 출력
    {
        textData = GetComponent<TextMeshProUGUI>();

        string path = Path.Combine(Application.dataPath, "PlayData.json");
        string jsonData = File.ReadAllText(path);

        textData.text = jsonData;

    }
}
