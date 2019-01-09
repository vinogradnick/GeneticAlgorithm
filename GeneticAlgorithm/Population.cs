using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Population:IPopulation
    {
        public IFitnessFunction FitnessFunction { get; set; }
        public List<IChromosome> PopulationList { get;  set; }
        public int PopulationSize { get;  set; }
        public int CountInvidials { get;  set; }
        public int SelectionSize { get; set; }
        public float FitnessMax{ get; set; }
        public IChromosome BestChromosome { get; set; }

        public void Selection()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Конструктор популяции
        /// </summary>
        /// <param name="size">размер популяции</param>
        /// <param name="count">Количество особей в популяции</param>
        /// <param name="selectionSize">Количество особей для выбора</param>
        /// <param name="genomeSize">Размер генома</param>
        /// <param name="fitness"></param>
        public Population(int size, int count, int selectionSize,int genomeSize,IFitnessFunction fitness)
        {
            this.PopulationSize = size;
            this.SelectionSize = selectionSize;
            PopulationList = new List<IChromosome>(count);
            this.FitnessFunction = fitness;
            Fill(genomeSize);
            
        }

        private void Fill(int genomeSize)
        {
            for (int i = 0; i < PopulationList.Capacity; i++)
            {
                IChromosome chromosome =new Chromosome(genomeSize);
                chromosome.FillGenome();
                PopulationList.Add(chromosome);
            }
        }
        public void EliteSelection()
        {
            foreach (IChromosome ch in PopulationList)
                ch.Fitness = FitnessFunction.GetFitness(ch);
            PopulationList.Sort((x,y)=>(int)x.Fitness-(int)y.Fitness);
            PopulationList.RemoveRange(0,PopulationList.Count-SelectionSize);
            
            FitnessMax = PopulationList[0].Fitness;
            BestChromosome = PopulationList[0];

        }

        public void CrossingoverPopulation()
        {
            EliteSelection();
            List<IChromosome> newPopulation = new List<IChromosome>();
            while (newPopulation.Count != PopulationSize)
            {
                IChromosome[] parents = RouleteParentsSelection();
                newPopulation.AddRange(Crossingover(parents[0],parents[1]));
            }
            
            PopulationList = newPopulation;
        }

        public IChromosome[] RouleteParentsSelection()
        {
            Random random=  new Random();
            List<IChromosome> parents = new List<IChromosome>();
            while (parents.Count != 2)
            {
                parents.Add(Roulete(PopulationList[random.Next(0,PopulationList.Count)],PopulationList[random.Next(0,PopulationList.Count)]));
            }

            return parents.ToArray();
        }

        public IChromosome Roulete(params IChromosome[] chromosomes)
        {
            IChromosome maxChromosome=new Chromosome(chromosomes[0].Genome.Length);
            for (int i = 0; i < chromosomes.Length; i++)
                if (chromosomes[i].Fitness > maxChromosome.Fitness)
                    maxChromosome = chromosomes[i];
            return maxChromosome;
        }
        public IChromosome[] Crossingover(IChromosome partner1, IChromosome partner2)
        {
           Random random = new Random();
           int startPoint = random.Next(0, partner1.Genome.Length-1);
            int endPoint = random.Next(0, partner1.Genome.Length);
           IChromosome child1 = new Chromosome((ushort[])partner1.Genome.Clone());
           IChromosome child2=new Chromosome((ushort[])partner2.Genome.Clone());

            for (int i = startPoint; i < endPoint; i++)
            {
                child1.Genome[i] = partner2.Genome[i];
                child2.Genome[i] = partner1.Genome[i];
            }
            return new IChromosome[2]{ child1,child2};
        }
        public void Print(List<IChromosome> list)
        {
            for (int i = 0; i < list.Count; i++)
                Debug.WriteLine(list[i].Fitness);
        }

    }
}