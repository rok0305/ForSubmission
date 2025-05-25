using UnityEngine;

public class Platform : MonoBehaviour
{
    private int spawnPositionIndex; // 생성 위치 확인
    [SerializeField]
    private Transform[] spawnposition; // 생성 가능 위치
    [SerializeField]
    private float moveSpeed = 4; // 이동 속도

    private void OnEnable()
    {
        spawnPositionIndex = Random.Range(0, 3); // 랜덤 위치에 위치
        transform.position = spawnposition[spawnPositionIndex].position; // 저장된 위치로 위치
    }
    private void Update()
    {
        transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0); // moveSpeed에 따라 밑으로 이동
        if(transform.position.y < -12) // 일정 구간 이상 내려가면 비활성화
        {
            gameObject.SetActive(false); 
        }
    }
    private void OnDisable() // 비활성화 시 위치 초기화
    {
        transform.position = new Vector3(0, 12, 0);
    }

}
