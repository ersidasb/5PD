using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class RSASignature
    {
        private int q;
        private int p;
        List<int> primes = new List<int>();

        public int generatePrime()
        {
            int max = 1000;
            int min = 13;

            if(primes.Count == 0)
            {
                for (int i = min; i < max; i++)
                {
                    int cnt = 0;
                    for (int j = 1; j < max; j++)
                        if (i % j == 0)
                            cnt++;
                    if (cnt == 2)
                        primes.Add(i);
                }
            }
            Random random = new Random();
            int index = random.Next(0, primes.Count - 1);

            return primes[index];
        }

        public List<int> getMessageSignature(string message)
        {
            List<int> keyAndSignature = new List<int>();
            p = generatePrime();
            q = generatePrime();

            int n = p * q;
            keyAndSignature.Add(n);

            int fi = (q - 1) * (p - 1);

            int e = 2;
            while (e < fi)
            {
                if (DBD(e, fi) == 1)
                    break;
                else
                    e++;
            }
            keyAndSignature.Add(e);

            int d = IEA(e, fi);

            foreach (char c in message.ToCharArray())
            {
                keyAndSignature.Add((Int32)BigInteger.ModPow(c, d, n));
            }

            return keyAndSignature;
        }

        private int DBD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a | b;
        }
        private int IEA(int e, int N)
        {
            int r0, r1, s0, s1, t0, t1, ri, qi, min;
            int r0const, r1const;

            int s = 0, t = 0, d;

            if (N < e)
            {
                min = N;
                r0 = N;
                r0const = e;
                r1 = e;
                r1const = N;
            }
            else
            {
                min = e;
                r0 = e;
                r0const = N;
                r1 = N;
                r1const = e;
            }

            ri = min;
            s0 = 1;
            s1 = 0;

            t0 = 0;
            t1 = 1;

            while (ri >= 1)
            {
                ri = r0 % r1;
                if (ri < 1)
                    break;

                qi = (r0 - ri) / r1;

                t = s0 - qi * s1;
                s = t0 - qi * t1;

                s0 = s1;
                s1 = t;

                t0 = t1;
                t1 = s;

                r0 = r1;
                r1 = ri;
            }

            if ((s * r0const) + (t * r1const) == 1)
            {
                d = t;
                if (d < 0)
                {
                    d = d + N;
                    return d;
                }
                return d;
            }
            return 0;
        }
    }
}
