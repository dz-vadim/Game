using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Power = 100;

    public TrajectoryRenderer Trajectory;

    private Camera mainCamera;
    Vector3 speed;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        float enter;
        Vector3 mouseRange;
        mouseRange = Input.mousePosition;
        
        if (mouseRange.y > mainCamera.pixelHeight / 2) mouseRange.y = mainCamera.pixelHeight / 2;
        Ray ray = mainCamera.ScreenPointToRay(mouseRange);
        RaycastHit hit;
        if ((Physics.Raycast(ray, out hit)) && (hit.collider.name == "Ground"))
        {
            new Plane(-Vector3.up, transform.position).Raycast(ray, out enter);
            Vector3 mouseInWorld = ray.GetPoint(enter);

            speed = (mouseInWorld - transform.position) * Power;
            transform.rotation = Quaternion.LookRotation(speed);
            Trajectory.ShowTrajectory(transform.position, mouseInWorld);           
        }
        if ((Input.GetMouseButtonUp(0))&&(GameObject.FindGameObjectWithTag("Ball")==null))
            {
                Rigidbody bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                bullet.AddForce(speed, ForceMode.VelocityChange);
            }
        
    }
}
