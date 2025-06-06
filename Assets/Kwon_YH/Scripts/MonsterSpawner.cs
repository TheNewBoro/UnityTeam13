using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("spawn Monster Prefabs")]
    [SerializeField] private GameObject monsterPrefab;

    [Header("spawn tile")]
    [SerializeField] private List<Transform> spawnTiles;

    [Header("spawn delay")]
    [SerializeField] private float spawnInterval = 3f;

    [Header("spawn attempt")]
    [SerializeField] private int maxAttemptsPerTile = 10;

    [Header("player object")]
    [SerializeField] private Transform player;

    [Header("spawn length")]
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
            Debug.LogWarning("스폰 가능한 타일이 없습니다.");
            return;
        }

        Transform tile = spawnTiles[Random.Range(0, spawnTiles.Count)];
        Collider tileCollider = tile.GetComponent<Collider>();

        if (tileCollider == null)
        {
            Debug.LogWarning($"Tile '{tile.name}'에 Collider가 없습니다.");
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

        Debug.LogWarning($"'{tile.name}' 타일에서 유효한 위치를 찾지 못했습니다.");
    }

    Vector3 GetRandomPositionInBounds(Bounds bounds)
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.max.y + 1f;
        return new Vector3(x, y, z);
    }

}
