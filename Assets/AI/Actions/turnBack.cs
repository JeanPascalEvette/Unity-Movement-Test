using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class turnBack : RAINAction
{
    private Vector3 turnTarget = new Vector3(0,0,99);

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        if(turnTarget == new Vector3(0,0,99))
        {
            var direction = ai.Body.GetComponent<Transform>().forward;
            turnTarget = ai.Body.GetComponent<Transform>().position - direction;
        }

        ai.Body.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);


        ai.Motor.FaceAt(turnTarget);
        if (ai.Motor.IsFacing(turnTarget))
        {
            turnTarget = new Vector3(0, 0, 99);
            return ActionResult.SUCCESS;
        }

        return ActionResult.RUNNING;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}