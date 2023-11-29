using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private FloatValue enemySpawnTime;
    [SerializeField] private List<SpawnPoint> spawnPoints;
    [SerializeField] private List<Enemy> enemiesType;
    float cooldownTime;
    void Start()
    {
        cooldownTime = enemySpawnTime.initialValue;
        SpawnEnemy(cooldownTime);
    }

    private void SpawnEnemy(float cooldownTime){
        Transform spawnPosition = SelectPointToSpawnEnemy();
        Enemy enemyType = SelectEnemyType();
        StartCoroutine(SpawnEnemyCo(cooldownTime, enemyType, spawnPosition.position));
    }

    private Transform SelectPointToSpawnEnemy(){
        int totalPoints = spawnPoints.Count;
        int selectedPoint = Random.Range(0, totalPoints);
        return spawnPoints.ElementAt(selectedPoint).transform;        
    }

    private Enemy SelectEnemyType(){
        int totalEnemiesType = enemiesType.Count;
        int selectedEnemy = Random.Range(0, totalEnemiesType);
        return enemiesType.ElementAt(selectedEnemy);
    }

    protected IEnumerator SpawnEnemyCo (float cooldownTime ,Enemy enemyType, Vector2 spawnPosition){

        yield return new WaitForSecondsRealtime(cooldownTime);
        Enemy newEnemy = Instantiate( enemyType, spawnPosition, Quaternion.identity).GetComponent<Enemy>();
        SpawnEnemy(cooldownTime);
    }
}
