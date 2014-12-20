using UnityEngine;
using System.Collections;

public class TreeChopperController : MonoBehaviour 
{
    public enum Status
    {
        Growing, 
        FullGrown, 
        Dying,
        Dead
    }

    public static TreeChopperController controller;

    public static int rows = 4;
    public static int columns = 3;

    public static float growthTime = 10f;
    public static float fullGrownPeriod = 5f;
    public static float deathTime = 5f;

    public float score = 1f;
    public int level = 1;

    public Color growingColor, fullGrownColor, dyingColor, deadColor;
    public GameObject fullGrownAudio;
    public GameObject growingAudio;
    public GameObject dyingAudio;
    GameObject currentTree;

    public ParticleSystem treeParticles;
    float stopParticles;
    float particleDelay = 1f;

	void Start () 
    {
        fullGrownAudio = Instantiate(Resources.Load("Audio/FullGrownTreeSound", typeof(GameObject))) as GameObject;
        growingAudio =Instantiate( Resources.Load("Audio/GrowingTreeSound", typeof(GameObject))) as GameObject;
        dyingAudio = Instantiate(Resources.Load("Audio/DyingTreeSound", typeof(GameObject))) as GameObject;
        controller = this;
        currentTree = new GameObject();
	}

    public bool sound;
	void Update () 
    {

        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
                if (hit.collider != null)
                {
                    switch (hit.collider.gameObject.GetComponent<Tree>().status)
                    {
                        case TreeChopperController.Status.Growing:
                            {
                                score += 1f;
                                growingAudio.audio.Play();
                                break;
                            }
                        case TreeChopperController.Status.FullGrown:
                            {
                                score += 10f;
                                fullGrownAudio.audio.Play();
                                break;
                            }
                        case TreeChopperController.Status.Dying:
                            {
                                score -= 5f;
                                dyingAudio.audio.Play();
                                break;
                            }
                        case TreeChopperController.Status.Dead: break;
                    }
                    hit.collider.gameObject.GetComponent<Tree>().status = TreeChopperController.Status.Dead;
                    hit.collider.gameObject.SetActive(false);

                    treeParticles.transform.position = hit.collider.gameObject.transform.position;
                    treeParticles.Play();
                    stopParticles += particleDelay;

                    currentTree = hit.collider.gameObject;
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                switch (hit.collider.gameObject.GetComponent<Tree>().status)
                {
                    case TreeChopperController.Status.Growing:
                        {
                            score += 1f;
                            growingAudio.audio.Play();
                            break;
                        }
                    case TreeChopperController.Status.FullGrown:
                        {
                            score += 10f;
                            fullGrownAudio.audio.Play(); 
                            break;
                        }
                    case TreeChopperController.Status.Dying:
                        {
                            score -= 5f;
                            dyingAudio.audio.Play();
                            break;
                        }
                    case TreeChopperController.Status.Dead: break;
                }
                hit.collider.gameObject.GetComponent<Tree>().status = TreeChopperController.Status.Dead;
                hit.collider.gameObject.SetActive(false);

                treeParticles.transform.position = hit.collider.gameObject.transform.position;
                treeParticles.Play();
                stopParticles = Time.time + particleDelay;

                currentTree = hit.collider.gameObject;
            }
        }

        currentTree.SetActive(true);
        if (Time.time > stopParticles) treeParticles.Stop();
	}
}
