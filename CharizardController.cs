using UnityEngine;

public class CharizardController : MonoBehaviour
{
    [SerializeField] private float speed;

    private FixedJoystick fixedJoystick;
    private Rigidbody rigidBody;
    private Animator animationController;
    private bool isFlying = false;

    private void OnEnable()
    {
        fixedJoystick = FindFirstObjectByType<FixedJoystick>();
        rigidBody = GetComponent<Rigidbody>();
        animationController = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        Vector3 movement = new Vector3(xVal, 0, yVal);

        // ✅ Correct velocity
        rigidBody.velocity = movement * speed;

        // ✅ Rotation (even if moving slightly)
        if (movement.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, angle, 0);

            if (!isFlying)
            {
                animationController.SetBool("flyParam", true);
                isFlying = true;
            }
        }
        else
        {
            if (isFlying)
            {
                animationController.SetBool("flyParam", false);
                isFlying = false;
            }
        }
    }
}