using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Health
{
    // Start is called before the first frame update

    float getHealth();
    float getMaxHealth();
    void damage(float damageToTake, myEnums.damageType damageType,Transform damageSourcePosition);

    void onDeath();
 
  
}
