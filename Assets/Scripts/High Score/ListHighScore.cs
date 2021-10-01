using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ListHighScore
{
    private static List<HighScore> _highScoreList = new List<HighScore>();
    private static readonly string FilePath = Application.persistentDataPath + "/HighScoreData.json";

    public static List<HighScore> HighScoreList
    {
        get { return _highScoreList; }
    }

    public static void SaveNewHighScore(HighScore highScore)
    {
        _highScoreList.Add(highScore);
        _highScoreList.Sort((score, score1) => score.score.CompareTo(score1.score));
        _highScoreList.Reverse();
        if (_highScoreList.Count > 5)
        {
            _highScoreList.RemoveAt(_highScoreList.Count - 1);
        }

        SaveToJson();
    }

    public static void LoadHighScore()
    {
        if(!File.Exists(FilePath)) return;

        string jsonFile = File.ReadAllText(FilePath);
        ListHighScoreData listHighScoreData = JsonUtility.FromJson<ListHighScoreData>(jsonFile);
        _highScoreList = listHighScoreData.listHighScore;
    }

    private static void SaveToJson()
    {
        ListHighScoreData listHighScoreData = new ListHighScoreData();
        listHighScoreData.listHighScore = _highScoreList;
        string jsonFile = JsonUtility.ToJson(listHighScoreData);
        File.WriteAllText(FilePath, jsonFile);
    }
}
