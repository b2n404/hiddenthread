// MyCharacter.cs - how to get input from Rewired.Player

using UnityEngine;
using System.Collections;
//using AC;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
public Rigidbody rb;
// The Rewired player id of this character
public int playerId = 0;

// The movement speed of this character
public float moveSpeed = 3.0f;

public float jumpForce;
public float impactVelocity;

// The bullet speed
public float bulletSpeed = 15.0f;

// Assign a prefab to this in the inspector.
// The prefab must have a Rigidbody componet on it in order to work.

public GameObject bulletPrefab;

//private Player player; // The Rewired Player//
private CharacterController cc;
private Vector3 moveVector;
private bool fire;

private void Awake()
{
    //Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
    //player = ReInput.players.GetPlayer(playerId);//

    // Get the character controller
    cc = GetComponent<CharacterController>();
}

void Update()
{
    GetInput();
    ProcessInput();
}

private void GetInput()
{
    // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
    // whetther the input is coming from a joystick, the keyboard, mouse, or a custom controller.

    // moveVector.x = player.GetAxis("Horizontal"); // get input by name or action id
    // moveVector.y = player.GetAxis("Vertical");
    // fire = player.GetButtonDown("Fire");
}

private void ProcessInput()
{
    // Process movement
    if(moveVector.x != 0.0f || moveVector.y != 0.0f)
    {
        cc.Move(moveVector * moveSpeed * Time.deltaTime);
    }

    // Process fire
    if (fire)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + transform.right, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.right * bulletSpeed, ForceMode.VelocityChange);
    }

    // Process jump
    // if(player.GetButtonDown("Jump"))
    // {
    //     rb.AddForce(Vector3.up * jumpForce);
    // }
}
}