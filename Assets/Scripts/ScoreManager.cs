using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public Text cromossomosText;
    public Text cromossomos2Text;
    public Text fusosText;
    public TMP_Text userPointsText;

    public static int cromossomos;
    public static int cromossomos2;
    public static int fusos;
    private static ScoreManager Instance = null;
    private static int geral = 0;
    private static GameObject finalizar;

    private static int userPoints = 0;
    
    void Start()
    {
        if (Instance == null) { Instance = this; }
        if (Instance != this) { Destroy(gameObject); }


        if(SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "GameOver")
        {
            Instance.userPointsText.text = "Sua pontuação foi: " + PlayerPrefs.GetInt("userPoints", userPoints).ToString();
            return;
        }        
        if(SceneManager.GetActiveScene().name == "Profase" || SceneManager.GetActiveScene().name == "Metafase" || SceneManager.GetActiveScene().name == "Anafase" || SceneManager.GetActiveScene().name == "Telofase")
        {
            finalizar = GameObject.FindWithTag("Finalizar");
            Debug.Log(finalizar);
            finalizar.SetActive(false);
            SetPlayerScoreFase();
        } else {
            finalizar = GameObject.FindWithTag("Finalizar");
            Debug.Log(finalizar);
            finalizar.SetActive(false);
            SetPlayerScore(0);
        }
    }

    public static void activateButton(){
        finalizar.SetActive(true);
    }

    public static int GetUserPoints(){
        return userPoints; 
    }

    public static void SetUserPoints(int value){
        userPoints = value;
    }

    public static void IncrementUserPoints(int value){
        userPoints += value;
        PlayerPrefs.SetInt("userPoints", userPoints);
    }
    public static void DecrementUserPoints(int value){
        userPoints -= value;
        PlayerPrefs.SetInt("userPoints", userPoints);
    }


    public static int GetGeneral(){
        return geral; 
    }

    public static void SetGeneral(int value){
        geral = value;
    }

    public static void IncrementGeneral(){
        geral++;
        PlayerPrefs.SetInt("Geral", geral);
    }
    public static void DecrementGeneral(){
        geral--;
        PlayerPrefs.SetInt("Geral", geral);
    }

    public static void SetPlayerScore(int score)
    {
        cromossomos = score;
        cromossomos2 = score;
        fusos = score;
        Instance.cromossomosText.text = "Cromossomos X: " + cromossomos.ToString();
        Instance.cromossomos2Text.text = "Cromossomos Y: " + cromossomos2.ToString();
        Instance.fusosText.text = "Fusos: " + fusos.ToString();
        PlayerPrefs.SetInt("Cromossomo1", cromossomos);
        PlayerPrefs.SetInt("Cromossomo2", cromossomos2);
        PlayerPrefs.SetInt("Fuso", fusos);
        PlayerPrefs.SetInt("Geral", score);
    }
    
    public static void SetPlayerScoreFase()
    {
        cromossomos = PlayerPrefs.GetInt("Cromossomo1", cromossomos);
        cromossomos2 = PlayerPrefs.GetInt("Cromossomo2", cromossomos2);
        fusos = PlayerPrefs.GetInt("Fuso", fusos);
        Instance.cromossomosText.text = "Cromossomos X: " + cromossomos.ToString();
        Instance.cromossomos2Text.text = "Cromossomos Y: " + cromossomos2.ToString();
        Instance.fusosText.text = "Fusos: " + fusos.ToString();
    }

    public static int GetScore()
    {
        return cromossomos;
    }

    public static void IncrementCromo()
    {
        cromossomos++;
        Instance.cromossomosText.text = "Cromossomos X: " + cromossomos.ToString();
        PlayerPrefs.SetInt("Cromossomo1", cromossomos);
    }

    public static void IncrementCromo2()
    {
        cromossomos2++;
        Instance.cromossomos2Text.text = "Cromossomos Y: " + cromossomos2.ToString();
        PlayerPrefs.SetInt("Cromossomo2", cromossomos2);
    }

    public static void IncrementFuso()
    {
        fusos++;
        Instance.fusosText.text = "Fusos: " + fusos.ToString();
        PlayerPrefs.SetInt("Fuso", fusos);
    }

    public static void DecrementCromo()
    {
        cromossomos--;
        Instance.cromossomosText.text = "Cromossomos X: " + cromossomos.ToString();
        PlayerPrefs.SetInt("Cromossomo1", cromossomos);
    }

    public static void DecrementCromo2()
    {
        cromossomos2--;
        Instance.cromossomos2Text.text = "Cromossomos Y: " + cromossomos2.ToString();
        PlayerPrefs.SetInt("Cromossomo2", cromossomos2);
    }

    public static void DecrementFuso()
    {
        fusos--;
        Instance.fusosText.text = "Fusos: " + fusos.ToString();
        PlayerPrefs.SetInt("Fuso", fusos);
    }

    public static void FinalizeScore()
    {
        PlayerPrefs.SetInt("Cromossomo1", cromossomos);
        PlayerPrefs.SetInt("Cromossomo2", cromossomos2);
        PlayerPrefs.SetInt("Fuso", fusos);
    }
}
