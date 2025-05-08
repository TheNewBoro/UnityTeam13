using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public float dropRate = 0.1f; // ��� Ȯ�� 
    public GameObject itemPrefab; // ����� ������ ������
    [SerializeField] private float MonsterHP = 1;

    private void Update()
    {
        MonsterDie();
    }
    private void MonsterDie()
    {
        if (MonsterHP <= 0)
        {
            Debug.Log("���� ������� ����");
            Destroy(gameObject);
            DropItem();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("�Ҹ� �浹�� ���� ü�� ����");
            MonsterHP--;
        }
    }

    void DropItem()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.y += 1f;
        float rand = Random.Range(0f, 1f);
        if (rand <= dropRate)
        {
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
