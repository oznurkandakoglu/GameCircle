using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleControls : MonoBehaviour
{
    [SerializeField] GameObject collectible;
    [SerializeField] GameObject collected;
    [SerializeField] Transform collectingPoint;
    [SerializeField] GameObject collPoint;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] Animator _animator;
    List<GameObject> collectedObjects;
    Vector3 nextCollectingPoint;
    // Start is called before the first frame update
    void Start()
    {
        nextCollectingPoint = collectingPoint.transform.position;
        collectedObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nextCollectingPoint.x = collectingPoint.transform.position.x;
        nextCollectingPoint.z = collectingPoint.transform.position.z;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("collectible"))
        {
            collPoint.GetComponent<AudioSource>().PlayOneShot(explosionSound);
            GameObject go = Instantiate(collected, nextCollectingPoint, Quaternion.identity);
            collectedObjects.Add(go);
            go.transform.SetParent(collectingPoint);
            nextCollectingPoint.y += .2f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("finishLine"))
        {
            TouchControl.gameOver = true;
            _animator.SetBool("dance", true);
            GetComponent<AudioSource>().Stop();
            for (int i = 0; i < collectedObjects.Count; i++)
            {
                Destroy(collectedObjects[i]);
            }

            //WinPaneli Açýlacak.
        }
    }
}
