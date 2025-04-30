using UnityEngine;

public class ItemsData : MonoBehaviour
{   /* ����� ������ ĳ���Ͱ� Ŀ���� �ǵ尡 ����
     * �ǵ� ü���� 1 �ǵ�� �ִ� 2��
     * 
     */
    public GameObject ShieldPrefab;  // �ǵ� ������
    public Transform Player; //�ǵ� ���� ��ġ

    int maxShield = 2; // �ǵ�� �ִ� 2��
    private int currentShield = 0; // ���� �ǵ� 0��

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ ���� ������Ʈ�� Player �±� �ۼ�
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
            currentShield++; // TODO �ǵ� ������Ʈ �߰�
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
