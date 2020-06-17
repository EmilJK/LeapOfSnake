using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelGenManager : MonoBehaviour
{
    public int roomsVisited;
    public int roomsBiomeCounter;
    public int currentBiomeInt;
    public Transform roomParent;
    public AudioSource ambxAudio;

    GeneralSettings jsonScript;

    public TextMeshProUGUI depthCounter, depthScore, depthHighScore;

    public bool biomeChecker;

    //public Animator camBackground;

    public enum Biomes { universe, heaven, mountain, medival, viking, roman, stoneage, iceage, mesozoic, paleozonic, hell };
    public Biomes currentBiome = Biomes.heaven;

    public GameObject[] roomsToGenerateNow;

    public GameObject[] roomsHeaven;
    public GameObject[] roomsMountain;
    public GameObject[] roomsMedival;
    public GameObject[] roomsViking;
    public GameObject[] roomsRoman;
    public GameObject[] roomsStoneage;
    public GameObject[] roomsIceage;
    public GameObject[] roomsMesozoic;
    public GameObject[] roomsPaleozonic;
    public GameObject[] roomsHell;
    public GameObject[] roomsUniverse;

    public AudioClip[] ambxClips;

    public List<GameObject> rooms = new List<GameObject>();

    #region backgrounds
    public SpriteRenderer layerOneMain;
    public SpriteRenderer layerOneAbove;
    public SpriteRenderer layerOneUnder;
    public SpriteRenderer layerTwoMain;
    public SpriteRenderer layerTwoAbove;
    public SpriteRenderer layerTwoUnder;
    public SpriteRenderer layerThreeMain;
    public SpriteRenderer layerThreeAbove;
    public SpriteRenderer layerThreeUnder;

    public Sprite[] heavenSprite;
    public Sprite[] mountainSprite;
    public Sprite[] medivalSprite;
    public Sprite[] vikingSprite;
    public Sprite[] romanSprite;
    public Sprite[] stoneageSprite;
    public Sprite[] iceageSprite;
    public Sprite[] mesozoicSprite;
    public Sprite[] paleozonicSprite;
    public Sprite[] hellSprite;
    public Sprite[] universeSprite;
    #endregion

    void Start()
    {
        jsonScript = FindObjectOfType<GeneralSettings>();

        roomsVisited = 0;
        roomsBiomeCounter = 0;
        currentBiomeInt = 1;

        //depthCounter = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ambxAudio.clip = ambxClips[currentBiomeInt];
        AssignBiomes();
        BiomeCounter();
        //camBackground.SetInteger("CurrentBiome", currentBiomeInt);

        depthCounter.text = "Depth: " + roomsVisited;
        depthScore.text = "Your Score: \n" + roomsVisited;
        depthHighScore.text = "Your Highscore: \n" + jsonScript.highScore;
    }

    public void AssignBiomes()
    {
        switch (currentBiome)
        {
            case Biomes.heaven:
                roomsToGenerateNow = roomsHeaven;
                currentBiomeInt = 1;
                layerOneMain.sprite = heavenSprite[0]; layerTwoMain.sprite = heavenSprite[1]; layerThreeMain.sprite = heavenSprite[2];
                layerOneAbove.sprite = heavenSprite[0]; layerTwoAbove.sprite = heavenSprite[1]; layerThreeAbove.sprite = heavenSprite[2];
                layerOneUnder.sprite = heavenSprite[0]; layerTwoUnder.sprite = heavenSprite[1]; layerThreeUnder.sprite = heavenSprite[2];
                break;
            case Biomes.mountain:
                roomsToGenerateNow = roomsMountain;
                currentBiomeInt = 2;
                layerOneMain.sprite = mountainSprite[0]; layerTwoMain.sprite = mountainSprite[1]; layerThreeMain.sprite = mountainSprite[2];
                layerOneAbove.sprite = mountainSprite[0]; layerTwoAbove.sprite = mountainSprite[1]; layerThreeAbove.sprite = mountainSprite[2];
                layerOneUnder.sprite = mountainSprite[0]; layerTwoUnder.sprite = mountainSprite[1]; layerThreeUnder.sprite = mountainSprite[2];
                break;
            case Biomes.medival:
                roomsToGenerateNow = roomsMedival;
                currentBiomeInt = 3;
                layerOneMain.sprite = medivalSprite[0]; layerTwoMain.sprite = medivalSprite[1]; layerThreeMain.sprite = medivalSprite[2];
                layerOneAbove.sprite = medivalSprite[0]; layerTwoAbove.sprite = medivalSprite[1]; layerThreeAbove.sprite = medivalSprite[2];
                layerOneUnder.sprite = medivalSprite[0]; layerTwoUnder.sprite = medivalSprite[1]; layerThreeUnder.sprite = medivalSprite[2];
                break;
            case Biomes.viking:
                roomsToGenerateNow = roomsViking;
                currentBiomeInt = 4;
                layerOneMain.sprite = vikingSprite[0]; layerTwoMain.sprite = vikingSprite[1]; layerThreeMain.sprite = vikingSprite[2];
                layerOneAbove.sprite = vikingSprite[0]; layerTwoAbove.sprite = vikingSprite[1]; layerThreeAbove.sprite = vikingSprite[2];
                layerOneUnder.sprite = vikingSprite[0]; layerTwoUnder.sprite = vikingSprite[1]; layerThreeUnder.sprite = vikingSprite[2];
                break;
            case Biomes.roman:
                roomsToGenerateNow = roomsRoman;
                currentBiomeInt = 5;
                layerOneMain.sprite = romanSprite[0]; layerTwoMain.sprite = romanSprite[1]; layerThreeMain.sprite = romanSprite[2];
                layerOneAbove.sprite = romanSprite[0]; layerTwoAbove.sprite = romanSprite[1]; layerThreeAbove.sprite = romanSprite[2];
                layerOneUnder.sprite = romanSprite[0]; layerTwoUnder.sprite = romanSprite[1]; layerThreeUnder.sprite = romanSprite[2];
                break;
            case Biomes.stoneage:
                roomsToGenerateNow = roomsStoneage;
                currentBiomeInt = 6;
                layerOneMain.sprite = stoneageSprite[0]; layerTwoMain.sprite = stoneageSprite[1]; layerThreeMain.sprite = stoneageSprite[2];
                layerOneAbove.sprite = stoneageSprite[0]; layerTwoAbove.sprite = stoneageSprite[1]; layerThreeAbove.sprite = stoneageSprite[2];
                layerOneUnder.sprite = stoneageSprite[0]; layerTwoUnder.sprite = stoneageSprite[1]; layerThreeUnder.sprite = stoneageSprite[2];
                break;
            case Biomes.iceage:
                roomsToGenerateNow = roomsIceage;
                currentBiomeInt = 7;
                layerOneMain.sprite = iceageSprite[0]; layerTwoMain.sprite = iceageSprite[1]; layerThreeMain.sprite = iceageSprite[2];
                layerOneAbove.sprite = iceageSprite[0]; layerTwoAbove.sprite = iceageSprite[1]; layerThreeAbove.sprite = iceageSprite[2];
                layerOneUnder.sprite = iceageSprite[0]; layerTwoUnder.sprite = iceageSprite[1]; layerThreeUnder.sprite = iceageSprite[2];
                break;
            case Biomes.mesozoic:
                roomsToGenerateNow = roomsMesozoic;
                currentBiomeInt = 8;
                layerOneMain.sprite = mesozoicSprite[0]; layerTwoMain.sprite = mesozoicSprite[1]; layerThreeMain.sprite = mesozoicSprite[2];
                layerOneAbove.sprite = mesozoicSprite[0]; layerTwoAbove.sprite = mesozoicSprite[1]; layerThreeAbove.sprite = mesozoicSprite[2];
                layerOneUnder.sprite = mesozoicSprite[0]; layerTwoUnder.sprite = mesozoicSprite[1]; layerThreeUnder.sprite = mesozoicSprite[2];
                break;
            case Biomes.paleozonic:
                roomsToGenerateNow = roomsPaleozonic;
                currentBiomeInt = 9;
                layerOneMain.sprite = paleozonicSprite[0]; layerTwoMain.sprite = paleozonicSprite[1]; layerThreeMain.sprite = paleozonicSprite[2];
                layerOneAbove.sprite = paleozonicSprite[0]; layerTwoAbove.sprite = paleozonicSprite[1]; layerThreeAbove.sprite = paleozonicSprite[2];
                layerOneUnder.sprite = paleozonicSprite[0]; layerTwoUnder.sprite = paleozonicSprite[1]; layerThreeUnder.sprite = paleozonicSprite[2];
                break;
            case Biomes.hell:
                roomsToGenerateNow = roomsHell;
                currentBiomeInt = 10;
                layerOneMain.sprite = hellSprite[0]; layerTwoMain.sprite = hellSprite[1]; layerThreeMain.sprite = hellSprite[2];
                layerOneAbove.sprite = hellSprite[0]; layerTwoAbove.sprite = hellSprite[1]; layerThreeAbove.sprite = hellSprite[2];
                layerOneUnder.sprite = hellSprite[0]; layerTwoUnder.sprite = hellSprite[1]; layerThreeUnder.sprite = hellSprite[2];
                break;
            case Biomes.universe:
                roomsToGenerateNow = roomsUniverse;
                currentBiomeInt = 0;
                layerOneMain.sprite = universeSprite[0]; layerTwoMain.sprite = universeSprite[1]; layerThreeMain.sprite = universeSprite[2];
                layerOneAbove.sprite = universeSprite[0]; layerTwoAbove.sprite = universeSprite[1]; layerThreeAbove.sprite = universeSprite[2];
                layerOneUnder.sprite = universeSprite[0]; layerTwoUnder.sprite = universeSprite[1]; layerThreeUnder.sprite = universeSprite[2];
                break;
            default:
                break;
        }
    }

    public void BiomeCounter()
    {
        if (roomsBiomeCounter >= 10)
        {
            if (currentBiome == Biomes.hell)
            {
                biomeChecker = false;
            }
            else if (currentBiome == Biomes.universe)
            {
                biomeChecker = true;
            }

            if (biomeChecker)
            {
                currentBiome++;
            }
            else if (!biomeChecker)
            {
                currentBiome--;
            }
            Invoke("PlayAmbx", 1f);
            roomsBiomeCounter = 0;
        }
    }

    public void PlayAmbx()
    {
        ambxAudio.Play();
    }
    //Returns a new random "room" to instansiate from the RoomCollider script
    public GameObject NewRoom()
    {
        if (currentBiomeInt < 3 && roomsVisited < 30)
        {
            int randRoom;
            randRoom = Random.Range(0, 5);
            GameObject newRoom;

            newRoom = roomsToGenerateNow[randRoom];
            roomsVisited++;
            roomsBiomeCounter++;
            return newRoom;
        }
        else
        {
            int randRoom;
            randRoom = Random.Range(0, roomsToGenerateNow.Length);
            GameObject newRoom;

            newRoom = roomsToGenerateNow[randRoom];
            roomsVisited++;
            roomsBiomeCounter++;
            return newRoom;

        }
    }

    public void RemoveARoom(GameObject addToList)
    {
        rooms.Add(addToList);
        if (rooms.Count > 5)
        {
            Destroy(rooms[0]);
            rooms.RemoveAt(0);
        }
    }
}
