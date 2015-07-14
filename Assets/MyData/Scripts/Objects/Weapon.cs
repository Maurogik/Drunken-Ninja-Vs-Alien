using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

  public Creature owner = null;
  private float damagePetHit = 15.0f;
  private Vector3 lastPos;
  private Vector3 currentPos;

  void Update()
  {
    lastPos = currentPos;
    currentPos = transform.position;
  }

  void OnTriggerEnter(Collider other)
  {
    CreaturePart creaturePart = other.GetComponent<CreaturePart>();
    if (creaturePart != null 
      && creaturePart.creature != owner
      && gameObject.layer != other.gameObject.layer
      && !owner.IsDead
      && !creaturePart.creature.IsDead
      && (creaturePart.bodyPart == BodyPart.BODY || creaturePart.bodyPart == BodyPart.HEAD))
    {
      if (GameData.cheatOn && creaturePart.creature.gameObject.layer == LayerMask.NameToLayer("Player"))
      {
        return;
      }
      owner.nbHits += 1;
      creaturePart.creature.health -= damagePetHit;
      if (creaturePart.bodyPart == BodyPart.HEAD)
      {
        creaturePart.creature.health = 0;
      }

      if (creaturePart.creature.health < 0)
      {
        creaturePart.creature.health = 0;
        owner.nbKills += 1;
        GameObject deathParticles = InstanceManager.InstantiateObject(GameData.deathParticlePrefab);
        deathParticles.transform.parent = creaturePart.transform;
        deathParticles.transform.localPosition = Vector3.zero;
        Destroy(deathParticles, 10.0f);
        other.collider.enabled = false;
        creaturePart.creature.IsDead = true;
        Destroy(creaturePart.creature.gameObject, 8.0f);

        TimeManager.Instance.BulletTimeDeath();

        return;
      }

      Vector3 point = Vector3.Lerp(transform.position, other.transform.position, 0.5f);
      Vector3 weaponDirection = currentPos - lastPos;
      weaponDirection.Normalize();

      GameObject bloodParticles = InstanceManager.InstantiateObject(GameData.hitParticlePrefab, point, Quaternion.identity);
      bloodParticles.transform.LookAt(point + weaponDirection);
      Destroy(bloodParticles, 4.0f);

      GameObject dripParticles = Instantiate(GameData.dripParticlePrefab) as GameObject;
      dripParticles.transform.parent = creaturePart.transform;
      dripParticles.transform.localPosition = Vector3.zero;
      Destroy(dripParticles, 10.0f);

      TimeManager.Instance.BulletTimeHit();
    }
  }
}
