using System;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    float _nextShootTime;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] Transform _shootPoint;
    [SerializeField] float _delay = 0.5f;
    [SerializeField] float _bulletSpeed = 1f;


    Vector3 _direction;
    Queue<Bullet> _pool = new Queue<Bullet>();

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var raycastHit, Mathf.Infinity))
        { 
            _direction = raycastHit.point - _shootPoint.position;
            _direction.Normalize();
            _direction = new Vector3(_direction.x, 0, _direction.z);
            transform.forward = _direction;
        }

        if (CanShoot())
            Shoot();
    }

    void Shoot()
    {
        _nextShootTime = Time.time + _delay;
        var bullet = GetBullet();
        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.rotation;
        bullet.GetComponent<Rigidbody>().velocity = _direction * _bulletSpeed;
    }

    Bullet GetBullet()
    {
        if (_pool.Count > 0)
        {
            var bullet = _pool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            var bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.SetGun(this);
            return bullet;
        }
    }

    bool CanShoot()
    {
        return Time.time >= _nextShootTime;
    }

    public void AddToPool(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }
}