using UnityEngine;

namespace PlayerSystem
{
    public class Movement
    {
        public void Move(Rigidbody rb, Transform orientation, float speed, Vector3 dir)
        {
            Vector3 moveDir = orientation.forward * dir.y + orientation.right * dir.x;
            rb.AddForce(moveDir.normalized * speed, ForceMode.Force);
        }
    }
}