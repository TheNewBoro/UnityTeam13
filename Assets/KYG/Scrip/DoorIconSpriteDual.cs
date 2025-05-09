using UnityEngine;

public class DoorIconSpriteDual : MonoBehaviour
{
    public Transform player;
    public Transform worldIcon;

    [Header("������ ����")]
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

        // �׻� ī�޶� ���ϰ� (������ ȿ��)
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0;
        worldIcon.forward = -camForward.normalized;
    }
}
