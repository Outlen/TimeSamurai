using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRetreatEnemy : MonoBehaviour {
  public float speed = 4;
  public GameObject player;
  public Transform target;
  public float range = 40;
  public float minDistance = 20;
  public State state = State.Hunting;

  public enum State {
    Hunting,
    Fleeing,
    Shooting,
  }

  void Start() {
    player = GameObject.Find("Player");
    target = player.transform;
  }

  void Update() {
    switch (state) {
    case State.Hunting:
      if (Vector2.Distance(transform.position, target.position) < minDistance) {
        state = State.Fleeing;
      } else if (Vector2.Distance(transform.position, target.position) <
                 range) {
        state = State.Shooting;
      } else if (Vector2.Distance(transform.position, target.position) >
                 range) {
        transform.position = Vector3.MoveTowards(
            transform.position, target.position, speed * Time.deltaTime);
      }
      break;
    case State.Fleeing:
      if (Vector2.Distance(transform.position, target.position) > minDistance) {
        state = State.Hunting;
      } else {
        transform.position = Vector3.MoveTowards(
            transform.position, target.position, -speed * Time.deltaTime);
      }
      break;
    case State.Shooting:
      state = State.Hunting;
      break;
    default:
      break;
    }

    // if (state != State.Hunting &&
    //     Vector2.Distance(transform.position, target.position) > range) {
    // } else {
    //   state = State.Shooting;
    //   // StartCoroutine(melee());
    // }
  }
  // IEnumerator melee() { yield return new WaitFor; }
}
//   void Update() {
//     // prevent going to close
//     // if (Vector2.Distance(transform.position, target.position) <
//     minDistance)
//     // { transform.position = Vector2.MoveTowards(
//     //     transform.position, target.position, speed * Time.deltaTime);
//     if (Vector2.Distance(transform.position, target.position) <
//         shootingRange) { // outside of range
//       transform.position = Vector2.MoveTowards(
//           transform.position, target.position, speed * Time.deltaTime);
//     } else { // hold position
//       // transform.position =
//       //     Vector2.MoveTowards(transform.position, target.position, 0);
//     }
//   }
// }
