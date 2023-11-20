using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeBall : MonoBehaviour
{
    private float time;
    private bool thrown = false;
    public Vector3 finalPosition;
    
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject pokeBall;
    [SerializeField] private Rigidbody pokeBallBody;
    [SerializeField] private Transform pokeballHandle;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float throwForce;

    private string currentPokemon;

    [SerializeField] private GameObject[] pokemonModels;
    [SerializeField] private string[] pokemonNames;

    private Dictionary<string, GameObject> pokemonList;

    public string CurrentPokemon
    { 
        get { return currentPokemon; }
        set { currentPokemon = value; }
    }

    public bool Thrown
    { 
        get { return thrown; }
    }

    private void Awake()
    {
        for (int i = 0; i < pokemonNames.Length; i++)
        {
            pokemonList.Add(pokemonNames[i], pokemonModels[i]);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 3 && thrown)
        {
            ResetPos();
        }
        
        if (!thrown )
        {
            this.transform.position = pokeballHandle.position;
        }
    }

    public void Throw()
    {
        if (thrown)
        {
            return;
        }

        pokeBallBody.useGravity = true;
        // pokeBallBody.velocity = new Vector3(0, 2, 5);
        pokeBallBody.velocity = cameraTransform.forward * throwForce;
        pokeBallBody.velocity += Vector3.up * 2;
        time = 0;    
        thrown = true;
    }

    private void ResetPos()
    {
        thrown = false;
        pokeBallBody.useGravity = false;
        gameObject.SetActive(false);
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

            SpawnPokemon();
            ResetPos();
        }
    }

    private void SpawnPokemon()
    {
        Instantiate(this.pokemonList[currentPokemon], finalPosition, Quaternion.identity);
    }
}
