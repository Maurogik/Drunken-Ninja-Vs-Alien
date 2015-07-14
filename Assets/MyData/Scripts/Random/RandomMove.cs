using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {

  private CreaturePart creaturePart = null;

  void OnEnable() 
  {
    creaturePart = GetComponent<CreaturePart>();
  }

  protected float getSpeed()
  {
    BodyPart bodyPart = creaturePart.bodyPart;
    return GameData.speed * GameData.GetSpeedModifier(bodyPart, creaturePart.creature.state);
  }
}
