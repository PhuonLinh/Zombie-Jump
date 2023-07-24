using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] GameObject btnComment00,btnComment01;
    [SerializeField] Text text00;
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
        bool isText00 = text00.enabled;
        btnComment00.SetActive(false);
        btnComment01.SetActive(true);
        text00.enabled = !isText00;
    }
}
