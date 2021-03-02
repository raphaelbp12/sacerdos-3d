using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrds.Classes;

public class StatsController : MonoBehaviour
{
    public float attackSpeed = 2f;
    [SerializeField]
    public int playerLevel = 100;
    [SerializeField]
    public int dexterity = 0;
    [SerializeField]
    public int vitality = 100;
    [SerializeField]
    public int strength = 0;
    [SerializeField]
    public int intelligence = 0;
    [SerializeField]
    int playerClass = 0;
}
