using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score = 0; // Лічильник балів
    public static int currentLevel = 1; // Поточний рівень

    // Додайте посилання на текстовий елемент для відображення балів та рівня, якщо потрібно

    public static void IncreaseScoreAndCheckLevel()
    {
        score++; // Збільшення балів при зборі бонусу

        // Логіка для перевірки переходу на новий рівень
        if (score == currentLevel)
        {
            IncreaseLevel();
        }

        // Оновлення відображення балів та рівня, якщо потрібно
    }

    static void IncreaseLevel()
    {
        currentLevel++; // Збільшення номера рівня

        // Логіка для зміни складності гри, наприклад, збільшення швидкості бонусів, тощо.

        // Виведення інформації про новий рівень
        Debug.Log("Level Up! Now on Level " + currentLevel);
    }
}
