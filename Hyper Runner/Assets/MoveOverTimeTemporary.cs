using UnityEngine;

public class MoveOverTimeTemporary : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (transform.position + (Time.deltaTime * speed * Vector3.one));
    }
}
