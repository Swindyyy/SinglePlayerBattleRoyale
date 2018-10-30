using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Wave", menuName = "Wave/Create new wave")]
public class Wave : ScriptableObject {

    public int numOfFastEnemies;
    public int numOfSlowEnemies;
    public float waveShrinkTime;
    public int fogDamage;
    public float dayLength;
    public bool isFogPresent;
    public float fogCoveragePercentage;

    public Wave(int _numOfFastEnemies, int _numOfSlowEnemies, float _waveShrinkTime, int _fogDamage, float _dayLength, bool _isFogPresent, float _fogCoveragePercentage)
    {
        numOfFastEnemies = _numOfFastEnemies;
        numOfSlowEnemies = _numOfSlowEnemies;
        waveShrinkTime = _waveShrinkTime;
        fogDamage = _fogDamage;
        dayLength = _dayLength;
        isFogPresent = _isFogPresent;
        fogCoveragePercentage = _fogCoveragePercentage;
    }

}
