using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {
  public float speed = 4;
  public GameObject player;
  public Transform target;
  public float range = 3;
  public State state = State.Hunting;

  public enum State {
    Hunting,
    Attacking,
  }

  void Start() {
    player = GameObject.Find("Player");
    target = player.transform;
  }

  void Update() {
    switch (state) {
    case State.Hunting:
      if (Vector2.Distance(transform.position, target.position) < range) {
        state = State.Attacking;
      } else if (Vector2.Distance(transform.position, target.position) >
                 range) {
        transform.position = Vector3.MoveTowards(
            transform.position, target.position, speed * Time.deltaTime);
      }
      break;
    case State.Attacking:
      state = State.Hunting;
      break;
    default:
      break;
    }
  }
}
