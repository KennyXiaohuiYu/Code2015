uint32_t reverseBits(uint32_t n) {
    uint32_t iMin = 1;
	    uint32_t iMax = (uint32_t) 0x80000000;// 2147483648;
	    uint32_t ret = 0;
        for (int i=0;i<32;i++)
        {
        	uint32_t t = n & iMin;
            if (t>0)
               ret |= iMax;
            iMin <<= 1;
            iMax >>= 1;
        }
        return ret;
}
