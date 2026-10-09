using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public float Score = 0;
    public TextMeshProUGUI ScoreText;
    public GameObject GameOverScreen;

    public ObstacleSpawner ObstacleSpawner;

    private bool _isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isGameOver)
        {
            Score += Time.deltaTime * 10f;
            ScoreText.text = Mathf.FloorToInt(Score).ToString("D5");
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && _isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnDeath()
    {
        _isGameOver = true;
        GameOverScreen.SetActive(true);
        Obstacle.MoveSpeed = 0f;
        ObstacleSpawner.StopSpawning();
    }
}
