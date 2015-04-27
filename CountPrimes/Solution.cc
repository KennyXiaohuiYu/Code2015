class Solution {
public:
    int countPrimes(int n) {
        bool primes [n];
        
        for (int i=2;i<n;i++)
            primes[i] = 1;
            
        int sqrtN = sqrt(n);
        
        for (int i=2; i<=sqrtN; i++)
        {
            if (primes[i]==1)
            {
                int j=2;
                int k=i*j;
                while (k<n)
                {
                    primes[k]=0;  
                    k=i*(++j);
                }
            }
        }
        int sum=0;
        for (int i=2;i<n;i++)
            sum += primes[i];
        return sum;
    }
};

