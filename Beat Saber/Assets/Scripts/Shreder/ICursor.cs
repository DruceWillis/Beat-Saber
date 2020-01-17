using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICursor
{
    float alpha {get; set;}
    bool inLowerPart {get; set;}
    Vector3 point {get; set;}    
}
