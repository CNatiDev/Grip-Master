using UnityEngine;

public class LimitArmStretch : MonoBehaviour
{
    private ConfigurableJoint joint;

    [SerializeField]
    private float maxXLimit = 45f; // Valoarea limită maximă pe axa X

    [SerializeField]
    private float maxYLimit = 45f; // Valoarea limită maximă pe axa Y

    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();

        // Setează mișcarea limitată pe axele X și Y
        joint.angularXMotion = ConfigurableJointMotion.Limited;
        joint.angularYMotion = ConfigurableJointMotion.Limited;

        // Setează limitele de rotație pentru axa X
        SoftJointLimit limitX = new SoftJointLimit();
        limitX.limit = maxXLimit;
        joint.lowAngularXLimit = limitX;
        joint.highAngularXLimit = limitX;

        // Setează limitele de rotație pentru axa Y
        SoftJointLimit limitY = new SoftJointLimit();
        limitY.limit = maxYLimit;
        joint.angularYLimit = limitY;
    }
}
