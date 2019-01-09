using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public interface IPopulation
    {
        List<IChromosome> PopulationList { get; set; }
        int PopulationSize { get; set; }
        int CountInvidials { get; set; }
        int SelectionSize { get; set; }
        void Selection();
        void CrossingoverPopulation();
        IChromosome[] Crossingover(IChromosome partner1, IChromosome partner2);
        void EliteSelection();
        float FitnessMax { get; set; }
        IChromosome BestChromosome { get; set; }
    }
}