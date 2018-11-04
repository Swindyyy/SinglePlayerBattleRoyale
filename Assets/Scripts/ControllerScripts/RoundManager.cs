using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RoundManager : MonoBehaviour {

    bool isDayTime = false;

    [SerializeField]
    List<Wave> waveList = new List<Wave>();

    [SerializeField]
    GameObject fog;

    [SerializeField]
    EnemySpawner enemySpawner;

    Wave currentWave;
    int waveCounter = 0;

    [SerializeField]
    float dayTimeRemaining;

    [SerializeField]
    Light dayLight;

    [SerializeField]
    float dayLightStrength = 1;

    [SerializeField]
    Light nightLight;   

    [SerializeField]
    float nightLightStrength = 0.1f;

    [SerializeField]
    float dayNightSwitchTime = 1f;

    [SerializeField]
    PostProcessVolume nightTimePost;

    [SerializeField]
    PostProcessVolume dayTimePost;

    Vector3 currentFogScale;
    Vector3 targetFogScale;
    Animator animator;


	// Use this for initialization
	void Start () {
        currentWave = waveList[waveCounter];
        enemySpawner.EnemiesToSpawn(currentWave.numOfFastEnemies, currentWave.numOfSlowEnemies);
        dayTimeRemaining = currentWave.dayLength;
        isDayTime = false;
        enemySpawner.SetAreEnemiesSpawning(true);
        currentFogScale = fog.transform.localScale;
        Debug.Log("Initial fog scale: " + currentFogScale);
        targetFogScale = new Vector3(currentFogScale.x * currentWave.fogCoveragePercentage, currentFogScale.y, currentFogScale.z * currentWave.fogCoveragePercentage);
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isDayTime)
        {
            if (dayTimeRemaining >= 0)
            {
                DayCountdown();
            }
            else
            {
                BeginNextWave();
            }

            return;
        }
        else
        {
            ShrinkFog();
        }


        var numOfEnemiesRemaining = EnemiesRemaining();

        if(numOfEnemiesRemaining == 0 && !isDayTime && !enemySpawner.GetAreEnemiesSpawning())
        {
            isDayTime = true;
            animator.SetTrigger("onDayStart");
        }
	}


    void OnGUI()
    {
        if(isDayTime)
        {
            GUILayout.Label("Day time");
        } else
        {
            GUILayout.Label("Night time");
        }
    }

    int EnemiesRemaining()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length;
    }

    void DayCountdown()
    {
        dayTimeRemaining -= Time.deltaTime;
    }

    void BeginNextWave()
    {
        waveCounter += 1;

        if(waveCounter > waveList.Count)
        {
            return;
        }

        Wave nextWave = waveList[waveCounter];
        currentWave = nextWave;

        dayTimeRemaining = currentWave.dayLength;
        enemySpawner.EnemiesToSpawn(currentWave.numOfFastEnemies, currentWave.numOfSlowEnemies);
        enemySpawner.SetAreEnemiesSpawning(true);
        isDayTime = false;
        animator.SetTrigger("onNightStart");

        fog.SetActive(currentWave.isFogPresent);
        currentFogScale = fog.transform.localScale;
        targetFogScale = new Vector3(currentFogScale.x * currentWave.fogCoveragePercentage, currentFogScale.y, currentFogScale.z * currentWave.fogCoveragePercentage);
        Debug.Log("Current Fog Scale " + currentFogScale);
        Debug.Log("Target Fog Scale " + targetFogScale);

    }  

    void ShrinkFog()
    {
        float distancePerSecond = (currentFogScale.x - targetFogScale.x) / currentWave.waveShrinkTime;
        //Debug.Log("Distance per second: " + distancePerSecond);
        //Debug.Log("Distance per frame: " + distancePerSecond * Time.deltaTime);
       
        if(fog.activeSelf)
        {
            float newScale = fog.transform.localScale.x - (distancePerSecond * Time.deltaTime);
            if (newScale >= targetFogScale.x)
            {
                fog.transform.localScale = new Vector3(newScale, currentFogScale.y, newScale);
            }
        }
    }

    public int GetCurrentWaveDamage()
    {
        return currentWave.fogDamage;
    }

}  
