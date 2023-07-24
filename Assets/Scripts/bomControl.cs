using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomControl : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
    }
}
