using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyWaveGenerator : MonoBehaviour {
  public bool continueSpawning = true;
  public int waveGapSeconds = 3;
  public int spawnGapSeconds = 1;
  public float spawnDistance = 80;
  public Transform target;

  public int waveLevel = 4;
  public float waveStartTime;
  public int timeLimit = 10; // time limit plus wave level.
                             // 10 + 4 = 14seconds

  public List<GameObject> enemyTypes;
  public List<float> typeProbabilities;
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
      waveStartTime = Time.time;
      distributeProbabilities();
      yield return new WaitWhile(enemiesAreAliveOrTimeLimitReached);
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

  private bool enemiesAreAliveOrTimeLimitReached() {
    if ((waveStartTime + waveLevel + timeLimit) < Time.time) {
      return false;
    }
    enemies = enemies.Where(e => e != null).ToList();
    return enemies.Count > 0;
  }
  public float max;
  private void distributeProbabilities() {
    if (typeProbabilities[0] < 51) {
      // once probabilities have been distributed enough,
      //      don't bother continuing
      // Debug.Log("distributed");
      return;
    }
    int prob = Random.Range(1, 11) + waveLevel;
    for (int i = typeProbabilities.Count - 1; i >= 0; i--) {
      typeProbabilities[typeProbabilities.Count - i - 1] += prob * (i + 1);
    }
    max = typeProbabilities.Sum();
    for (int i = 0; i < typeProbabilities.Count; i++) {
      typeProbabilities[i] = typeProbabilities[i] * 100 / max;
    }
  }

  private GameObject randomType() {
    int type = Random.Range(1, 101);
    for (int i = 0; i < typeProbabilities.Count; i++) {
      if (type <= typeProbabilities[i]) {
        return enemyTypes[i];
      }
      type -= (int)typeProbabilities[i];
    }
    return enemyTypes[enemyTypes.Count - 1];
  }
}
