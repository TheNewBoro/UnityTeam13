using UnityEngine;

public class ItemsData : MonoBehaviour
{   /* 당근을 먹으면 캐릭터가 커지고 실드가 생김
     */
    public GameObject shieldPrefab; // 실드 프리팹
    private GameObject currentShield; // 현재 실드 개수
    private int shieldHealth = 0; // 실드 개수

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            GetItem(other.gameObject);
        }
        else if (other.CompareTag("EnemyAttack"))
        {
            if (shieldHealth > 0)
            {
                DestroyShield();
            }           
        }
    }
    void GetItem(GameObject item)
    {
        Destroy(item);
        if (shieldHealth == 0)
        {
            CreateShield();
        }
        else
        {
            // 이미 실드가 있으면 추가 생성하지 않음
        }
    }

    void CreateShield()
    {
        if (currentShield == null)
        {
            currentShield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            currentShield.transform.SetParent(transform); // 플레이어와 함께 움직이게 함
            shieldHealth = 1;
        }
       
    }
    void DestroyShield()
    {
        if (currentShield != null)
        {
            Destroy(currentShield);
            currentShield = null;
            shieldHealth = 0;
        }
    }
}
