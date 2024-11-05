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

    // Start is called before the first frame update
    void Start()
    {
        

    }

    public void RestartGame()
    {
        SceneNavigator.instance.gameState = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GameOver()
    {
        gameIsActive = false;

        gameOverScreen.SetActive(true);
    }

    private void Update()
    {
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

            GameObject target = Instantiate(targets[index]);
            Target targetScript = target.GetComponent<Target>();
            targetScript.typeIndex = index;
            
        }
    }

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
