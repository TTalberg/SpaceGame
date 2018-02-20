using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {
    public Text txtScore;
    private int Score = 0;
    int update;

    // Use this for initialization
    void UpdateScore(int update) {
        Score = Score + update;
        txtScore.text = "Kills: FUCKING POST THIS " + Score;
    }
}
