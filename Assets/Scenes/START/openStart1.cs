using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openStart1 : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("PROGRAMMER");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("TUTORIAL");
    }

    public void changllenge()
    {
        SceneManager.LoadScene("Changllenge");
    }
}


