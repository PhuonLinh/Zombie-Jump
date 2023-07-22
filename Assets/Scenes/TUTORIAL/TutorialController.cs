using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] GameObject btnComment00,btnComment01;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickButtonNext()
    {
        btnComment00.SetActive(false);
        btnComment01.SetActive(true);

    }
}
