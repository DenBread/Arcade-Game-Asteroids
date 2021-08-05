using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AsteroidData", menuName = "Asteroid Data", order = 51)]
public class AsteroidData : ScriptableObject
{
    [SerializeField] private GameObject _asteroid;
}
