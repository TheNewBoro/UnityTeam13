using UnityEngine;

public class ItemsData : MonoBehaviour
{   /* ����� ������ ĳ���Ͱ� Ŀ���� �ǵ尡 ����
     */
    public GameObject ShieldPrefab;  // �ǵ� ������
    public Transform Player; //�ǵ� ���� ��ġ

    int maxShield = 1; // �ǵ�� �ִ� 1��
    private int shieldHealth = 0; // ���� �ǵ� 0��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) // �÷��̾ ���� ������Ʈ�� Item �±� �ۼ�
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
            shieldHealth++; // TODO �ǵ� ������Ʈ �߰�
        }
    }
     public void TakeDamage(int damage)
     {
         shieldHealth -= damage;
         if (shieldHealth <= 0)
         {
             gameObject.SetActive(false); // �ǵ� ��Ȱ��ȭ
         }
     }
}
