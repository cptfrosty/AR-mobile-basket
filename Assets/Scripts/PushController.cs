using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushController : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform spawnPoint;

    public List<GameObject> bullets = new List<GameObject>();

    private void Start()
    {
        bullets.Clear();

        for(int i = 0; i < 30; i++)
        {
            GameObject go = Instantiate(prefabBullet, transform.position, Quaternion.identity);
            go.SetActive(false);

            bullets.Add(go);
        }
    }

    public void Push()
    {
        GameObject go = null;
        for (int i = 0; i < 30; i++)
        {
            if (!bullets[i].activeSelf)
            {
                go = bullets[i];
                break;
            }
        }
        if (go != null)
        {
            go.transform.position = spawnPoint.position;
            go.SetActive(true);
            //go.transform.rotation = Quaternion.
            go.GetComponent<Rigidbody>().AddForce(transform.forward * ProgrammManager.force, ForceMode.Impulse);
        }
    }
}
