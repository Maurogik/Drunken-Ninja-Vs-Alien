using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

  public float frontRotationCoef = 5.0f;
  public CreatureState state;
  public float health = 50.0f;
  public Color color = Color.black;
  public int nbKills = 0;
  public int nbHits = 0;

  private Transform bodyRoot;
  private float lastSpeed;
  private Quaternion targetQuat;
  private bool isDead = false;

  public bool IsDead
  {
    get { return isDead; }
    set { isDead = value; if (isDead)state = CreatureState.IDLE; }
  }

  protected void Move(Vector3 normalizedMove, float speed)
  {
    bodyRoot.LookAt(bodyRoot.position + normalizedMove);
    lastSpeed = normalizedMove.magnitude * speed;
    transform.position += normalizedMove * Time.deltaTime * speed;

    if (normalizedMove.sqrMagnitude != 0.0f)
    {
      Quaternion oldRot = transform.rotation;
      transform.LookAt(transform.position + normalizedMove);
      targetQuat = transform.rotation;
      transform.rotation = oldRot;
    }
  }

  protected void OnEnable()
  {
    foreach (CreaturePart part in  GetComponentsInChildren<CreaturePart>())
    {
      part.creature = this;
      if (part.bodyPart == BodyPart.BODY)
      {
        bodyRoot = part.transform;
      }
      LineRenderer line = part.GetComponent<LineRenderer>();
      if (line)
      {
        line.material.color = color;
      }
    }

    foreach (Weapon weapon in GetComponentsInChildren<Weapon>())
    {
      weapon.owner = this;
    }
  }

  void LateUpdate()
  {
    if (!isDead)
    {
      Quaternion look = Quaternion.Lerp(transform.rotation, targetQuat, 0.05f);
      transform.rotation = look;
      bodyRoot.localRotation = Quaternion.Euler(Vector3.right * lastSpeed * frontRotationCoef);
    }
    else
    {
      transform.position += Vector3.down * Time.deltaTime * GameData.moveSpeed * 0.1f;
    }
  }
}
