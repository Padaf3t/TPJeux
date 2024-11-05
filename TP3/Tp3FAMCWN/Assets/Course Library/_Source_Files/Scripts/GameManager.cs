using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static SaveSystem;

public class GameManager : MonoBehaviour
{
    float spawnRate = 1f;
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;

    public int score = 0;
    public int nLives { get; private set; }

    public static GameManager instance;

    public List<GameObject> lifeImages;

    public bool gameIsActive = true;

    public GameObject gameOverScreen;
    public GameObject pausePanel;

    private PausePanel pauseScript;

    public AudioSource gameMusic;

    private void Awake()
    {
        StartCoroutine(SpawnTargets());

        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }

        instance = this;
        pauseScript = GetComponent<PausePanel>();

        gameMusic.volume = GameSetting.SoundVolume;
        spawnRate = GameSetting.SpawnValue;
        int scoreTemp = 0;
        int liveTemp = 3;

        if (SceneNavigator.instance.gameState != null)
        {
            SpawnLoadTarget();
            scoreTemp = SceneNavigator.instance.gameState.score;
            liveTemp = SceneNavigator.instance.gameState.lives;
        }

        //TODO reste a 
        //verifier si scene est nouvelle partie ou non

        UpdateScore(scoreTemp);
        UpdateLives(liveTemp);
        gameOverScreen.SetActive(false);
        pausePanel.SetActive(false);
    }

    /// <summary>
    /// Restart the game, make sure the gamestate is null to reload a fresh game
    /// </summary>
    public void RestartGame()
    {
        SceneNavigator.instance.gameState = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    /// <summary>
    /// Set the game over screen
    /// </summary>
    public void GameOver()
    {
        gameIsActive = false;

        gameOverScreen.SetActive(true);
    }

    private void Update()
    {
        //On escape, open or close the pause panel
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (pausePanel.activeSelf)
            {
                pauseScript.ClosePanel();
            }
            else
            {
                pauseScript.OpenPanel();
            }
        }

        //put by Léo Caussant, now we can cheat :D
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f - Time.timeScale;
        } 
    }

    /// <summary>
    /// Set the timeScale to 0 or 1
    /// </summary>
    /// <param name="val"></param>
    public void SetPause(bool val = true)
    {
        Time.timeScale = val ? 1f : 0f;
    }

    /// <summary>
    /// Add the scoreToAdd to score
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void UpdateScore(int scoreToAdd = 0)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    /// <summary>
    /// Add the livesToAdd to nLives
    /// </summary>
    /// <param name="livesToAdd"></param>
    public void UpdateLives(int livesToAdd = 0)
    {
        nLives += livesToAdd;

        for(int i = 0; i < lifeImages.Count; i++)
        {
            lifeImages[i].SetActive(i < nLives);
        }

        if (nLives <= 0) GameOver();
    }

    /// <summary>
    /// Spawn the target while the game is active
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnTargets()
    {
        while (gameIsActive)
        {
            yield return new WaitForSeconds(1f / spawnRate);
            var index = Random.Range(0, targets.Count);

            GameObject target = Instantiate(targets[index]);
            Target targetScript = target.GetComponent<Target>();
            targetScript.typeIndex = index;
            
        }
    }

    /// <summary>
    /// Reload each target object if a GameState is set
    /// Instantiate when the time is stop to make sure the object dont 
    /// interact with each other
    /// </summary>
    private void SpawnLoadTarget()
    {
        Time.timeScale = 0;
        foreach (var targetData in SceneNavigator.instance.gameState.targetData)
        {
            // Instantiate the correct target prefab based on the type
            GameObject targetPrefab = targets[targetData.type]; // Assuming type maps to prefab index
            GameObject targetInstance = Instantiate(targetPrefab, new Vector3(targetData.xPosition, targetData.yPosition, targetData.zPosition),
                                                      Quaternion.Euler(targetData.xAngle, targetData.yAngle, targetData.zAngle));
        
            targetInstance.GetComponent<Rigidbody>().velocity = new Vector3(targetData.xVelocity, targetData.yVelocity, targetData.zVelocity);
            targetInstance.GetComponent<Target>().haveBeenLoaded = true;
        }
        Time.timeScale = 1;
    }
}
