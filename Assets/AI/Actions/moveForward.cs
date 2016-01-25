using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class moveForward : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        float rotation = 0;
        Vector3 axis = new Vector3(0, 1, 0);
        ai.Body.GetComponent<Rigidbody>().rotation.ToAngleAxis(out rotation, out axis);

        float direction = -1;
        if (rotation > 90.0f - 3.0f && rotation < 90.0f + 3.0f)
            direction = 1;

        ai.Body.GetComponent<Rigidbody>().velocity = new Vector3(direction * 2.0f, ai.Body.GetComponent<Rigidbody>().velocity.y, ai.Body.GetComponent<Rigidbody>().velocity.z);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}