using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] bool _isonGround = false;
    [SerializeField] Vector2 _force;
    

    /*[SerializeField] GameObject zombiePrefab;*/
    /*public float destroyDelay = 2f; // Thời gian chờ trước khi hủy bỏ chibi cũ*/

    Rigidbody2D _rigi;
    Collider2D _colli;


    public void Start()
    {
        /*base.Start();*/
        _rigi = GetComponent<Rigidbody2D>();
        _colli = GetComponent<Collider2D>();

        /*// Load the score from PlayerPrefs
        score = PlayerPrefs.GetInt(ScoreKey, 0);

        UpdateScoreText();*/
    }


    /*protected override void StartSpawningChibi()
    {
        base.StartSpawningChibi();
    }*/

    /*protected new IEnumerator SpawnChibiLoop()
    {
        Debug.Log("Chibi cua controlZombie");
        return base.SpawnChibiLoop();
    }*/

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        Vector2 _moverment = Vector2.zero;
        _moverment.x = Input.GetAxisRaw("Horizontal") * _speed;
        _moverment.y = _rigi.velocity.y;

        _rigi.velocity = _moverment;

        /*if (_rigi.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }*/

        if (Input.GetKey(KeyCode.Space) && _isonGround)
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
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            //xu ly va cham nguoi choi
            Debug.Log("Zombie an nguoi choi");

            // Sinh nhân bản chibi mới sau một khoảng thời gian
            StartCoroutine(SpawnChibiLoop());

           
        }
    }*/

}


