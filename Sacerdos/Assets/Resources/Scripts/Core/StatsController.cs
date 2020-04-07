using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Classes;

public class StatsController : MonoBehaviour
{
    [SerializeField]
    float exp = 0;
    [SerializeField]
    int playerLevel = 2;
    [SerializeField]
    int dexterity = 0;
    [SerializeField]
    int vitality = 0;
    [SerializeField]
    int strength = 0;
    [SerializeField]
    int intelligence = 0;
    [SerializeField]
    int playerClass = 0;
    List<PlayerStatsCurve> playerStatsCurves = new List<PlayerStatsCurve>();
    List<PlayerStatsByClass> playerStatsByClasses = new List<PlayerStatsByClass>();
    PlayerStats playerStats = new PlayerStats();
    // Start is called before the first frame update
    void Start()
    {
        playerStatsCurves.AddRange(FileSystem.ParseJsonFile<List<PlayerStatsCurve>>("stats"));
        playerStatsByClasses.AddRange(FileSystem.ParseJsonFile<List<PlayerStatsByClass>>("stats_by_class"));
        playerStats = FileSystem.ParseJsonFile<PlayerStats>("player");
        playerClass = playerStats.Class;
        exp = playerStats.Experience;
    }

    // Update is called once per frame
    void Update()
    {
        dexterity = GetAttributeByName(PlayerStatsByClassEnum.dexterity);
        vitality = GetAttributeByName(PlayerStatsByClassEnum.vitality);
        strength = GetAttributeByName(PlayerStatsByClassEnum.strength);
        intelligence = GetAttributeByName(PlayerStatsByClassEnum.intelligence);
    }

    int GetAttributeByName(PlayerStatsByClassEnum attributeName)
    {
        PlayerStatsCurve statsCurve = new PlayerStatsCurve();
        PlayerStatsByClass playerStatsByClass = playerStatsByClasses[playerClass];
        statsCurve = playerStatsCurves[0];

        switch (attributeName)
        {
            case PlayerStatsByClassEnum.dexterity:
                statsCurve = playerStatsCurves[playerStatsByClass.dexterity];
                break;
            case PlayerStatsByClassEnum.vitality:
                statsCurve = playerStatsCurves[playerStatsByClass.vitality];
                break;
            case PlayerStatsByClassEnum.strength:
                statsCurve = playerStatsCurves[playerStatsByClass.strength];
                break;
            case PlayerStatsByClassEnum.intelligence:
                statsCurve = playerStatsCurves[playerStatsByClass.intelligence];
                break;
            default:
                statsCurve = playerStatsCurves[playerStatsByClass.intelligence];
                break;
        }

        return GetAttributeOnCurveByLevel(playerLevel, statsCurve);
    }

    int GetAttributeOnCurveByLevel(int level, PlayerStatsCurve statsCurve)
    {
        float stat = (statsCurve.baseMultiplier * Mathf.Pow(statsCurve.classMultiplier, statsCurve.levelMultiplier * level)) + statsCurve.classBase;
        return Mathf.FloorToInt(stat);
    }
}
