using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    public Button btnnext;
    public Text text;
    public Sprite Image;
    
    public void FlipImage(Button button)
    {
        button.GetComponent<Image>().sprite = Image;
    }
    
}
