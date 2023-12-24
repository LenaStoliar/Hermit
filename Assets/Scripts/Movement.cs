// Код для Unity C# гри з космічним кораблем
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public int score;
    public float speed = 5f;
    public int maxHealth = 3;

    private int currentHealth;
    private bool bonusCollected = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();
        }
        else if (other.CompareTag("Bonus"))
        {
            CollectBonus();
        }
    }

    void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void CollectBonus()
    {
        if (!bonusCollected && score < currentHealth)
        {
            score++;
            bonusCollected = true;
            // Update UI for score
        }
        else
        {
            bonusCollected = false;
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over - You Lose!");
    }
}

public class LevelManager : MonoBehaviour
{
    private int currentLevel = 1; private SpaceShipController spaceShipController;

    void Start()
    {
        spaceShipController = FindObjectOfType<SpaceShipController>(); // Assuming there is only one instance of SpaceShipController
    }

    void Update()
    {
        if (spaceShipController.score == currentLevel && currentLevel < 3)
        {
            IncreaseLevel();
        }

        if (spaceShipController.score >= 3)
        {
            GameWin();
        }
    }

    void IncreaseLevel()
    {
        currentLevel++; // Збільшення номера рівня

        
        Debug.Log("Level Up! Now on Level " + currentLevel); currentLevel++; // Збільшення номера рівня

        
    }


    void GameWin()
    {
        Debug.Log("Congratulations! You Win!");
    }
}