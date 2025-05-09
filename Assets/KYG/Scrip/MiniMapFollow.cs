using UnityEngine;
using UnityEngine.UI;

public class DoorIconController : MonoBehaviour
{
    public Transform player;

    [Header("�̴ϸ� ������")]
    public GameObject miniMapIcon; // �׻� ǥ��, ���� ó�� ����

    [Header("ȭ�� ������")]
    public RectTransform worldIconUI; // World-space canvas���� Image

    [Header("������ ����")]
    public float minDistance = 5f;
    public float maxDistance = 30f;
    public float minScale = 0.5f;
    public float maxScale = 1.3f;

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        float t = Mathf.InverseLerp(maxDistance, minDistance, dist);
        float scale = Mathf.Lerp(minScale, maxScale, t);

        worldIconUI.localScale = new Vector3(scale, scale, 1);
    }
}
