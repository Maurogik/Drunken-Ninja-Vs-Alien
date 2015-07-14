using UnityEngine;
using System.Collections;

public class CreaturePlayer : Creature {

  private bool wastedOn = false;
  public static CreaturePlayer Instance = null;

  void Awake()
  {
    Instance = this;
  }

  void Update()
  {
    if (TimeManager.Instance.IsPaused())
    {
      return;
    }

    if (IsDead)
    {
      if (!wastedOn)
      {
        GameData.playerAlive = false;
        GameData.score = (int)health / 3 + nbHits * 10 + nbKills * 30;
        UIMgr.Instance.GameUIRoot.SetSate("Wasted");
        wastedOn = true;
      }
      return;
    }

    Creature closest = null;
    foreach (Creature enemy in GameData.enemies)
    {
      if (closest == null 
        || Vector3.Distance(closest.transform.position, transform.position) 
          < 
          Vector3.Distance(enemy.transform.position, transform.position))
      {
        closest = enemy;
      }
    }

    GameData.closestEnemy = closest;

    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Vector3 move = new Vector3(h, 0.0f, v);
    Debug.DrawLine(transform.position, transform.position + move * GameData.moveSpeed, Color.red, 5.0f);
    int layerMask = 1 << LayerMask.NameToLayer("Side");
    float dist = Mathf.Max(0.1f, GameData.moveSpeed * Time.deltaTime * 2.0f);
    if (Physics.Raycast(transform.position, move, dist, layerMask))
    {
      Move(Vector3.zero, GameData.moveSpeed);
      //Debug.Log("Move hit a wall !");
      return;
    } 
    //Debug.Log("Not hitting a wall");

    Move(move, GameData.moveSpeed);

    if (move.sqrMagnitude > 0.8f * 0.8f)
    {
      //running
      state = CreatureState.RUNNING;
    }
    else if (move.sqrMagnitude == 0.0f)
    {
      //idle
      state = CreatureState.IDLE;
    }
    else
    {
      //walking
      state = CreatureState.WALKING;
    }
  }


  void OnDestroy()
  {
    if (IsDead && !GameData.reloadingLevel)
    {
      UIMgr.Instance.ShowMenu();
    }
  }
}
