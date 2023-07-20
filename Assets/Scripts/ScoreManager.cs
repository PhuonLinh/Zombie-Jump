﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;
	public int score;
	public Text scoreText;

	public int count;
	public Text countText;

	public GameObject ZombiePrefab;

	void Awake()
	{
		makeInstance();
	}

	void Start()
	{
        // Load the score from PlayerPrefs

		IncrementScore();
		IncrementCount();
    }

	public void makeInstance()
	{
		if (instance == null)
			instance = this;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
			score += 10;
			count++;
			//xu ly va cham nguoi choi
			Debug.Log("Zombie an nguoi choi");

			// Nhân bản zombie
			GameObject newZombie = Instantiate(ZombiePrefab, transform.position, Quaternion.identity);

			// Hủy bỏ đối tượng người chơi
			Destroy(collision.gameObject);
		}

        if (collision.CompareTag("bom"))
        {
			count--;
            Debug.Log("zombie cham bom");
            IncrementCount(); // Cập nhật giá trị count sau khi giảm
            Destroy(gameObject);
			
		}

    }
	// display score
    public void IncrementScore()
	{
		scoreText.text = "Score: " + score;
	}

	public int GetScore()
	{
		return this.score;
	}

	//display count
	public void IncrementCount()
	{
		countText.text = "Zombie: " + count.ToString();
	}

	public int GetCount()
	{
		return this.count;
	}

	public void GetHighScore()
	{
		PlayerPrefs.SetInt("score", score);
		if (PlayerPrefs.HasKey("highScore"))
		{
			if (score > PlayerPrefs.GetInt("highScore"))
			{
				PlayerPrefs.SetInt("highScore", score);

			}
		}
		else
		{
			PlayerPrefs.SetInt("highScore", score);
		}
	}
}