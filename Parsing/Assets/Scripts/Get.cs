using UnityEngine;
using System.IO;
using TMPro;
public class Get : MonoBehaviour
{
    private TextMeshProUGUI textData;
    private void Awake() // ���� �� Json �����Ϳ��� ���� �ҷ��� text�� ���
    {
        textData = GetComponent<TextMeshProUGUI>();

        string path = Path.Combine(Application.dataPath, "PlayData.json");
        string jsonData = File.ReadAllText(path);

        textData.text = jsonData;

    }
}
