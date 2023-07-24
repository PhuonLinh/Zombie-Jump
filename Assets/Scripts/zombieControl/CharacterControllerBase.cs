using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerBase : MonoBehaviour
{
    protected float minX=-9.9f;
    protected float maxX=9f;
    protected float minY=-2.53f;
    protected float maxY=1.6f;
    protected float moveSpeed=2f;
    /*public float spawnDelay = 2f; // Thời gian chờ giữa mỗi lần sinh nhân bản*/
    public ChibiControl chibiPrefab;
    public bomControl Bomb;
    /*protected bool isSpawningChibi = false;*/

    protected virtual void Start()
    {
        //StartSpawningChibi();
    }

    float timeInstantiate = 9f;
    float timeStart;
    private void Update()
    {
        if (Time.time - timeStart > timeInstantiate)
        {
            timeStart = Time.time;
            //Todo

            InstantiateChibi();
            InstantiateBom();
        }
    }

    void InstantiateChibi()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(maxX, maxX + 2f), Random.Range(minY, maxY), 0);
        ChibiControl newChibi = Instantiate(chibiPrefab, randomSpawnPosition, Quaternion.identity);
        newChibi.Setup();
    }

    void InstantiateBom()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(maxX+4f, maxX +7f), Random.Range(minY, maxY), 0);
        bomControl newBomb = Instantiate(Bomb, randomSpawnPosition, Quaternion.identity);
    }
    //protected virtual void StartSpawningChibi()
    //{
    //    while (!isSpawningChibi)
    //    {
    //        isSpawningChibi = true;
    //        StartCoroutine(SpawnChibiLoop());
    //    }
    //}

    //protected IEnumerator SpawnChibiLoop()
    //{
    //    while (true)
    //    {
    //        // Sinh nhân bản chibi mới với vị trí ngẫu nhiên
    //        Vector3 randomSpawnPosition = new Vector3(Random.Range(maxX, maxX + 2f), Random.Range(minY, maxY), 0);
    //        GameObject newChibi = Instantiate(chibiPrefab, randomSpawnPosition, Quaternion.identity);

    //        // Di chuyển chibi mới sang trái
    //        while (newChibi != null && newChibi.transform.position.x > minX)
    //        {
    //            newChibi.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    //            yield return null;
    //        }

    //        if (newChibi != null)
    //        {
    //            // Hủy chibi mới
    //            Destroy(newChibi);
    //        }


    //        // Tạm dừng trước khi hủy chibi mới
    //        yield return new WaitForSeconds(spawnDelay);

    //        // Coroutine đã hoàn thành, cho phép gọi lại
    //        isSpawningChibi = false;
    //    }
    //}
}
