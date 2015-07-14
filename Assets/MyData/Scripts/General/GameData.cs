using UnityEngine;
using System.Collections.Generic;


public enum BodyPart
{
  LEG,
  ARM,
  BODY,
  HEAD
}

public enum CreatureState
{
  RUNNING,
  WALKING,
  IDLE
}

public class GameData : MonoBehaviour {

  private static float[,] partSpeeds = 
  {
    { 2.0f, 1.5f, 1.5f, 1.5f },
    { 1.0f, 1.0f, 0.8f, 1.0f },
    { 0.3f, 0.6f, 0.3f, 0.4f }
  };

  public static bool cheatOn = false;
  public static bool playerAlive = true;
  public static int score = 0;
  public static float speed = 1.0f;
  public static float moveSpeed = 5.0f;
  public static bool running = false;
  public static bool reloadingLevel = false;

  public static List<Creature> enemies = new List<Creature>();
  public static Creature closestEnemy = null;

  public static float GetSpeedModifier(BodyPart part, CreatureState state)
  {
    float res = partSpeeds[(int)state, (int)part];
    return res;
  }

  public static GameObject[] weaponsPrefab;
  public static CurvePrefab[] curvesPrefab;
  public static GameObject hitParticlePrefab;
  public static GameObject deathParticlePrefab;
  public static GameObject dripParticlePrefab;

  public GameObject[] _weaponsPrefab;
  public CurvePrefab[] _curvesPrefab;
  public GameObject _hitParticlePrefab;
  public GameObject _deathParticlePrefab;
  public GameObject _dripParticlePrefab;

  void Awake()
  {
    curvesPrefab = _curvesPrefab;
    weaponsPrefab = _weaponsPrefab;
    hitParticlePrefab = _hitParticlePrefab;
    deathParticlePrefab = _deathParticlePrefab;
    dripParticlePrefab = _dripParticlePrefab;
    reloadingLevel = false;
    score = 0;
    playerAlive = true;
  }
	
}
