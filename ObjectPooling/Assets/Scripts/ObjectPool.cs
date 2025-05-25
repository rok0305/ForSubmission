using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> platforms; // 리스트
    [SerializeField]
    private GameObject platformPrefab; // 대상 오브젝트
    [SerializeField]
    private Transform spawnPoint; // 오브젝트 최소 생성 위치

    private int index = 0; // 리스트 인덱스
    private float spawnCooltime = 0; // 대기시간
    private float spawnCooltimeMax = 1.25f; // 생성 (활성화) 간 시간

    private void Awake()
    {
        platforms = new List<GameObject>(); // 오브젝트 관리 리스트

        PlatformInstantiate(); // 새로운 오브젝트 생성
        /*for (int i = 0; i < 10; i++)
        {
            platforms[i] = Instantiate(platformPrefab, spawnPoint.position, Quaternion.identity);
            platforms[i].transform.parent = gameObject.transform;
            platforms[i].SetActive(false);
        }*/
    }

    private void Update()
    {
        if (spawnCooltime < 0) // 대기시간이 다 지나면 밑의 코드 실행
        {
            while (platforms[index].activeSelf == true)
            {
                index++;
                if (index >= platforms.Count) // 리스트의 끝까지 검사해도 모두 활성화 되어 있을 시 새로운 오브젝트 생성 및 반복문 탈출
                {
                    PlatformInstantiate();
                    break;
                }
            }

            platforms[index].SetActive(true); // 해당 순서의 오브젝트 활성화
            spawnCooltime = spawnCooltimeMax; // 활성화 대기시간 초기화

            index++;
            if(index >= platforms.Count) // List의 범위를 넘어갈 시 첫 번째 인덱스로
            {
                index = 0;
            }

        }

        spawnCooltime -= Time.deltaTime; // 대기 시간 검사
    }
    
    private void PlatformInstantiate()
    {
        GameObject platform = Instantiate(platformPrefab, spawnPoint.position, Quaternion.identity); // 오브젝트 인스턴스화
        platform.SetActive(false); // 비활성화
        platforms.Add(platform); // 리스트에 추가
    }
}
