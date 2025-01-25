using UnityEngine;

namespace MyGameNamespace
{
    public class PlayerDash : MonoBehaviour
    {
        public float dashSpeed = 15f; // Speed at the start of the dash
        public float dashDuration = 0.5f; // How long the dash lasts
        public float dashCooldown = 1f; // Cooldown time before dashing again

        private float lastDashTime;
        private bool isDashing = false;
        private float dashStartTime;
        private Rigidbody2D rb;
        private float currentSpeed;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            HandleDash();
        }

        void HandleDash()
        {
            //Add condition connected to State such as that how many dashes left
            //before decrement a state
            //no more dash can be done

            //Nothing happens if State is at 1 (lowest)
            if (Input.GetMouseButtonDown(1) && Time.time >= lastDashTime + dashCooldown)
            {
                StartDash();
            }

            if (isDashing)
            {
                UpdateDash();
            }
        }

        void StartDash()
        {
            isDashing = true;
            lastDashTime = Time.time;
            dashStartTime = Time.time;
            currentSpeed = dashSpeed; // Start at dashSpeed

            // Optional: Add a visual effect or sound here
        }

        void UpdateDash()
        {
            float elapsed = Time.time - dashStartTime;
            float t = elapsed / dashDuration;

            // Interpolate speed from dashSpeed to 0 over the duration of the dash
            currentSpeed = Mathf.Lerp(dashSpeed, 0, t);

            // End the dash if the duration has passed
            if (elapsed >= dashDuration)
            {
                EndDash();
                return;
            }

            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Set z to 0 for 2D

            // Calculate the direction from the player to the mouse position
            Vector2 direction = (mousePosition - transform.position).normalized;

            // Apply the current speed to the player's movement
            rb.linearVelocity = direction * currentSpeed;
        }

        void EndDash()
        {
            isDashing = false;
            rb.linearVelocity = Vector2.zero; // Stop the player after dashing
        }
    }
}