using System;

namespace GeneticAlgorithm
{
    public interface IFitnessFunction
    {
        float GetFitness(IChromosome chromosome);
    }
    public class FitnessFunction:IFitnessFunction
    {
        public float GetFitness(IChromosome chromosome)
        {
            
            float fitness = 0;
            
            for (int i = 0; i <chromosome.Genome.Length; i++)
            {

                fitness += chromosome.Genome[i];
            }

            return fitness;
        }
    }
}