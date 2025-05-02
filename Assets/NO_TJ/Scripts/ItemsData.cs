using UnityEngine;

public class ItemsData : MonoBehaviour
{   /* 당근을 먹으면 캐릭터가 커지고 실드가 생김
     */
    public GameObject ShieldPrefab;  // 실드 프리팹
    public Transform Player; //실드 생성 위치

    int maxShield = 1; // 실드는 최대 1개
    private int shieldHealth = 0; // 현재 실드 0개

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) // 플레이어가 먹을 오브젝트에 Item 태그 작성
        {
            if (shieldHealth == 0)
            { 
                GenerateShield(); 
            }
            Destroy(other.gameObject);
        }
    }
    private void GenerateShield()
    {
        GameObject shield = Instantiate(ShieldPrefab, Player.position, Player.rotation);
        shield.transform.parent = Player.transform;
    }

    public void AddShield()
    {
        if (shieldHealth < maxShield)
        {
            shieldHealth++; // TODO 실드 오브젝트 추가
        }
    }
     public void TakeDamage(int damage)
     {
         shieldHealth -= damage;
         if (shieldHealth <= 0)
         {
             gameObject.SetActive(false); // 실드 비활성화
         }
     }
}
