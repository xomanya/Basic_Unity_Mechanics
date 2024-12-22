using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpExample : MonoBehaviour
{
    [SerializeField] private PopUpScript _popup;

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.F))
       {
               _popup.gameObject.SetActive(true);
               _popup.Show(); 
       } 
    }
}
