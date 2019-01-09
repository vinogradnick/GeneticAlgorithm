using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class GeneticAlgorithm
    {
        private IPopulation _population;
        private IMutator _mutator;
        public float PopulationFitness { get; set; }
        public IChromosome BestChromosome { get; set; }

        public GeneticAlgorithm(IPopulation population, IMutator mutator)
        {
            this._population = population;
            this._mutator = mutator;
        }

        public void Evaluate()
        {
            _population.EliteSelection();
            _population.CrossingoverPopulation();
           _population.PopulationList= _mutator.Mutate(_population.PopulationList);
            this.PopulationFitness = _population.FitnessMax;
            this.BestChromosome = _population.BestChromosome;
        }

        
    }
}
