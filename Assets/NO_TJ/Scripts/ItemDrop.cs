using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public float dropRate = 0.1f; // 드롭 확률 
    public GameObject itemPrefab; // 드롭할 아이템 프리팹
    [SerializeField] private float MonsterHP = 1;

    private void Update()
    {
        MonsterDie();
    }
    private void MonsterDie()
    {
        if (MonsterHP <= 0)
        {
            Debug.Log("몬스터 사망으로 삭제");
            Destroy(gameObject);
            DropItem();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("불릿 충돌로 몬스터 체력 감소");
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
