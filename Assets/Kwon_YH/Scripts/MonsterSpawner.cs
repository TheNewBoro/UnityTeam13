using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("������ ���� ������")]
    [SerializeField] private GameObject monsterPrefab;

    [Header("���� ������ Tile ������Ʈ��")]
    [SerializeField] private List<Transform> spawnTiles;

    [Header("���� ���� (��)")]
    [SerializeField] private float spawnInterval = 3f;

    [Header("�� Ÿ�� �� ���� �õ� �ִ� Ƚ��")]
    [SerializeField] private int maxAttemptsPerTile = 10;

    [Header("�÷��̾� ������Ʈ")]
    [SerializeField] private Transform player;

    [Header("���� �Ÿ� ���� (���� ����)")]
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 10f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMonster();
            timer = 0f;
        }
    }

    void SpawnMonster()
    {
        if (spawnTiles.Count == 0)
        {
            Debug.LogWarning("���� ������ Ÿ���� �����ϴ�.");
            return;
        }

        Transform tile = spawnTiles[Random.Range(0, spawnTiles.Count)];
        Collider tileCollider = tile.GetComponent<Collider>();

        if (tileCollider == null)
        {
            Debug.LogWarning($"Tile '{tile.name}'�� Collider�� �����ϴ�.");
            return;
        }

        Bounds bounds = tileCollider.bounds;

        for (int i = 0; i < maxAttemptsPerTile; i++)
        {
            Vector3 randomPos = GetRandomPositionInBounds(bounds);

            float distanceToPlayer = Vector3.Distance(player.position, randomPos);

            if (distanceToPlayer < minSpawnDistance || distanceToPlayer > maxSpawnDistance)
                continue;

            if (Physics.Raycast(randomPos + Vector3.up * 5f, Vector3.down, out RaycastHit hit, 10f))
            {
                if (hit.collider.transform == tile)
                {
                    Instantiate(monsterPrefab, hit.point, Quaternion.identity);
                    return;
                }
            }
        }

        Debug.LogWarning($"'{tile.name}' Ÿ�Ͽ��� ��ȿ�� ��ġ�� ã�� ���߽��ϴ�.");
    }

    Vector3 GetRandomPositionInBounds(Bounds bounds)
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.max.y + 1f;
        return new Vector3(x, y, z);
    }

}
