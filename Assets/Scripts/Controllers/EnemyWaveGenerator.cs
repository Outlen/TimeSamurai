using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyWaveGenerator : MonoBehaviour {
  public bool continueSpawning = true;
  public int waveGapSeconds = 5;
  public int spawnGapSeconds = 1;
  public int waveLevel = 2;
  public float spawnDistance = 40;
  public Transform target;

  public List<GameObject> enemyTypes;
  public List<GameObject> enemies;
  public GameObject enemyContainer;

  void Start() {
    target = GameObject.Find("Player").transform;
    enemyContainer = GameObject.Find("Enemy Container");
    StartCoroutine(WaveManager());
  }

  // void Update() {
  // }

  IEnumerator WaveManager() {
    yield return new WaitForSeconds(waveGapSeconds);
    while (continueSpawning) {
      yield return SpawnWaveEnemies();
      yield return new WaitWhile(enemiesAreAlive);
      yield return new WaitForSeconds(waveGapSeconds);
    }
  }

  IEnumerator SpawnWaveEnemies() {
    waveLevel++;
    for (int i = 0; i <= waveLevel; i++) {
      // int x = Random.Range(-10, 10);
      // int y = Random.Range(-10, 10);
      // Choose a random angle.
      float angle = Random.Range(0, 360);
      // Convert the angle to a direction.
      Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
      // Calculate the spawn position.
      Vector2 spawnPosition =
          target.position + ((Vector3)direction * spawnDistance);
      GameObject newEnemy =
          Instantiate(randomType(), spawnPosition, Quaternion.identity);
      newEnemy.transform.parent = enemyContainer.transform;
      enemies.Add(newEnemy);
      yield return new WaitForSeconds(spawnGapSeconds);
    }
  }

  private bool enemiesAreAlive() {
    enemies = enemies.Where(e => e != null).ToList();
    return enemies.Count > 0;
  }

  private GameObject randomType() { return enemyTypes[0]; }
}