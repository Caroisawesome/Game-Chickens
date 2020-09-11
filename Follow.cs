using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject playerObj;
    private Vector3 direction;
    private float distance;
    private float maxSight;
    private float stepSize;
    private float followRadius;

    // Start is called before the first frame update
    void Start()
    {
        maxSight=6;
        followRadius=2;
        stepSize=5.0f;
    }

    Vector3 goTowardsObject() {
        distance = Vector3.Distance(playerObj.transform.position, transform.position);

        if (distance > followRadius && distance < maxSight) {
            direction = (playerObj.transform.position - transform.position)/(float)distance;
        } else {
            direction = Vector3.zero;
        }

        return direction;
    }

    // Update is called once per frame
    void Update()
    {

        float randomVal = Random.Range(0.0f, 1.0f);
        Vector3 direction;

        // have random property that chooses whether to go towards mother duck, or other duckling.
        if (randomVal > 0.7) {
            // go towards mother duck
            playerObj = GameObject.Find("Player");
            direction = goTowardsObject();
        } else if (randomVal > 0.6) {
            // go towards other duckling
            playerObj = GameObject.Find("Duckling"+Random.Range(1,4).ToString());
            direction = goTowardsObject();
        } else if (randomVal > 0.5 ) {
            // go in a random direction
            Vector3 randDirection = Random.insideUnitCircle;
            direction = new Vector3(randDirection.x, 0, randDirection.y);
        } else { 
            // don't move
            direction = Vector3.zero;
        }

        if (direction != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(stepSize * Time.deltaTime * -1*direction);
        }
    }
}
