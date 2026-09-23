using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform LeftPaddle;
    public Transform RightPaddle;
    public BallController ballController;

    public int Player1Score = 0;
    public int Player2Score = 0;
    public TextMeshProUGUI textPoints1;
    public TextMeshProUGUI textPoints2;

    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;

    public float WinScore = 5;

    void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        LeftPaddle.position = new Vector3(-7f, 0f, 0f);
        RightPaddle.position = new Vector3(7f, 0f, 0f);
        ballController.ResetBall();

        Player1Score = 0;
        Player2Score = 0;
        textPoints2.text = Player2Score.ToString();
        textPoints1.text = Player1Score.ToString();

        screenEndGame.SetActive(false);

    }

    public void LeftScore()
    {
        Player1Score++;
        textPoints1.text = Player1Score.ToString();
        CheckWin();
    }

    public void RightScore()
    {
        Player2Score++;
        textPoints2.text = Player2Score.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (Player2Score >= WinScore || Player1Score >= WinScore)
        {
            EndGame();
            print("Game is Over");
        }
    }
    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(Player1Score > Player2Score);
        textEndGame.text = "Vitória " + winner;
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 3f);
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}