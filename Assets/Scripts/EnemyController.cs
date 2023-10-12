using UnityEngine;
// KasperVarje

public class EnemyController : MonoBehaviour
{
    // detection alueen koko voidaan säätää myös unity projektissa
    public float detectionRadius = 10.0f;
    public float detectionAngle = 90.0f;

    private void Update()
    {
        LookForPlayer();
    }

    private PlayerMovement LookForPlayer()
    {
        if (PlayerMovement.Instance == null)
        {
            return null;
        }

        Vector3 enemyPosition = transform.position;
        Vector3 toPlayer = PlayerMovement.Instance.transform.position - enemyPosition;
        toPlayer.y = 0;

        if (toPlayer.magnitude <= detectionRadius)
        {
            if (Vector3.Dot(toPlayer.normalized, transform.forward) >
                Mathf.Cos(detectionAngle * 0.5f * Mathf.Deg2Rad))
            {
                Debug.Log("Pelaaja on havaittu!");
                return PlayerMovement.Instance;
            }
        }


        return null;
    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Color c = new Color(0.8f, 0, 0, 0.4f);
        UnityEditor.Handles.color = c;

        Vector3 rotatedForward = Quaternion.Euler(
            0,
            -detectionAngle * 0.5f,
            0) * transform.forward;

        UnityEditor.Handles.DrawSolidArc(
            transform.position,
            Vector3.up,
            rotatedForward,
            detectionAngle,
            detectionRadius);

    }
#endif
}
