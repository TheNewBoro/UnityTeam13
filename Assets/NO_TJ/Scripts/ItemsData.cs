using UnityEngine;

public class ItemsData : MonoBehaviour
{   /* 당근을 먹으면 캐릭터가 커지고 실드가 생김
     * 실드 체력은 1 실드는 최대 2개
     * 
     */
    public GameObject ShieldPrefab;  // 실드 프리팹
    public Transform Player; //실드 생성 위치

    int maxShield = 2; // 실드는 최대 2개
    private int currentShield = 0; // 현재 실드 0개

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 먹을 오브젝트에 Player 태그 작성
        {
            GenerateShield();
            Destroy(other.gameObject);
        }
    }
    private void GenerateShield()
    {
        GameObject shield = Instantiate(ShieldPrefab, Player.position, Player.rotation);
    }

    public void AddShield()
    {
        if (currentShield < maxShield)
        {
            currentShield++; // TODO 실드 오브젝트 추가
        }
    }
    public void TakeDamage()
    {
        if (currentShield > 0)
        {
            currentShield--;
        }
        else
        {
            Destroy(ShieldPrefab);
        }
    }
}
