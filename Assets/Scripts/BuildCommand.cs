using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCommand : Command
{
    public TileDisplay where;
    public GameObject what;

    public override void Execute()
    {
        where.Build(what);
    }
}
