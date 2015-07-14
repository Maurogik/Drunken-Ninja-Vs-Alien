using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

  public GameObject spawners;
  public TextMesh text;
  public int duration = 3;

	// Use this for initialization
	void Start () {
    StartCoroutine(count());
	}

  private IEnumerator count()
  {
    spawners.SetActive(false);
    while (duration > 0)
    {
      text.text = duration.ToString() + "...";
      --duration;
      yield return new WaitForSeconds(1.0f);
    }
    spawners.SetActive(true);
    //duration == 0
    text.text = "Survive !";
    yield return new WaitForSeconds(1.0f);
    text.text = "";
  }
}
