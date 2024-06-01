using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform shootingPoint; // Точка стрельбы
    public float projectileSpeed = 30f; // Скорость снаряда

    public float fireRate = 0.1f; // Скорость стрельбы (интервал между выстрелами)

    private float nextFireTime = 0f; // Время до следующего выстрела

    void Update()
    {
        // Проверяем, удерживается ли левая кнопка мыши
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot(); // Вызываем метод стрельбы
            nextFireTime = Time.time + fireRate; // Обновляем время до следующего выстрела
        }
    }

    void Shoot()
    {
        // Получаем позицию мыши в мировом пространстве
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Устанавливаем z-позицию в 0, так как мы в 2D пространстве

        // Вычисляем направление к позиции мыши
        Vector2 direction = (mousePosition - shootingPoint.position).normalized;

        // Вычисляем угол поворота
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Создаем снаряд с правильным поворотом
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.Euler(new Vector3(0, 0, angle)));

        // Добавляем скорость снаряду
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
        Destroy(projectile, 5);
    }
}
