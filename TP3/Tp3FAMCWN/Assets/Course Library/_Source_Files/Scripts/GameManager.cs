using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float spawnRate = 1f;
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;

    public int score = 0;
    private int nLives = 3;

    public static GameManager instance;

    public List<GameObject> lifeImages;

    public bool gameIsActive = true;

    public GameObject gameOverScreen;

    public AudioSource gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());

        instance = this;
        
        UpdateScore();
        UpdateLives();
        gameOverScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );

    }

    public void GameOver()
    {
        gameIsActive = false;

        gameOverScreen.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f - Time.timeScale;
        } 
    }

    public void SetPause(bool val = true)
    {
        Time.timeScale = val ? 1f : 0f;
    }

    public void UpdateScore(int scoreToAdd = 0)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    public void UpdateLives(int livesToAdd = 0)
    {
        nLives += livesToAdd;

        for(int i = 0; i < lifeImages.Count; i++)
        {
            lifeImages[i].SetActive(i < nLives);
        }

        if (nLives <= 0) GameOver();
    }

    private IEnumerator SpawnTargets()
    {
        while (gameIsActive)
        {
            yield return new WaitForSeconds(1f / spawnRate);
            var index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }
}
