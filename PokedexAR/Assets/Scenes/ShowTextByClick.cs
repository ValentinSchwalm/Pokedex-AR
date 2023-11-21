using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextByClick : MonoBehaviour
{
    public GameObject canvas; // Referenz zum canvas

    void Start()
    {
        canvas.SetActive(false); // Versteckt das canvas beim Start
    }

    void OnMouseDown()
    {
        canvas.SetActive(!canvas.activeSelf); // Schaltet das canvas bei jedem Klick um
    }
}
