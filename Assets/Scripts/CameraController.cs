using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Raum Kamera
    [SerializeField]private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Player Kamera
    [SerializeField]private Transform player;
    [SerializeField]private float aheadDistance;
    [SerializeField]private float cameraspeed;
    private float lookAhead;


    private void Update()
    {
        //Raum Kamera
        //transform.position = Vector3.SmoothDamp(transform.position, 
        //new Vector3(currentPosX, transform.position.y, transform.position.z), 
        //ref velocity, 
        //speed);

        //Player verfolgen
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraspeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }


}
