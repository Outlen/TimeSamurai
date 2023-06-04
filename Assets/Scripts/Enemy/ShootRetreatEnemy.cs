using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRetreatEnemy : MonoBehaviour {
  public float speed;
  public Transform target;
  public float shootingRange;
  public float minDistance;

  void Start() {
    target = GameObject.Find("Player").transform;
    speed = UnityEngine.Random.Range(1, 3);
    shootingRange = UnityEngine.Random.Range(6, 9);
    minDistance = UnityEngine.Random.Range(3, 5);
  }
  void Update() {
    if (Vector2.Distance(transform.position, target.position) < minDistance) {
      transform.position = Vector2.MoveTowards(transform.position,
          target.position, -speed * Time.deltaTime);
    } else if (Vector2.Distance(transform.position, target.position) < shootingRange) {
      transform.position = Vector2.MoveTowards(transform.position,
          target.position, speed * Time.deltaTime);
    } else {
      transform.position = transform.position;
    }
  }
}
