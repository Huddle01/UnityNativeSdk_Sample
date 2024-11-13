using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    [SerializeField]
    private Transform _mainParent;

    public float overlapRadius = 0.5f; // Radius for checking platforms below

    private Transform platform;          // Current platform the character is on
    private Vector3 prePos;              // Previous position of the platform
    private ThirdPersonController characterMovement; // Reference to the character movement script

    void Start()
    {
        // Get reference to the CharacterMovement script on the same GameObject
        characterMovement = GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        // Use OverlapSphere to check for colliders within the specified radius below the character
        Collider[] colliders = Physics.OverlapSphere(transform.position + Vector3.down * overlapRadius, overlapRadius);

        // Check if any of the colliders are tagged as "Platform"
        platform = null; // Reset platform reference each frame
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("MovingPlatform"))
            {
                Debug.Log(collider.tag);
                platform = collider.transform;
                prePos = platform.position;

                // Notify CharacterMovement script of the new platform
                characterMovement.SetCurrentPlatform(platform, prePos);

                _mainParent.SetParent(platform);
                return;
            }
        }

        // If no platform is detected, clear the platform reference
        if (platform != null)
        {
            characterMovement.SetCurrentPlatform(null, Vector3.zero);
            platform = null;
        }
    }

    // Optional: Visualize the sphere in the Editor for debugging
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * overlapRadius, overlapRadius);
    }
}
