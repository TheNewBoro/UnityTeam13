using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // ���� ������ ���õ� ������
    [Header("spawn Monster Prefabs")]
    [SerializeField] private GameObject monsterPrefab;

    // ���Ͱ� ������ �� �ִ� Ÿ�ϵ��� ����Ʈ
    [Header("spawn tile")]
    [SerializeField] private List<Transform> spawnTiles;

    // ���Ͱ� �����Ǵ� �ð� ����
    [Header("spawn delay")]
    [SerializeField] private float spawnInterval = 3f;

    // �� Ÿ�Ͽ��� ���͸� �����ϱ� ���� �õ��� �ִ� Ƚ��
    [Header("spawn attempt")]
    [SerializeField] private int maxAttemptsPerTile = 10;

    // �÷��̾��� ��ġ ����
    [Header("player object")]
    [SerializeField] private Transform player;

    // �÷��̾�� ���� ������ �ּ� �� �ִ� �Ÿ�
    [Header("spawn length")]
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 10f;

    // ���� Ÿ�̸�
    private float timer = 0f;

    void Update()
    {
        // �� �����Ӹ��� Ÿ�̸� ����
        timer += Time.deltaTime;

        // ������ ���ݸ��� ���� ����
        if (timer >= spawnInterval)
        {
            SpawnMonster();
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    void SpawnMonster()
    {
        // Ÿ���� �ϳ��� ���ٸ� ��� �޽��� ��� �� ����
        if (spawnTiles.Count == 0)
        {
            Debug.LogWarning("���� ������ Ÿ���� �����ϴ�.");
            return;
        }

        // ������ Ÿ�� ����
        Transform tile = spawnTiles[Random.Range(0, spawnTiles.Count)];
        Collider tileCollider = tile.GetComponent<Collider>();

        // ���õ� Ÿ�Ͽ� Collider�� ���ٸ� ��� ��� �� ����
        if (tileCollider == null)
        {
            Debug.LogWarning($"Tile '{tile.name}'�� Collider�� �����ϴ�.");
            return;
        }

        // Ÿ���� ��� ���� ȹ��
        Bounds bounds = tileCollider.bounds;

        // ������ Ƚ����ŭ ���� ��ġ�� �õ�
        for (int i = 0; i < maxAttemptsPerTile; i++)
        {
            // Ÿ�� ��� �� ������ ��ġ ȹ��
            Vector3 randomPos = GetRandomPositionInBounds(bounds);

            // �ش� ��ġ�� �÷��̾� �� �Ÿ� ���
            float distanceToPlayer = Vector3.Distance(player.position, randomPos);

            // �Ÿ��� �ʹ� �����ų� �ʹ� �ָ� ���� �õ��� �Ѿ
            if (distanceToPlayer < minSpawnDistance || distanceToPlayer > maxSpawnDistance)
                continue;

            // ������ �Ʒ��� ����ĳ��Ʈ�Ͽ� ���� ��ġ Ȯ��
            if (Physics.Raycast(randomPos + Vector3.up * 5f, Vector3.down, out RaycastHit hit, 10f))
            {
                // �ش� ��ġ�� ���� Ÿ�� ������ Ȯ��
                if (hit.collider.transform == tile)
                {
                    // ���� ����
                    Instantiate(monsterPrefab, hit.point, Quaternion.identity);
                    return; // ���� �Ϸ� �� ����
                }
            }
        }

        // ��� �õ� ���� �� ��� �޽��� ���
        Debug.LogWarning($"'{tile.name}' Ÿ�Ͽ��� ��ȿ�� ��ġ�� ã�� ���߽��ϴ�.");
    }

    // �־��� Ÿ�� ��� ������ ������ ��ġ ��ȯ
    Vector3 GetRandomPositionInBounds(Bounds bounds)
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.max.y + 1f; // ������ ����ĳ��Ʈ �ϱ� ���� �ణ ���� ��ġ��Ŵ
        return new Vector3(x, y, z);
    }


}
