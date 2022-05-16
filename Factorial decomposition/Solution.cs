using System.Collections.Generic;
using System.Text;
using System.Numerics;

struct Degree
{
    public BigInteger Base { get; set; } 
    public int Power { get; set; }
}

class FactDecomp
{
	public static string Decomp(int n)
	{
        List<Degree> primeFactors = new List<Degree>();
        for (BigInteger i = 2; i <= n; i++)
        {
            bool PrimeNumber = true;
            for (int j = 0; j < primeFactors.Count; j++)
            {
                BigInteger currentNumber = i;
                BigInteger baseDegree = primeFactors[j].Base;

                while ((currentNumber % baseDegree) == 0)
                {
                    PrimeNumber = false;
                    SetDegreeWithIncrementedPower(primeFactors, j);
                    currentNumber /= baseDegree;
                }
            }
            if (PrimeNumber)
                primeFactors.Add(new Degree { Base = i, Power = 1 });
        }

        return DecompositePrimeFactorsToString(primeFactors);
    }

    public static void SetDegreeWithIncrementedPower(List<Degree> primeFactors, int index)
    {
        Degree degree = primeFactors[index];
        degree.Power++;
        primeFactors[index] = degree;
    }

    public static string DecompositePrimeFactorsToString(List<Degree> primeFactors)
    {
        StringBuilder decompositionResult = new StringBuilder();

        for (int i = 0; i < primeFactors.Count; i++)
        {
            if (i != 0)
                decompositionResult.Append(" * ");

            if (primeFactors[i].Power > 1)
                decompositionResult.Append(primeFactors[i].Base + "^" + primeFactors[i].Power);
            else
                decompositionResult.Append(primeFactors[i].Base);
        }
        return decompositionResult.ToString();
    }
}