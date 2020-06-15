using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GeneralSettings : MonoBehaviour
{
    //[SerializeField]
    public bool isRight;
    public int highScore;
    public int selectedTrail;
    public bool tutorialSeen;


    private void Awake()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");

        Settings fromSaveFile = JsonUtility.FromJson<Settings>(json);
        isRight = fromSaveFile.isRight;
        highScore = fromSaveFile.highScore;
        selectedTrail = fromSaveFile.selectedTrail;
        tutorialSeen = fromSaveFile.tutorialSeen;
    }

    public void SaveSettings()
    {
        Settings toSaveFile = new Settings();
        toSaveFile.isRight = isRight;
        toSaveFile.highScore = highScore;
        toSaveFile.selectedTrail = selectedTrail;
        toSaveFile.tutorialSeen = tutorialSeen;
        string json = JsonUtility.ToJson(toSaveFile);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public class Settings
    {
        public bool isRight;
        public int highScore;
        public int selectedTrail;
        public bool tutorialSeen;
    }
    
}
