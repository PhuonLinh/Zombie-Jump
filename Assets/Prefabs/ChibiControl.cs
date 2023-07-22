using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChibiControl : MonoBehaviour
{
    public void Setup()
    {
        Invoke("destroyChibi", 5f);
    }

    void destroyChibi()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 2f * Time.deltaTime);
    }
}
