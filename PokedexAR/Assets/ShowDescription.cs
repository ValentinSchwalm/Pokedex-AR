using UnityEngine;

public class ShowDescription : MonoBehaviour
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
