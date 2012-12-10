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

	    public static uint Factorial(uint n){
	        uint toret = 1;
	        while(n > 1)
	            toret *= n--;
	        return toret;
	    }
	}
}
