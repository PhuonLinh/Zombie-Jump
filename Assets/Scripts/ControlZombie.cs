using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlZombie : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] bool _isonGround = false;
    [SerializeField] Vector2 _force;

    public GameObject zombiePrefab;
    public GameObject chibiPrefab;
    public float destroyDelay = 2f; // Thời gian chờ trước khi hủy bỏ chibi cũ

    Rigidbody2D _rigi;
    Collider2D _colli;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _colli = GetComponent<Collider2D>();

        /*// Load the score from PlayerPrefs
        score = PlayerPrefs.GetInt(ScoreKey, 0);

        UpdateScoreText();*/
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        Vector2 _moverment = Vector2.zero;
        _moverment.x = Input.GetAxisRaw("Horizontal")* _speed;
        _moverment.y = _rigi.velocity.y;

        _rigi.velocity = _moverment;

        if (_rigi.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        
        if(Input.GetKey(KeyCode.Space) && _isonGround)
        {
            _rigi.AddForce(_force);
            _isonGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            _isonGround = true;
        }
    }
    //----------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            //xu ly va cham nguoi choi
            Debug.Log("Zombie an nguoi choi");

           /* // Hủy bỏ đối tượng người chơi
            Destroy(collision.gameObject);

            // Nhân bản zombie
            GameObject newZombie = Instantiate(ZombiePrefab, transform.position, Quaternion.identity);
            // Thực hiện bất kỳ xử lý nào cho zombie mới tại đây

            // Ví dụ: Thiết lập tốc độ của zombie mới
            ControlZombie newZombieScript = newZombie.GetComponent<ControlZombie>();
            newZombieScript._speed = Random.Range(3f, 7f);

            //xu ly diem so khi va cham
            Debug.Log("Zombie cham nguoi choi de cong diem");
            // Xử lý va chạm với đối tượng người chơi
            IncreaseScore(10); // Tăng điểm số lên 10*/
            //--------------------------------------
            /*// Sinh nhân bản zombie mới
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);*/

            // Sinh nhân bản chibi mới sau một khoảng thời gian
            StartCoroutine(SpawnNewChibi());

            // Hủy bỏ chibi cũ sau một khoảng thời gian
            Destroy(collision.gameObject, destroyDelay);
        }
    }

    private IEnumerator SpawnNewChibi()
    {
        /*Vector3 randomSpawnPosition = new Vector3(Random.Range(maxX, maxX + 2f), Random.Range(minY, maxY), 0);
        GameObject newChibi = Instantiate(chibiPrefab, randomSpawnPosition, Quaternion.identity);
*/
        // Di chuyển chibi mới sang trái
        while (chibiPrefab.transform.position.x > minX)
        {
            chibiPrefab.transform.Translate(Vector3.left * _speed * Time.deltaTime);
            yield return null;
        }


        // Hủy chibi mới
        Destroy(chibiPrefab);

        // Tạm dừng trước khi hủy chibi mới

        yield return new WaitForSeconds(destroyDelay);

        // Sinh nhân bản chibi mới
        Instantiate(chibiPrefab, transform.position, Quaternion.identity);
    }
    //----------------------------------------------------------------------------
    /*private void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log(score);
        UpdateScoreText();

        // Save the updated score to PlayerPrefs
        PlayerPrefs.SetInt(ScoreKey, score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        Debug.Log(scoreText.text);
    }*/

}
