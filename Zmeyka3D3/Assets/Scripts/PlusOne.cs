using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlusOne : MonoBehaviour
{
    
    public Canvas MyGUI;
    public TextMeshProUGUI TextPlusOne;    
    TextMeshProUGUI ShowTextPlusOne;
    public Transform metka;
    public Camera MyCamera;

    void OnTriggerStay (Collider col) // +1
    {
        if(col.tag == "Bot")
        
        {
            ShowTextPlusOne = (TextMeshProUGUI)Instantiate(TextPlusOne);
            ShowTextPlusOne.transform.SetParent(MyGUI.transform, true);
            Vector3 screenPos = MyCamera.WorldToScreenPoint(metka.position);
            ShowTextPlusOne.transform.position = screenPos;
        }
    }
    
}






