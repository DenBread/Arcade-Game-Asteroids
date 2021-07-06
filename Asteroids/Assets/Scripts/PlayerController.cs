using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointBullet;
    [SerializeField] private float _speedBullet;

    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    private Vector2 _vec;
     
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
    }

    /// <summary>
    /// Точка напрвления для игрока
    /// </summary>
    private void LookMouse()
    {
        Vector3 screenMousePostion = Input.mousePosition;
        transform.right = Vector2.Lerp(transform.right, (_camera.ScreenToWorldPoint(screenMousePostion) - transform.position), 0.1f);
    }

    /// <summary>
    /// Создание пули
    /// </summary>
    private void CreatBullet()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullets = Instantiate(bullet, pointBullet.position, Quaternion.identity);
            bullets.GetComponent<Rigidbody2D>().AddRelativeForce(transform.right * _speedBullet, ForceMode2D.Impulse);

            Destroy(bullets, 10f);
        }
    }

    /// <summary>
    /// Перевдижения игрока с помощью клавиши
    /// </summary>
    private void Move()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(transform.right * _speed * Time.deltaTime, ForceMode2D.Force);
        }
    }
}
