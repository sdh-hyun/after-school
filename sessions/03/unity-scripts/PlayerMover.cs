using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) x -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) x += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) y -= 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) y += 1f;

        Vector3 direction = new Vector3(x, y, 0f).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
