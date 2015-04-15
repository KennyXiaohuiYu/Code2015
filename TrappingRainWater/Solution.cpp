class Solution {
public:
    int trap(int A[], int n) {
        int iPrevTop = -1;
	int iPrevTopPos = 0;
	int iCurrentTop = 0;
	int iCurrentTopPos = 0;
	int iTopCount = 0;
	int nRet = 0;
	int l1 = -1, i = 0;
	while (i < n) {
		while (A[i] >= l1 && i < n) {
			l1 = A[i];
			i++;
		}
		iCurrentTopPos = i - 1;
		iCurrentTop = A[iCurrentTopPos];
		if (iPrevTopPos < iCurrentTopPos) {
			int limit = std::min(iPrevTop, iCurrentTop);
			for (int j = iPrevTopPos + 1; j < iCurrentTopPos; j++) {
				int delta = limit - A[j];
				if (delta > 0) {
					nRet += delta;
					A[j] = limit;
				}
			}
		}
		if (i == n)
			break;
		iPrevTop = iCurrentTop;
		iPrevTopPos = iCurrentTopPos;
		l1 = iCurrentTop;
		while (i < n && A[i] <= l1) {
			l1 = A[i];
			i++;
		}
		if (i == n)
			break;
		iTopCount++;
	}
	if (iTopCount > 1)
		nRet += trap(A, n);

	return nRet;
    }
};

