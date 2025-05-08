using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // 몬스터 스폰에 관련된 프리팹
    [Header("spawn Monster Prefabs")]
    [SerializeField] private GameObject monsterPrefab;

    // 몬스터가 스폰될 수 있는 타일들의 리스트
    [Header("spawn tile")]
    [SerializeField] private List<Transform> spawnTiles;

    // 몬스터가 스폰되는 시간 간격
    [Header("spawn delay")]
    [SerializeField] private float spawnInterval = 3f;

    // 각 타일에서 몬스터를 스폰하기 위해 시도할 최대 횟수
    [Header("spawn attempt")]
    [SerializeField] private int maxAttemptsPerTile = 10;

    // 플레이어의 위치 참조
    [Header("player object")]
    [SerializeField] private Transform player;

    // 플레이어와 몬스터 사이의 최소 및 최대 거리
    [Header("spawn length")]
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 10f;

    // 스폰 타이머
    private float timer = 0f;

    void Update()
    {
        // 매 프레임마다 타이머 증가
        timer += Time.deltaTime;

        // 설정된 간격마다 몬스터 스폰
        if (timer >= spawnInterval)
        {
            SpawnMonster();
            timer = 0f; // 타이머 초기화
        }
    }

    void SpawnMonster()
    {
        // 타일이 하나도 없다면 경고 메시지 출력 후 종료
        if (spawnTiles.Count == 0)
        {
            Debug.LogWarning("스폰 가능한 타일이 없습니다.");
            return;
        }

        // 랜덤한 타일 선택
        Transform tile = spawnTiles[Random.Range(0, spawnTiles.Count)];
        Collider tileCollider = tile.GetComponent<Collider>();

        // 선택된 타일에 Collider가 없다면 경고 출력 후 종료
        if (tileCollider == null)
        {
            Debug.LogWarning($"Tile '{tile.name}'에 Collider가 없습니다.");
            return;
        }

        // 타일의 경계 정보 획득
        Bounds bounds = tileCollider.bounds;

        // 지정된 횟수만큼 랜덤 위치를 시도
        for (int i = 0; i < maxAttemptsPerTile; i++)
        {
            // 타일 경계 내 임의의 위치 획득
            Vector3 randomPos = GetRandomPositionInBounds(bounds);

            // 해당 위치와 플레이어 간 거리 계산
            float distanceToPlayer = Vector3.Distance(player.position, randomPos);

            // 거리가 너무 가깝거나 너무 멀면 다음 시도로 넘어감
            if (distanceToPlayer < minSpawnDistance || distanceToPlayer > maxSpawnDistance)
                continue;

            // 위에서 아래로 레이캐스트하여 실제 위치 확인
            if (Physics.Raycast(randomPos + Vector3.up * 5f, Vector3.down, out RaycastHit hit, 10f))
            {
                // 해당 위치가 현재 타일 위인지 확인
                if (hit.collider.transform == tile)
                {
                    // 몬스터 스폰
                    Instantiate(monsterPrefab, hit.point, Quaternion.identity);
                    return; // 스폰 완료 후 종료
                }
            }
        }

        // 모든 시도 실패 시 경고 메시지 출력
        Debug.LogWarning($"'{tile.name}' 타일에서 유효한 위치를 찾지 못했습니다.");
    }

    // 주어진 타일 경계 내에서 임의의 위치 반환
    Vector3 GetRandomPositionInBounds(Bounds bounds)
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.max.y + 1f; // 위에서 레이캐스트 하기 위해 약간 위로 위치시킴
        return new Vector3(x, y, z);
    }


}
