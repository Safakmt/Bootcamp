using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManage : MonoBehaviour
{

    public List<GameObject> BirdQueue = new List<GameObject>();
    [SerializeField]
    private CamControl camController;
    private GameObject player;
    public bool lose = false;
    private void Start()
    {
        setNewBird();
    }

    private void Update()
    {
        if (player == null && BirdQueue.Count != 0)
        {
            setNewBird();
            camController.SwitchToBird();
        }
        else if (player == null && BirdQueue.Count == 0)
        {
            StartCoroutine(LoseState());

        }
    }

    void setNewBird()
    {
        player = Instantiate(BirdQueue[0], transform.position, Quaternion.identity);
        BirdQueue.RemoveAt(0);
        player.GetComponent<SpringJoint2D>().anchor.Set(transform.position.x, transform.position.y);
        player.GetComponent<SpringJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
        camController.setBirdCam(player);
    }
    IEnumerator LoseState()
    {
        yield return new WaitForSeconds(3.5f);
        lose = true;
    }
}
