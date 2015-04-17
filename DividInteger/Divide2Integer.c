/*
 * Divid2Integer.c
 *
 *  Created on: Apr 16, 2015
 *      Author: kenny
 *
 *  Divide two integers without using multiplication, division and mod operator.
 *
 *  If it is overflow, return MAX_INT.
 */
#include <stdio.h>
#include <limits.h>
#include <stdbool.h>

int divide(int dividend, int divisor) {
	int negZero = 0x80000000;
		if (divisor == 0)
			return INT_MAX;
		if (dividend == 0)
			return 0;
		bool bNeg = false;
		if ((dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0))
			bNeg = true;
		unsigned dividend2 = abs(dividend);
		unsigned divisor2 = abs(divisor);
		unsigned result = 0;
		int temp = 0;
		while (dividend2 > divisor2) {
			divisor2 <<= 1;
			temp++;
		}

		while (temp >= 0)
		{
			result <<= 1;
			if (dividend2 >= divisor2)
			{
				dividend2 -= divisor2;
				result++;
			}
			temp--;
			divisor2 >>= 1;
		}
		if (result > INT_MAX && !bNeg)
			return INT_MAX;
		if (bNeg)
			return -result;
		return (int)result;
}

int main() {
	return divide(-2147483648, -1);
}
