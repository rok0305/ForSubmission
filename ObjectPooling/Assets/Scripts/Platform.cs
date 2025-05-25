using UnityEngine;

public class Platform : MonoBehaviour
{
    private int spawnPositionIndex; // ���� ��ġ Ȯ��
    [SerializeField]
    private Transform[] spawnposition; // ���� ���� ��ġ
    [SerializeField]
    private float moveSpeed = 4; // �̵� �ӵ�

    private void OnEnable()
    {
        spawnPositionIndex = Random.Range(0, 3); // ���� ��ġ�� ��ġ
        transform.position = spawnposition[spawnPositionIndex].position; // ����� ��ġ�� ��ġ
    }
    private void Update()
    {
        transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0); // moveSpeed�� ���� ������ �̵�
        if(transform.position.y < -12) // ���� ���� �̻� �������� ��Ȱ��ȭ
        {
            gameObject.SetActive(false); 
        }
    }
    private void OnDisable() // ��Ȱ��ȭ �� ��ġ �ʱ�ȭ
    {
        transform.position = new Vector3(0, 12, 0);
    }

}
