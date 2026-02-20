using UnityEngine;
using UnityEngine.UIElements;

public class CameraControlExam06 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float offset;
    public Camera targetCamera;

    public float width;
    public float height;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 player1Pos = player1.transform.position;
        Vector3 player2Pos = player2.transform.position;

        // Student code ...
        width = (Mathf.Abs(player1Pos.x - player2Pos.x) / targetCamera.aspect) + offset;
        height = Mathf.Abs(player2Pos.z - player1Pos.z) + offset;
        targetCamera.transform.position = new Vector3((player1Pos.x + player2Pos.x)/2, 40, (player2Pos.z + player1Pos.z)/2);
        targetCamera.orthographicSize = Mathf.Max(width, height);

        
    }
}
