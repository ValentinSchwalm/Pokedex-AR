using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeBall : MonoBehaviour
{
    private float time;
    private bool thrown = false;
    private Vector3 originalPosition;
    public Vector3 finalPosition;
    
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject pokeBall;
    [SerializeField] private Rigidbody pokeBallBody;
    [SerializeField] private GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3 && thrown)
        {
            ResetPos();
        }
        
    }

    public void Throw()
    {
        Debug.Log("throw");
        originalPosition = pokeBallBody.position;
        pokeBallBody.useGravity = true;
        pokeBallBody.velocity = new Vector3(0, 2, 5);
        time = 0;    
        thrown = true;
        button.SetActive(false);
    }

    public void ResetPos()
    {
        thrown = false;
        Debug.Log("didn't spawn");
        Debug.Log(originalPosition);
        pokeBallBody.useGravity = false;
        pokeBallBody.position = originalPosition;
        button.SetActive(true);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Destroy(pokeBall);
            Debug.Log("Destroyed");
            RaycastHit raycastHit;
            Physics.Raycast(pokeBallBody.position, Vector3.down, out raycastHit, 10, layerMask);
            finalPosition = raycastHit.point;
        }
    }
}
