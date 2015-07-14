using UnityEngine;
using System.Collections;

public class CreatureAI : Creature {

  private CreaturePlayer player;
  public float slowRange = 4.0f;
  public float stopRange = 2.0f;
  public float startHeight = 1.0f;

  private Vector3 avgMove;
  private float avgTime = 1.0f;

	void Start ()
  {
    player = FindObjectOfType<CreaturePlayer>();
	}

  void OnEnable()
  {
    base.OnEnable();
    GameData.enemies.Add(this);
  }

  void OnDisable()
  {
    GameData.enemies.Remove(this);
  }
	
	void Update ()
  {
    if (TimeManager.Instance.IsPaused())
    {
      return;
    }

    if (!IsDead && player  != null && !player.IsDead)
    {
      Vector3 dirToPlayer = player.transform.position - transform.position;
      float dist = dirToPlayer.magnitude;
      dirToPlayer.Normalize();

      if (dist < stopRange)
      {
        dirToPlayer *= 0.01f;
      }

      if (dist < slowRange)
      {
        dirToPlayer *= dist / slowRange;
      }
      dirToPlayer.y = 0.0f;

      float newTime = avgTime + Time.deltaTime * GameData.moveSpeed;
      avgMove = (avgMove * avgTime + dirToPlayer * Time.deltaTime * GameData.moveSpeed) / newTime;

      Move(avgMove, GameData.moveSpeed);
    }
	}
}
