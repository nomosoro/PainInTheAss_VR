using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities{
	public class ArrayHelpers{
		public static T GetRandomValue<T>(T[] array){
			if (array == null || array.Length == 0) {
				return default(T);
			}
			return array[Random.Range(0,array.Length)];
		}
	}

}
