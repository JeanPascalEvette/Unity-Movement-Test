using RAIN.Entities.Aspects;
using RAIN.Perception.Sensors;
using RAIN.Serialization;
using UnityEngine;

[RAINSerializableClass]
public class GroundSensor : VisualSensor
{
    [RAINSerializableField]
    private LayerMask _physicsMask = -1;

    protected override bool TestVisibility(RAINAspect aAspect, float aSqrRange)
    {
        // Normal aspect test worked, we're done
        if (base.TestVisibility(aAspect, aSqrRange))
            return true;

        // Being a little pedantic about this, but just in case
        Transform tAspectTransform = aAspect.MountPoint;
        if (tAspectTransform == null)
            tAspectTransform = aAspect.Entity.Form.transform;


        // Do a physics check against the aspect, may need to add a mask for this
        RaycastHit myRaycastHit = new RaycastHit();
        Physics.Linecast(Position, Position + new Vector3(AI.Body.GetComponent<Transform>().forward.x * 0.49f, -0.6f, 0.0f), out myRaycastHit);
        // If the collider is a child (or equal to) our aspect, we're good
        if (myRaycastHit.collider != null && myRaycastHit.collider.transform.IsChildOf(tAspectTransform))
            return true;

        return false;
    }
}