using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score = 0; // ˳������� ����
    public static int currentLevel = 1; // �������� �����

    // ������� ��������� �� ��������� ������� ��� ����������� ���� �� ����, ���� �������

    public static void IncreaseScoreAndCheckLevel()
    {
        score++; // ��������� ���� ��� ���� ������

        // ����� ��� �������� �������� �� ����� �����
        if (score == currentLevel)
        {
            IncreaseLevel();
        }

        // ��������� ����������� ���� �� ����, ���� �������
    }

    static void IncreaseLevel()
    {
        currentLevel++; // ��������� ������ ����

        // ����� ��� ���� ��������� ���, ���������, ��������� �������� ������, ����.

        // ��������� ���������� ��� ����� �����
        Debug.Log("Level Up! Now on Level " + currentLevel);
    }
}
