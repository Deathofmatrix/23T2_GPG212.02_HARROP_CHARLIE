using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PetGame
{
    public class DragAndDrop : MonoBehaviour
    {
        [SerializeField] private TargetJoint2D targetJoint;

        private Vector3 GetMouseWorldPosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void Awake()
        {
            targetJoint = GetComponent<TargetJoint2D>();
        }

        private void Start()
        {
            targetJoint.enabled = false;
        }

        private void OnMouseDown()
        {
            targetJoint.enabled = true;
            targetJoint.target = GetMouseWorldPosition();
        }

        private void OnMouseDrag()
        {
            targetJoint.target = GetMouseWorldPosition();
        }

        private void OnMouseUp()
        {
            targetJoint.enabled = false;
        }

        private void FixedUpdate()
        {
        }
    }
}
