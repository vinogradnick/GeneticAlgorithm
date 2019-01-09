using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public interface IMutator
    {
        float MutationChance { get; }
        List<IChromosome> Mutate( List<IChromosome> population);
    }

    public class Mutator:IMutator
    {
        private float _mutationChance;
        
        public Mutator(float mutationChance)
        {
            this._mutationChance = mutationChance;
        }

        public List<IChromosome> Mutate( List<IChromosome> population)
        {
            Random rd = new Random();
            for (int i = 0; i <population.Count*_mutationChance; i++)
            {
                int number = rd.Next(0, population.Count);
                population[number]=MutateChromosome(population[number]);
            }

            return population;
        }

        public IChromosome MutateChromosome(IChromosome chromosome)
        {
            int genomeLength = chromosome.Genome.Length;
            Random random = new Random();
            int countMutate = (int)(chromosome.Genome.Length * _mutationChance);
            for (int i = 0; i <countMutate ; i++)
            {
                int number = random.Next(0, genomeLength);
                chromosome.Genome[number] = chromosome.Genome[number] == 0 ? (ushort) 1 : (ushort) 0;
            }

            return chromosome;
        }
        public float MutationChance => _mutationChance;
    }
}