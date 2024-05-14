using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SphereRay : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public float rayDistance = 5f;
    [SerializeField] private GameObject aimPoint;
    private Vector3 originalAimPointPosition;
    public ArmsMenuController armsMenuController;

    public float dwellTime = 2f; // Dwell time in seconds
    private bool isDwelling = false; // Flag to track if dwelling is in progress
    private float dwellTimer = 0f; // Timer for tracking dwell time

    private bool isMenuHovered = false;

    [SerializeField]
    private GameObject gunOne;
    [SerializeField]
    private GameObject gunTwo;
    [SerializeField]
    private GameObject gunThree;
    [SerializeField]
    private GameObject enemyHalo;

    public static bool enemyIsPointed = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.13f;
        lineRenderer.endWidth = 0.13f;

        originalAimPointPosition = aimPoint.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + transform.forward * rayDistance);

        //Delete from hereon to go back to the latest update
        // Perform raycast to detect object interaction
        //Vector3.Distance(transform.position, transform.position + transform.forward * rayDistance)
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (transform.forward * rayDistance).normalized, out hit, rayDistance))
        {
            // If the ray hits an object
            Debug.Log("Hit object: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "Mummy_Monster_Red(Clone)" || hit.collider.gameObject.name == "Mummy_Monster_Blue(Clone)" || hit.collider.gameObject.name == "Mummy_Monster_Green(Clone)" || 
                hit.collider.gameObject.name == "Oppy_Red(Clone)" || hit.collider.gameObject.name == "Oppy_Blue(Clone)" || hit.collider.gameObject.name == "Oppy_Green(Clone)")
            {
                // Do something with the hit object, for example:
                Debug.Log("Enemy Tag is being pointed");
                Vector3 diffVector = new Vector3(0f, 0.2f, 0f);
                aimPoint.transform.position = hit.collider.gameObject.transform.position + diffVector;
                enemyIsPointed = true;
                enemyHalo.SetActive(true);
            }
            else
            {
                aimPoint.transform.localPosition = originalAimPointPosition;
                enemyIsPointed = false;
                enemyHalo.SetActive(false);
            }

            if (hit.collider.gameObject.name == "GunsMenu" || hit.collider.gameObject.name == "MenuItem1" || hit.collider.gameObject.name == "MenuItem2" || hit.collider.gameObject.name == "MenuItem3")
            {
                //armsMenuController.MoveOnHover();
                armsMenuController.SetActiveMenuItems();
                if (hit.collider.gameObject.name == "MenuItem1")
                {

                    Debug.Log("MenuItem1 is being selected");
                    // Start dwelling
                    if (!isDwelling)
                    {
                        isDwelling = true;
                        dwellTimer = 0f;
                    }
                    else
                    {
                        // Update dwell timer
                        dwellTimer += Time.deltaTime;

                        if (dwellTimer >= dwellTime - 1f)
                        {
                            hit.collider.gameObject.GetComponent<Animator>().Play("SelectionBlink");
                        }
                        // Check if dwell time is reached
                        if (dwellTimer >= dwellTime)
                        {
                            // Call the "Arms" function
                            
                            GunOne();
                            armsMenuController.SetInactiveMenuItems();

                            // Reset dwelling state
                            isDwelling = false;
                            dwellTimer = 0f;
                        }
                    }
                }
                else if (hit.collider.gameObject.name == "MenuItem2")
                {
                    Debug.Log("MenuItem2 is being selected");
                    // Start dwelling
                    if (!isDwelling)
                    {
                        isDwelling = true;
                        dwellTimer = 0f;
                    }
                    else
                    {
                        // Update dwell timer
                        dwellTimer += Time.deltaTime;

                        if (dwellTimer >= dwellTime - 1f)
                        {
                            hit.collider.gameObject.GetComponent<Animator>().Play("SelectionBlink");
                        }
                        // Check if dwell time is reached
                        if (dwellTimer >= dwellTime)
                        {
                            // Call the "Arms" function
                            GunTwo();
                            armsMenuController.SetInactiveMenuItems();

                            // Reset dwelling state
                            isDwelling = false;
                            dwellTimer = 0f;
                        }
                    }
                }
                else if (hit.collider.gameObject.name == "MenuItem3")
                {
                    Debug.Log("MenuItem3 is being selected");
                    // Start dwelling
                    if (!isDwelling)
                    {
                        isDwelling = true;
                        dwellTimer = 0f;
                    }
                    else
                    {
                        // Update dwell timer
                        dwellTimer += Time.deltaTime;

                        if (dwellTimer >= dwellTime - 1f)
                        {
                            hit.collider.gameObject.GetComponent<Animator>().Play("SelectionBlink");
                        }
                        // Check if dwell time is reached
                        if (dwellTimer >= dwellTime)
                        {
                            // Call the "Arms" function
                            GunThree();
                            armsMenuController.SetInactiveMenuItems();

                            // Reset dwelling state
                            isDwelling = false;
                            dwellTimer = 0f;
                        }
                    }
                }




            }
            else
            {
                // If the raycast doesn't hit anything, cancel the waiting
                armsMenuController.SetInactiveMenuItems();  
            }
        }
    }

    void GunOne()
    {
        gunOne.SetActive(true);
        gunTwo.SetActive(false);
        gunThree.SetActive(false);
    }

    void GunTwo()
    {
        gunOne.SetActive(false);
        gunTwo.SetActive(true);
        gunThree.SetActive(false);
    }

    void GunThree()
    {
        gunOne.SetActive(false);
        gunTwo.SetActive(false);
        gunThree.SetActive(true);
    }
}
