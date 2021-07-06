using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject _asteroid;
    [SerializeField] private GameObject _player;
    [SerializeField] private float speed;

    private void Update()
    {
        Vector2 pla = _player.transform.position;
        Vector2 asr = _asteroid.transform.position;

        var dir = (_player.transform.position - transform.position).normalized;
        _asteroid.GetComponent<Rigidbody2D>().velocity = dir * speed * Time.deltaTime;

    }
}
