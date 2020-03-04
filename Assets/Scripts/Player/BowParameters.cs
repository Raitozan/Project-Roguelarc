﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType {Direct}; //Dot ? AoE ?


public static class BowParameters
{
	public static DamageType damageType;
	public static int damageAmount;
	public static float arrowSpeed;

	public static float attackSpeed;

	/*ideas:
	 * cross wall
	 * dot duration
	 * aoe range
	 * magnetic effect (ennemies attracted on impact)
	 * multi shot (2 diagonal and the central)
	 * homing shot
	 * big arrows (but slower)
	 * charging shot
	 * fragmenting shot
	*/
}
