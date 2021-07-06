using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointBullet;

    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _vec;
     
    private void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        LookMouse();
        CreatBullet();
        Move();

        //_vec = _camera.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log(_vec.normalized);
    }

    private void LookMouse()
    {
        Vector3 screenMousePostion = Input.mousePosition;
        transform.right = Vector2.Lerp(transform.right, (_camera.ScreenToWorldPoint(screenMousePostion) - transform.position), 0.1f);
    }

    private void CreatBullet()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullets = Instantiate(bullet, pointBullet.position, Quaternion.identity);
            Destroy(bullets, 10f);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _vec = _camera.ScreenToWorldPoint(Input.mousePosition);
            _rb.velocity = Vector2.MoveTowards(transform.position, _vec, _speed);
        }
    }
}
