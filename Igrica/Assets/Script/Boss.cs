using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject _hitPrefab;
    [SerializeField] GameObject _explosionPrefab;
    [SerializeField] int _health = 50;
    [SerializeField] GameObject _endScreen;

    int _currentHealth;

    void OnEnable()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(Vector3 impactPoint)
    {
        _currentHealth--;
        Instantiate(_hitPrefab, transform.position, transform.rotation);

        if (_currentHealth == 0)
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
            _endScreen.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
