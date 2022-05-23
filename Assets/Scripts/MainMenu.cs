using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas points;
    private bool temp;

    public void PlayFirst(){
        SceneManager.LoadScene("main_scene");
    }

    public void PlayGame(){
        ScoreManager.IncrementGeneral();
        if (ScoreManager.GetGeneral() > 3){
            ScoreManager.SetGeneral(0);
        }
        SceneManager.LoadScene("main_scene");
    }
    public void LoadMounting()
    {
        temp = false;
        ScoreManager.FinalizeScore();
        if(ScoreManager.GetGeneral() == 0){
            temp = true;
            SceneManager.LoadScene("Profase");
        }
        if(ScoreManager.GetGeneral() == 1){
            temp = true;
            SceneManager.LoadScene("Metafase");
        }
        if(ScoreManager.GetGeneral() == 2){
            temp = true;
            SceneManager.LoadScene("Anafase");
        }
        if(ScoreManager.GetGeneral() == 3){
            temp = true;
            SceneManager.LoadScene("Telofase");
        }
        if(!temp){
            ScoreManager.SetGeneral(0);
            SceneManager.LoadScene("Win");
        }
    }
    public void LoadGameOver()
    {
        ScoreManager.SetGeneral(0);
        ScoreManager.SetPlayerScore(0);
        SceneManager.LoadScene("GameOver");
    }
    public void Win()
    {
        ScoreManager.SetGeneral(0);
        ScoreManager.SetPlayerScore(0);
        SceneManager.LoadScene("Win");
    }
    public void Restart()
    {
        ScoreManager.SetUserPoints(0);
        ScoreManager.SetGeneral(0);
        ScoreManager.SetPlayerScore(0);
        SceneManager.LoadScene("Menu");
    }
}
