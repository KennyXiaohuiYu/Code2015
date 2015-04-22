

class Solution {
public:
    int rob(vector<int> &num) {
        numList = num;    
        length = numList.size();
        cacheList.reserve(length);
        for (int i=0; i<length; i++)
            cacheList[i] = -1;
        return Rob(0);
    }
    
private:
    vector<int> numList;
    int length = 0;
    vector<int> cacheList;
    
    int Rob(int iStartIndex)
    {
        if (iStartIndex < length)
        {
            if (cacheList[iStartIndex] < 0)
                cacheList[iStartIndex] = max(Rob(iStartIndex+1), numList[iStartIndex] + Rob(iStartIndex+2));
            return cacheList[iStartIndex];
        }
        
        return 0;
    }
};

