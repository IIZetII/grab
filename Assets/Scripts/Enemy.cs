using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour

{
    public Transform[] waypoints; // Массив точек пути
    public float speed = 2f; // Скорость движения врага
    public float health = 10f;
    private int waypointIndex = 0; // Текущая цельная точка

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints set for the enemy.");
            return;
        }

        // Двигаемся к текущей целевой точке
        Transform targetWaypoint = waypoints[waypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Проверяем, достиг ли враг целевой точки
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Если достигли последней точки, меняем направление движения
            if (waypointIndex == waypoints.Length - 1)
            {
                waypointIndex--; // Переходим к предпоследней точке
                direction *= -1; // Меняем направление движения
            }
            // Если достигли первой точки, меняем направление движения
            else if (waypointIndex == 0)
            {
                waypointIndex++; // Переходим к следующей точке
                direction *= -1; // Меняем направление движения
            }
            // В противном случае двигаемся к следующей точке в зависимости от направления
            else
            {
                waypointIndex += (direction.x > 0) ? 1 : -1; // Переходим к следующей или предыдущей точке в зависимости от направления
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Логика смерти врага (например, уничтожение объекта)
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.tag == "player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}