using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSwap : MonoBehaviour
{

    [SerializeField]
    private Button button;
    [SerializeField]
    private Sprite defaultImage; 
    [SerializeField]
    private Sprite changedImage; 
    bool swaped;
    // Start is called before the first frame update
    

    void Start()
    {
        swaped = false;
        button.onClick.AddListener(taskOnClick);
    }

    // Update is called once per frame
    void taskOnClick()
    {

        if (swaped == false){
            button.GetComponent<Image>().sprite = changedImage;
            swaped = true;
        }
        else{
            button.GetComponent<Image>().sprite = defaultImage;
            swaped = false;
        }
    }
}
