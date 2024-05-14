using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Meta.XR.MRUtilityKit;
using TMPro;

public class EnemySpawnSecond : MonoBehaviour
{
    public FindEnemySpawnLocation findEnemySpawnLocation;
    public int spawnNumber;
    public GameObject spawnSecondObject;
    public GameObject spawnThirdObject;

    public int coffinsNumber;
    private float countCoffinNumber=0;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Stat Spawn Number: " + EnemySpawner.spawnNumberStat);
        Debug.Log("Stat Monster Number: " + MonsterController.counterKillMonsters);

        if (spawnNumber == MonsterController.counterKillMonsters && countCoffinNumber < coffinsNumber)
        {
            Destroy(GameObject.Find("Coffin(Clone)"), 0);
            Destroy(GameObject.Find("CoffinOppy(Clone)"), 0);
            Destroy(GameObject.Find("SpawnLocationIndicator(Clone)"), 0);
            Destroy(GameObject.Find("Cube"), 0);
            Destroy(GameObject.Find("Cube.001"),0);
            Destroy(GameObject.Find("Cube.002"), 0);
            Destroy(GameObject.Find("Cube.003"), 0);
            Destroy(GameObject.Find("Cube.008"), 0);
            Destroy(GameObject.Find("Cube.009"), 0);
            Destroy(GameObject.Find("Plane"), 0);
            Destroy(GameObject.Find("Plane.002"), 0);
            countCoffinNumber++;
            MonsterController.counterKillMonsters = 0;
            EnemySpawner.spawnCount = 0;
            Debug.Log("Second Coffin is being generated");
            if (FacialBlendShapeController.faceIsActive)
            {
                findEnemySpawnLocation.SpawnCoffinPoint(spawnSecondObject);
                GameObject.Find("Mummy_Monster_Red(Clone)").GetComponent<NavMeshAgent>().speed = 0.5f + (countCoffinNumber * 0.2f);
                GameObject.Find("Mummy_Monster_Blue(Clone)").GetComponent<NavMeshAgent>().speed = 0.5f + (countCoffinNumber * 0.2f);
                GameObject.Find("Mummy_Monster_Green(Clone)").GetComponent<NavMeshAgent>().speed = 0.5f + (countCoffinNumber * 0.2f);
            }
            else if (FacialBlendShapeController.faceIsActive == false)
            {
                findEnemySpawnLocation.SpawnCoffinPoint(spawnThirdObject);
                GameObject.Find("Oppy_Red(Clone)").GetComponent<NavMeshAgent>().speed = 0.5f + ((countCoffinNumber - 1) * 0.2f);
                GameObject.Find("Oppy_Blue(Clone)").GetComponent<NavMeshAgent>().speed = 0.5f + ((countCoffinNumber - 1) * 0.2f);
                GameObject.Find("Oppy_Green(Clone)").GetComponent<NavMeshAgent>().speed = 0.5f + ((countCoffinNumber - 1) * 0.2f);
            }
            
            
            
        }
    }



}
