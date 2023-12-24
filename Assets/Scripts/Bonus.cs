using UnityEngine;

public class BonusController : MonoBehaviour
{
    public float speed = 5f; // Швидкість руху бонусу

    void Update()
    {
        // Рух бонусу вниз
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Логіка для збору бонусу
            CollectBonus();
        }
    }

    void CollectBonus()
    {
        // Логіка для збору бонусу (збільшення балів та переходу на новий рівень)
        GameManager.IncreaseScoreAndCheckLevel();

        // Видалення об'єкту бонусу після збору
        Destroy(gameObject);
    }
}

