using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _asteroid;
    [SerializeField] private GameObject _player;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 diretion;
    private float x, y;

    private void Start()
    {
        _asteroid = GetComponent<Rigidbody2D>();
        x = Random.Range(-1f, 1f);
        diretion.x = x;
        diretion.y = -x;

    }

    private void Update()
    {
        
        Vector2 pla = _player.transform.position;
        Vector2 asr = _asteroid.transform.position;

        
        _asteroid.AddForce(diretion * speed * Time.deltaTime);

        if (Vector3.Distance(_player.transform.position, transform.position) > 3)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        
        var dir = (_player.transform.position - transform.position).normalized;
        _asteroid.velocity = dir * speed * Time.deltaTime;
    }


}
