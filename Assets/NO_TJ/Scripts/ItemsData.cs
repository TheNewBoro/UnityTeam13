using UnityEngine;

public class ItemsData : MonoBehaviour
{   /* ����� ������ ĳ���Ͱ� Ŀ���� �ǵ尡 ����
     */
    public GameObject shieldPrefab; // �ǵ� ������
    private GameObject currentShield; // ���� �ǵ� ����
    private int shieldHealth = 0; // �ǵ� ����

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
            // �̹� �ǵ尡 ������ �߰� �������� ����
        }
    }

    void CreateShield()
    {
        if (currentShield == null)
        {
            currentShield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            currentShield.transform.SetParent(transform); // �÷��̾�� �Բ� �����̰� ��
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
