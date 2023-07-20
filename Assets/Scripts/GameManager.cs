using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float moveSpeed;
    public float spawnDelay; // Thời gian chờ giữa mỗi lần sinh nhân bản
    public GameObject chibiPrefab;
    private bool isSpawningChibi = false;

    /*private Coroutine disappearCoroutine;
    
    private void Start()
    {
        StartMoving();
    }

    private void StartMoving()
    {
        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        // Lặp lại cho đến khi chibi đi qua khu vực minX
        while (transform.position.x > minX)
        {
            // Di chuyển chibi sang trái
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Tạm dừng trong một khoảng thời gian
        yield return new WaitForSeconds(2f);

        // Lưu tham chiếu đối tượng chibi cũ
        GameObject oldChibi = gameObject;

        // Lưu vị trí của chibi cũ
        Vector3 oldPosition = transform.position;

        // Biến mất chibi
        Destroy(oldChibi);

       
        // Sinh nhân bản chibi mới với vị trí ngẫu nhiên
        Vector3 randomSpawnPosition = new Vector3(Random.Range(maxX, maxX + 2f), Random.Range(minY, maxY), 0);
        Instantiate(chibiPrefab, randomSpawnPosition, Quaternion.identity);

    }*/

    private void Start()
    {
        StartSpawningChibi();
    }

    private void StartSpawningChibi()
    {
        while (!isSpawningChibi)
        {
            isSpawningChibi = true;
            StartCoroutine(SpawnChibiLoop());
        }
    }

    private IEnumerator SpawnChibiLoop()
    {
        while (true)
        {
            // Sinh nhân bản chibi mới với vị trí ngẫu nhiên
            Vector3 randomSpawnPosition = new Vector3(Random.Range(maxX, maxX + 2f), Random.Range(minY, maxY), 0);
            GameObject newChibi = Instantiate(chibiPrefab, randomSpawnPosition, Quaternion.identity);

            // Di chuyển chibi mới sang trái
            while (newChibi.transform.position.x > minX)
            {
                newChibi.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Hủy chibi mới
            Destroy(newChibi);

            // Tạm dừng trước khi hủy chibi mới
            yield return new WaitForSeconds(spawnDelay);

            // Coroutine đã hoàn thành, cho phép gọi lại
            isSpawningChibi = false;
        }
    }
}
