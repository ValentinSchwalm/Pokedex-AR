using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextByClick : MonoBehaviour
{
    private Camera camera;
    public GameObject canvas; // Referenz zum canvas

    void Start()
    {
        camera = FindObjectOfType<Camera>();
        Vector3 direction = camera.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
        canvas.SetActive(false); // Versteckt das canvas beim Start
    }

    void OnMouseDown()
    {
        canvas.SetActive(!canvas.activeSelf); // Schaltet das canvas bei jedem Klick um
    }
}
