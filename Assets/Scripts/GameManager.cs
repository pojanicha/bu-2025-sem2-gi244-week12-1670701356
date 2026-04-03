// notice ... List class requires System.Collections.Generic namespace
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    [Header("UI Elements")]
    // NOTE: TextMeshProUGUI requires "using TMPro"
    public TextMeshProUGUI scoreText;
    // NOTE: TextMeshProUGUI requires "using TMPro"
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    private int score;
    private bool isGameActive = true;
    private float spawnRate = 1.0f;
    private int minusScore;

    void Awake()
    {

    }

    void Start()
    {
        scoreText.text = "score:0" + score;
      
        StartGame();
    }

    /* public void UpdateScore(int score)
     {
         this.score = this.score + score;
         scoreText.text = "score:0" + this.score;


     }
    */

    public void UpdateScore(int s)
    {
        score += s;
        scoreText.text = "score:" + score;


    }


 




    void StartGame()
    {
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            int idx = Random.Range(0, targets.Count);
            var prefab = targets[idx];
            Instantiate(prefab);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}

