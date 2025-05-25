using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> platforms; // ����Ʈ
    [SerializeField]
    private GameObject platformPrefab; // ��� ������Ʈ
    [SerializeField]
    private Transform spawnPoint; // ������Ʈ �ּ� ���� ��ġ

    private int index = 0; // ����Ʈ �ε���
    private float spawnCooltime = 0; // ���ð�
    private float spawnCooltimeMax = 1.25f; // ���� (Ȱ��ȭ) �� �ð�

    private void Awake()
    {
        platforms = new List<GameObject>(); // ������Ʈ ���� ����Ʈ

        PlatformInstantiate(); // ���ο� ������Ʈ ����
        /*for (int i = 0; i < 10; i++)
        {
            platforms[i] = Instantiate(platformPrefab, spawnPoint.position, Quaternion.identity);
            platforms[i].transform.parent = gameObject.transform;
            platforms[i].SetActive(false);
        }*/
    }

    private void Update()
    {
        if (spawnCooltime < 0) // ���ð��� �� ������ ���� �ڵ� ����
        {
            while (platforms[index].activeSelf == true)
            {
                index++;
                if (index >= platforms.Count) // ����Ʈ�� ������ �˻��ص� ��� Ȱ��ȭ �Ǿ� ���� �� ���ο� ������Ʈ ���� �� �ݺ��� Ż��
                {
                    PlatformInstantiate();
                    break;
                }
            }

            platforms[index].SetActive(true); // �ش� ������ ������Ʈ Ȱ��ȭ
            spawnCooltime = spawnCooltimeMax; // Ȱ��ȭ ���ð� �ʱ�ȭ

            index++;
            if(index >= platforms.Count) // List�� ������ �Ѿ �� ù ��° �ε�����
            {
                index = 0;
            }

        }

        spawnCooltime -= Time.deltaTime; // ��� �ð� �˻�
    }
    
    private void PlatformInstantiate()
    {
        GameObject platform = Instantiate(platformPrefab, spawnPoint.position, Quaternion.identity); // ������Ʈ �ν��Ͻ�ȭ
        platform.SetActive(false); // ��Ȱ��ȭ
        platforms.Add(platform); // ����Ʈ�� �߰�
    }
}
