using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomControl : MonoBehaviour
{
    public void Setup()
    {
        //time chibi destroy
        Invoke("destroyBom", 8f);
    }

    void destroyBom()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 2f * Time.deltaTime);
    }
}
