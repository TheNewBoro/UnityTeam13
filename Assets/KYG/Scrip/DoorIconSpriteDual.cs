using UnityEngine;

public class DoorIconSpriteDual : MonoBehaviour
{
    public Transform player;
    public Transform worldIcon;

    [Header("스케일 제어")]
    public float minDistance = 5f;
    public float maxDistance = 30f;
    public float minScale = 0.5f;
    public float maxScale = 1.3f;

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        float t = Mathf.InverseLerp(maxDistance, minDistance, dist);
        float scale = Mathf.Lerp(minScale, maxScale, t);

        worldIcon.localScale = new Vector3(scale, scale, scale);

        // 항상 카메라를 향하게 (빌보드 효과)
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0;
        worldIcon.forward = -camForward.normalized;
    }
}
