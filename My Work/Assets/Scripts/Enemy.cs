using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 1;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private SpriteRenderer _healthBar;
    [SerializeField] private SpriteRenderer _healthFill;

    private int _currentHealth;

    public Vector3 TargetPosition { get; private set; }
    public int CurrentPathIndex { get; private set; }

    private int dir;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
        _healthFill.size = _healthBar.size;
        dir = 3;
    }

    public void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, _moveSpeed * Time.deltaTime);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        TargetPosition = targetPosition;
        _healthBar.transform.parent = null;

        Vector3 distance = TargetPosition - transform.position;
        if (Mathf.Abs(distance.y) > Mathf.Abs(distance.x))
        {
            if (distance.y > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3 (0f, 0f, 90f));
                dir = 0;
            }

            else
            {
                transform.rotation = Quaternion.Euler(new Vector3 (0f, 0f, -90f));
                dir = 2;
            }
        }
        else
        {
            if (distance.x > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3 (0f, 0f, 0f));
                dir = 3;
            }

            else
            {
                transform.rotation = Quaternion.Euler(new Vector3 (0f, 0f, 180f));
                dir = 1;
            }
        }
        _healthBar.transform.parent = transform;
    }

    public void SetCurrentPathIndex(int currentIndex)
    {
        CurrentPathIndex = currentIndex;
    }

    public void ReduceEnemyHealth(int damage)
    {
        _currentHealth -= damage;
        AudioPlayer.Instance.PlaySFX ("hit-enemy");

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            gameObject.SetActive (false);
            AudioPlayer.Instance.PlaySFX ("enemy-die");
            MoneyManager.money += 2;
        }

        float healthPercentage = (float) _currentHealth / _maxHealth;
        _healthFill.size = new Vector2 (healthPercentage * _healthBar.size.x, _healthBar.size.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WindBullet"))
        {
            if (dir == 0)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 50, Space.World);

            } else if (dir == 1)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 50, Space.World);

            } else if (dir == 2)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 50, Space.World);

            } else if (dir == 3)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 50, Space.World);
            }
        }
    }
}
