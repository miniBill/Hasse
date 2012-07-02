using System;

namespace Hasse{
	public static class MyMath{
		public static uint Pow(uint x, uint exp){
			if(exp == 0)
				return 1;

			uint result = 1;
			while(exp > 0){
				if((exp & 1) != 0)
					result *= x;
				x *= x;
				exp /= 2;
			}
			return result;
		}
	}
}
