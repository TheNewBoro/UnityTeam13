using UnityEngine;
using UnityEngine.UI;

public class DoorIconController : MonoBehaviour
{
    public Transform player;

    [Header("미니맵 아이콘")]
    public GameObject miniMapIcon; // 항상 표시, 따로 처리 가능

    [Header("화면 아이콘")]
    public RectTransform worldIconUI; // World-space canvas에서 Image

    [Header("스케일 조정")]
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
