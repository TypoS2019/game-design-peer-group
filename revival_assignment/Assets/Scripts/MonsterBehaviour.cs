using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField] private PlantBehaviour targetPlant;
    [SerializeField] private float reachDistance;
    [SerializeField] private float corruptTime;
    [SerializeField] private float speed;
    private Transform monsterTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        monsterTransform = GetComponent<Transform>();
        StartCoroutine(Search());
    }
    
    private IEnumerator Walk()
    {
        Vector3 targetPoint = targetPlant.transform.position;
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            if (Vector2.Distance(targetPoint, monsterTransform.position) <= reachDistance)
            {
                StartCoroutine(Corrupt());
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator Corrupt()
    {
        yield return new WaitForSeconds(corruptTime);
        targetPlant.Corrupt();
        targetPlant = null;
        StartCoroutine(Search());
        yield break;
    }

    private IEnumerator Search()
    {
        while (targetPlant == null)
        {
            PlantBehaviour[] plantBehaviours = GameObject.FindObjectsOfType<PlantBehaviour>();
            PlantBehaviour closestAlivePlant = null;
            float closestDistance = 0;
            foreach (var plant in plantBehaviours)
            {
                if (!plant.dead)
                {
                    float distance = Vector2.Distance(plant.transform.position, monsterTransform.position);
                    if (closestAlivePlant == null || closestDistance > distance)
                    {
                        closestDistance = distance;
                        closestAlivePlant = plant;
                    }
                }
            }
            targetPlant = closestAlivePlant;
            yield return null;
        }

        StartCoroutine(Walk());
    }
}
