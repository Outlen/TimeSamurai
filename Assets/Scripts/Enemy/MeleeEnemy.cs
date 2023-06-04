using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {
  public float speed;
  public GameObject target;
  public float meleeRange = 2;

  void Start() {
    target = GameObject.Find("Player");
    speed = UnityEngine.Random.Range(1, 3);
  }

  void Update() {
    if (Vector2.Distance(transform.position, target.transform.position) >
        meleeRange) {
      transform.position =
          Vector2.MoveTowards(transform.position, target.transform.position,
                              speed * Time.deltaTime);
    } else {
      // transform.position = transform.position;
    }
  }
}
