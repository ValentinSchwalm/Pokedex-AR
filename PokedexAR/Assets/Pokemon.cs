using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    [SerializeField] private string pokeName;

    public string PokeName
    {
        get { return pokeName; }
    }
}
