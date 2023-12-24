using UnityEngine;

public class BonusController : MonoBehaviour
{
    public float speed = 5f; // �������� ���� ������

    void Update()
    {
        // ��� ������ ����
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ����� ��� ����� ������
            CollectBonus();
        }
    }

    void CollectBonus()
    {
        // ����� ��� ����� ������ (��������� ���� �� �������� �� ����� �����)
        GameManager.IncreaseScoreAndCheckLevel();

        // ��������� ��'���� ������ ���� �����
        Destroy(gameObject);
    }
}

